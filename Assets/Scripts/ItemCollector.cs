using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Apples=0;
    [SerializeField] private Text Apple_Text;
    [SerializeField] private AudioSource CollectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            CollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Apples++;
            Apple_Text.text = "APPLES: " + Apples ;

        }
    }
}
