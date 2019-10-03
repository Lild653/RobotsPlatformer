using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeToLevel : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Liya");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Home");
    }

    public void GotoInstructionsScene()
    {
        SceneManager.LoadScene("Instructions");
    }
}
