using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_ctrl : MonoBehaviour
{
    public void GoGame()
    {
        SceneManager.LoadScene("test_map_for_navmesh");
    }
}
