using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sesler : MonoBehaviour
{

    AudioSource SesKaynak;

    public AudioClip ParaSesi;

    

    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();


    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "para") // karakter paraya �arpt���nda
        {
            SesKaynak.Play();

            SesKaynak.clip = ParaSesi;
        }

    }
}
