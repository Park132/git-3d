using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject btn_main;

    public GameObject player; // ui에 변수들을 출력하기 위함

    private int i = 0;

    private void Start()
    {
        ButtonCtrl(false);
        btn_main.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        Score.text = "eliminated target : " + eliminated_target.ToString() + " / " + winning_score;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "eliminated target : " + eliminated_target.ToString() + " / " + winning_score;
        Reload.text = "Reload time : " + GameObject.FindGameObjectWithTag("Player").GetComponent<Player_ctrl>().reload_timer.ToString();
        Health.text = "Health : " + GameObject.FindGameObjectWithTag("Player").GetComponent<Player_ctrl>().Health.ToString();

        if (eliminated_target == 12)
        {
            btn_main.SetActive(true);
            ButtonCtrl(false);
            Time.timeScale = 0f;
        }
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

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Click_R()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_ctrl>().reload_timer -= 1.5f;
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
