using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ctrl : MonoBehaviour
{
    public GameObject etank;
    public GameObject eturret;
    public GameObject effect_pos;
    public GameObject target;
    public GameObject rader; // ū �� �ݶ��̴��� ���� emptyobject�� ���⿡ ��ӽ��� ���⿡ �÷��̾ ������ �����ϰ� �� ����
    public GameObject ebsp; // �Ѿ��� ������ �� ����
    public GameObject bullet_prefab; // �Ѿ� ������

    public bool isFind = false; // �÷��̾ ������ ���� �ִ��� �Ǵ��ϰ� �� �ִ� �οﺯ��

    // �� �ɷ�ġ
    public float Health = 2.0f;
    public float movingspeed = 20.0f;
    public float rotationspeed = 22.0f;
    public float eheadrotationspeed = 2.0f;
    public float eworld_timer = 0.0f;
    public float ereload_timer = 4.0f;
    public float efirepower = 2000.0f;

    // �߻� ����Ʈ
    public ParticleSystem bullet_spawn_effect;

    // �״� ����� ���� ��ƼŬ, ��ҵ�
    public ParticleSystem penetrated;
    public ParticleSystem effectdead1;
    public ParticleSystem effectdead2;

    public int i = 0;
    private float dead_timer = 0f;

    private void Start()
    {
        eturret.gameObject.GetComponent<Rigidbody>().isKinematic = true; // ������� �� ��ž�� ���뿡 �ٿ����� ����
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

    private void OnCollisionEnter(Collision collision) // ���� �޾��� �� �÷��̾ ã�Ƴ��� ����� �����ؾ���
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
        isFind = false; // ���� �� �ൿ ����
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

        try // ���� ������ �Ⱦ ã�� ���ϴ� ��츦 ����ó����
        {
            if (isFind)
            {
                target = GameObject.FindGameObjectWithTag("Player");
                if(eworld_timer >= ereload_timer)
                {
                    OnFire();
                }
            }

            // õõ�� �����̱� ���� �̰ɷ� ���ϴ�
            Vector3 target_position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) - eturret.transform.position;

            eturret.transform.rotation = Quaternion.Slerp(eturret.transform.rotation, Quaternion.LookRotation(target_position), eheadrotationspeed * Time.deltaTime);

        }
        catch 
        {
            Debug.Log("Didn't Find Player, yet");
        }
        /* �ε巴�� �ʰ� �����ϰ� ��, �ϴ��� ���ܳ��� 
        Vector3 target_position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) - eturret.transform.position;

        eturret.transform.forward = target_position;
        */
    }

    // �÷��̾� ��ũ��Ʈ�� �߻� ���� �Լ�
    void OnFire() // �߻� �����ϱ� V 
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
