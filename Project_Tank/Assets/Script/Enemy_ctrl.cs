using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ctrl : MonoBehaviour
{
    public GameObject etank;
    public GameObject eturret;
    public GameObject effect_pos;
    public GameObject target;
    public GameObject rader; // 큰 원 콜라이더를 가진 emptyobject를 여기에 상속시켜 여기에 플레이어가 닿을시 추적하게 할 생각
    public GameObject ebsp; // 총알을 나가게 할 예정
    public GameObject bullet_prefab; // 총알 프리팹

    public bool isFind = false; // 플레이어가 범위에 들어와 있는지 판단하게 해 주는 부울변수

    // 적 능력치
    public float Health = 2.0f;
    public float movingspeed = 20.0f;
    public float rotationspeed = 22.0f;
    public float eheadrotationspeed = 2.0f;
    public float eworld_timer = 0.0f;
    public float ereload_timer = 4.0f;
    public float efirepower = 2000.0f;

    // 발사 이펙트
    public ParticleSystem bullet_spawn_effect;

    // 죽는 모습을 위한 파티클, 요소들
    public ParticleSystem penetrated;
    public ParticleSystem effectdead1;
    public ParticleSystem effectdead2;

    public int i = 0;
    private float dead_timer = 0f;

    private void Start()
    {
        eturret.gameObject.GetComponent<Rigidbody>().isKinematic = true; // 살아있을 때 포탑을 몸통에 붙여놓기 위함
    }
    // Update is called once per frame
    void Update()
    {
        eworld_timer += Time.deltaTime;
        Debug.Log(isFind);

        
        if (Health <= 0f)
            EffectDead();
        else
            AttackPlayer();

    }

    private void OnCollisionEnter(Collision collision) // 공격 받았을 때 플레이어를 찾아내는 기능을 구현해야함
    {
        if(collision.transform.tag == "Bullet")
        {
            Health--;
            Instantiate(penetrated, collision.transform.position, collision.transform.rotation);
        }

    }

    void EffectDead() // done.
    {
        eturret.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        isFind = false; // 죽은 후 행동 정지
        while (i < 1)
        {
            Instantiate(effectdead1, effect_pos.transform.position, effect_pos.transform.rotation);
            i++;
        }

        if(dead_timer >= 3.0f)
        {
            
            while (i < 2)
            {
                Instantiate(effectdead2, etank.transform.position, etank.transform.rotation);
                eturret.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 3f), Random.Range(-1f, 1f)).normalized * 1000f);
                eturret.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 1000f);
                
                i++;
            }
        }

        if (dead_timer >= 10.0f)
        {
            Destroy(this.gameObject);
        }
        dead_timer += Time.deltaTime;
    }

    void AttackPlayer()
    {
        Debug.DrawRay(ebsp.transform.position, ebsp.transform.forward * 4000f, Color.red);

        try // 빨간 에러가 싫어서 찾지 못하는 경우를 예외처리함
        {
            if (isFind)
            {
                target = GameObject.FindGameObjectWithTag("Player");
                if(eworld_timer >= ereload_timer)
                {
                    OnFire();
                }
            }

            // 천천히 움직이기 위해 이걸로 갑니다
            Vector3 target_position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) - eturret.transform.position;

            eturret.transform.rotation = Quaternion.Slerp(eturret.transform.rotation, Quaternion.LookRotation(target_position), eheadrotationspeed * Time.deltaTime);

        }
        catch 
        {
            Debug.Log("Didn't Find Player, yet");
        }
        /* 부드럽지 않고 딱딱하게 됨, 일단은 남겨놓기 
        Vector3 target_position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) - eturret.transform.position;

        eturret.transform.forward = target_position;
        */
    }

    // 플레이어 스크립트의 발사 관련 함수
    void OnFire() // 발사 구현하기 V 
    {
        GameObject bullet_prefabs = Instantiate(bullet_prefab, ebsp.transform.position, ebsp.transform.rotation);
        ParticleSystem bullet_spawn_effect_prefabs = Instantiate(bullet_spawn_effect, ebsp.transform.position, ebsp.transform.rotation);

        bullet_prefabs.gameObject.GetComponent<Rigidbody>().AddForce(ebsp.transform.forward * efirepower);
        eworld_timer = 0;
    }

    /*
    void EnemyFire()
    {
        if (isFind)
        {
            RaycastHit hit;
            if(Physics.Raycast(ebsp.transform.position, transform.forward, out hit) && eworld_timer >= ereload_timer)
            {
                Debug.Log("check!");
                eworld_timer = 0.0f;
            }
        }
    }
    */




}
