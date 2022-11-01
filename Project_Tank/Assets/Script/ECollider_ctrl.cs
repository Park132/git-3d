using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollider_ctrl : MonoBehaviour
{
    public ParticleSystem penetrated;

    public GameObject parent;

    
    private void OnCollisionEnter(Collision collision) // ���� �޾��� �� �÷��̾ ã�Ƴ��� ����� �����ؾ���
    {
        if (collision.transform.tag == "Bullet")
        {
            parent.gameObject.transform.parent.GetComponentInParent<Enemy_ctrl>().Health -= 1;
            Instantiate(penetrated, collision.transform.position, collision.transform.rotation);
        }

    }
}
