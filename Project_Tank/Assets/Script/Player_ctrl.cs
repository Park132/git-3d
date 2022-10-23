using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ui�� ������ �ð� ���� �ؾ� ��

public class Player_ctrl : MonoBehaviour
{
    public GameObject ptank;
    public GameObject pturret;
    public GameObject pcannon;
    public GameObject bullet_prefab;
    public GameObject bullet_spawn_point;

    public ParticleSystem bullet_spawn_effect;
    //����ȿ���� �ֱ�

    public Camera camera_pos;

    public float Health = 100.0f; // ������ �ִ� �Ͱ� �޴°�, ����, ��ź ���� �˰��� �����غ��� 
    //���� �ΰ����ɵ� �����غ���

    [SerializeField]
    private float world_timer = 0.0f;
    private float reload_timer = 5.0f;
    private float firepower = 2000.0f; // ��ź�� ���ϴ� �� //������ 20000
    private float movespeed = 15.0f; // ��ũ �� �� �̵��ӵ�
    private float headrotationspeed = 1.0f; // ��ž ȸ���ӵ�
    private float bodyrotationspeed = 22.0f; // ��ü ȸ���ӵ�
    

    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        world_timer += Time.deltaTime;

        BodyMove();
        TurretMove();
        OnFire();
        CameraLook();
    }

    void BodyMove() // ��ũ �̵� V 
    {
        Vector3 ptank_position = ptank.transform.position;

        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");

        if (x != 0)
        {
            isMoving = true;
            this.transform.Translate(Vector3.forward * x * movespeed * Time.deltaTime);
        }
        else
            isMoving = false;
        
        this.transform.Rotate(new Vector3(0, y * bodyrotationspeed * Time.deltaTime, 0));
    }

    void TurretMove()// ��ž ���� �Ĵٺ����ϱ�!!! delay�� ��� �ٱ� V
    {
        Ray ray = camera_pos.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit_res;

        if(Physics.Raycast(ray, out hit_res))
        {
            Vector3 mouseDir = new Vector3(hit_res.point.x, pcannon.transform.position.y, hit_res.point.z) - transform.position;

            pturret.transform.rotation = Quaternion.LerpUnclamped(pturret.transform.rotation, Quaternion.LookRotation(mouseDir), headrotationspeed * Time.deltaTime);

            //pturret.transform.forward  = mouseDir;
        }
    }

    void OnFire() // �߻� �����ϱ� V 
    {
        if (Input.GetMouseButtonDown(0) && world_timer >= reload_timer)
        {
            GameObject bullet_prefabs = Instantiate(bullet_prefab, bullet_spawn_point.transform.position, bullet_spawn_point.transform.rotation);
            ParticleSystem bullet_spawn_effect_prefabs = Instantiate(bullet_spawn_effect, bullet_spawn_point.transform.position, bullet_spawn_point.transform.rotation);

            bullet_prefabs.gameObject.GetComponent<Rigidbody>().AddForce(bullet_spawn_point.transform.forward * firepower);
            world_timer = 0;
        }
    }

    void CameraLook() // ī�޶� ���� ���� V
    {
        Vector3 offset = new Vector3(0, 150, -120);

        camera_pos.transform.position = ptank.transform.position + offset;
        camera_pos.transform.LookAt(ptank.transform);
    }
}
