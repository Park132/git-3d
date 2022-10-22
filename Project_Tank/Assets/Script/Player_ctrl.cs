using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ctrl : MonoBehaviour
{
    public GameObject ptank;
    public GameObject pturret;
    public GameObject camera_pos;

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
        HeadMove();
    }

    void BodyMove() // 탱크 이동
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

    void HeadMove()// 포탑 구현 쳐다보게하기!!!
    {
        Vector3 point = Camera.main.WorldToScreenPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, - Camera.main.transform.position.z));
        Debug.Log(point);
    }
    void CameraLook()
    {

    }
}
