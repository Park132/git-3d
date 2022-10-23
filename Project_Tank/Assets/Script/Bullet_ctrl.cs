using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ctrl : MonoBehaviour
{
    public GameObject bullet;
    

    public float penetrate_possibility = 0.7f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Tank")
        {
            Destroy(this.gameObject);
        }
    }
}
