using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public LayerMask Fruits;
    //[SerializeField] AudioClip FruitHiding;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==Fruits)
        {
           // SoundManager.instance.playSound(FruitHiding);

            Destroy(collision.gameObject);
        }
        
    }
}
