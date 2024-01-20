using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            //animation
            //audio
        }
    }

}
