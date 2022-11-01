using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollider_ctrl : MonoBehaviour
{
    public ParticleSystem penetrated;

    public GameObject parent;

    
    private void OnCollisionEnter(Collision collision) // 공격 받았을 때 플레이어를 찾아내는 기능을 구현해야함
    {
        if (collision.transform.tag == "Bullet")
        {
            parent.gameObject.transform.parent.GetComponentInParent<Enemy_ctrl>().Health -= 1;
            Instantiate(penetrated, collision.transform.position, collision.transform.rotation);
        }

    }
}
