using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private float CurrentHealth;
    private float MaxHealth;
    public Slider healthbar;
    public Scene currentscene;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 3f;
        CurrentHealth = MaxHealth;
        currentscene = SceneManager.GetActiveScene();
    }
    public void HealthChange()
    { 
        
        if (CurrentHealth <= 3)
        {
            //change bar
            CurrentHealth = CurrentHealth - 1f;
            healthbar.value = CalculateHealth();


        }
        if (CurrentHealth < 1f)
        { 
            Destroy(gameObject);
            SceneManager.LoadScene(currentscene.name);
        }
        

    }
    float CalculateHealth()
    {
        return CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
