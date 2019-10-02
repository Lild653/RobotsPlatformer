using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    public string loadlevel;

    private float wait = 3;

    private bool collided = false;
    private void Update()
    {
        if(collided){
            wait -= Time.deltaTime;
        }
        if(wait <= 0){
                SceneManager.LoadScene(loadlevel);
            }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            collided = true;
        }
    }

    
}
