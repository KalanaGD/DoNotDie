using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;


    public void SetMaxHealth(float health)
    {
        _healthSlider.maxValue = health;
        _healthSlider.value = health;
    }
         
    public void SetHealth(float health)
    {
        _healthSlider.value = health;
    }


}
