using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ctrl : MonoBehaviour
{
    public GameObject ptank;
    public GameObject pturret;
    public GameObject pcannon;
    public GameObject bullet_prefab;

    public Camera camera_pos;

    private float movespeed = 15.0f;
    private float headrotationspeed = 22.0f;
    private float bodyrotationspeed = 22.0f;
    

    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BodyMove();
        TurretMove();
    }

    void BodyMove() // 탱크 이동 V 
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

    void TurretMove()// 포탑 구현 쳐다보게하기!!! V
    {
        Ray ray = camera_pos.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit_res;

        if(Physics.Raycast(ray, out hit_res))
        {
            Vector3 mouseDir = new Vector3(hit_res.point.x, pcannon.transform.position.y, hit_res.point.z) - transform.position;
            pturret.transform.forward = mouseDir;
        }
    }

    void OnFire() // 발사 구현하기
    {

    }

    void CameraLook()
    {

    } //카메라 아직 구현 못함 
}
