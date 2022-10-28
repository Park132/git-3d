using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ctrl : MonoBehaviour
{
    public GameObject etank;
    public GameObject eturret;
    public GameObject effect_pos;

    public float Health = 1.0f;
    private float dead_timer = 0f;

    public int i = 0;

    public ParticleSystem penetrated;
    public ParticleSystem effectdead1;
    public ParticleSystem effectdead2;

    private void Start()
    {
        eturret.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0f)
        {
            EffectDead();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            Health--;
            Instantiate(penetrated, collision.transform.position, collision.transform.rotation);
        }
    }

    void EffectDead() // Á» ´õ ¼ÕºÁ¾ßµÊ
    {
        eturret.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        while (i < 1)
        {
            Instantiate(effectdead1, effect_pos.transform.position, effect_pos.transform.rotation);
            i++;
        }

        if(dead_timer >= 3.0f)
        {
            
            while (i < 2)
            {
                Instantiate(effectdead2, etank.transform.position, etank.transform.rotation);
                eturret.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 3f), Random.Range(-1f, 1f)).normalized * 1000f);
                eturret.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 1000f);
                
                i++;
            }
        }

        if (dead_timer >= 10.0f)
        {
            Destroy(this.gameObject);
        }
        dead_timer += Time.deltaTime;
    }
}
