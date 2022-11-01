using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ctrl : MonoBehaviour
{
    public GameObject bullet;
    public ParticleSystem ground_effect;

    public float penetrate_possibility = 0.7f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Tank")
        {
            Destroy(this.gameObject);
        }
        else if (collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(ground_effect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    /*
     총알이 플레이어에게 닿은 경우
    */
}
