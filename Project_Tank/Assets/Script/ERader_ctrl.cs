using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERader_ctrl : MonoBehaviour
{
    public GameObject Parent;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.transform.tag == "Player")
        {
            Parent.transform.parent.GetComponentInParent<Enemy_ctrl>().isFind = true; // 부모 오브젝트의 스크립트의 변수에 접근
            Debug.Log("check_trigger");
        }
            

        
    }
}
