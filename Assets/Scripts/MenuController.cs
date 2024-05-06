using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    void Start()
    {
        instance = this;
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("level_1");
    }

}
