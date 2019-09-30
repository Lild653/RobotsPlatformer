using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    public string loadlevel;

    private void OnTriggerEnter(Collider other)
    {
        print('h');
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadlevel);
        }
    }

    
}
