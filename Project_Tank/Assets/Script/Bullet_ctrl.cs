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
     �Ѿ��� �÷��̾�� ���� ���


Ȯ��:
Random.Range(0, 8)


��ź
����Ʈ ����

����
����Ʈ ����
������ ����
��ǰ�ı�(?)*/
    void PenetratingAlgorithm(float possibility)
    {
        float x = Random.Range(0.0f, 1.0f);

        if(x <= possibility)
        {
            //��ź �� ����Ʈ
        }
        else
        {
            //���� �� ����Ʈ
        }
    }
}
