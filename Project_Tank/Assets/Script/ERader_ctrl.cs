using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERader_ctrl : MonoBehaviour
{
    public GameObject Parent;

    private void OnTriggerStay(Collider other)
    {
        
        if (other.transform.tag == "Player") // 인지범위를 수치화 하고 싶은데 그냥 엔진에서 눈대중으로 대강 설정함
        {
            Parent.transform.parent.GetComponentInParent<Enemy_ctrl>().isFind = true; // 부모 오브젝트의 스크립트의 변수에 접근
            Debug.Log("check_trigger");
        }
            

        
    }
}
