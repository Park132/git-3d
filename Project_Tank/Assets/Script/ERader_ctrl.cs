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
            Parent.transform.parent.GetComponentInParent<Enemy_ctrl>().isFind = true; // �θ� ������Ʈ�� ��ũ��Ʈ�� ������ ����
            Debug.Log("check_trigger");
        }
            

        
    }
}
