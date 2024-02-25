using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{

    public int maxStamina = 30;
    public int currentStamina;

    public static PlayerStamina instance;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public HealthBar staminaBar;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxHealth(maxStamina);
    }

    public void UseStamina(int used)
    {

        if(currentStamina - used >= 0)
        {
            currentStamina -= used;

            staminaBar.SetHealth(currentStamina);

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen =  StartCoroutine(RegenStamina());
        }
        else
        {
            
        }
    }

    public bool CheckEnoughStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 30;
            staminaBar.SetHealth(currentStamina);
            yield return regenTick;
        }
        regen = null;
    }
}
