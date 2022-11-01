using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class System_ctrl : MonoBehaviour
{
    private int winning_score = 2;

    public int eliminated_target = 0;

    public Text Score;
    public Text Reload;
    public Text Health;

    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;

    public GameObject player;

    private int i = 0;

    private void Start()
    {
        ButtonCtrl(false);
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("eliminated target : " + eliminated_target);
        Score.text = "eliminated target : " + eliminated_target.ToString() + " / " + winning_score;
        Reload.text = "Reload time : " + player.GetComponent<Enemy_ctrl>().ereload_timer.ToString();
        Health.text = "Health : " + player.GetComponent<Enemy_ctrl>().Health.ToString();

        if (eliminated_target == winning_score)
        {
            do
            {
                winning_score += 2;
                ButtonCtrl(true);
                Time.timeScale = 0;
            } while (i < 0);
        }

    }

    void ButtonCtrl(bool boolean)
    {
        btn1.SetActive(boolean);
        btn2.SetActive(boolean);
        btn3.SetActive(boolean);
    }

    public void Click_R()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_ctrl>().reload_timer -= 2.0f;
        Time.timeScale = 1;
        ButtonCtrl(false);
    }

    public void Click_D()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_ctrl>().penetrate_possibility += 2.0f;
        Time.timeScale = 1;
        ButtonCtrl(false);
    }

    public void Click_S()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_ctrl>().penetrate_possibility += 20.0f;
        Time.timeScale = 1;
        ButtonCtrl(false);
    }
}
