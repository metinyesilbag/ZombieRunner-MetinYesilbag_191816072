using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class paraKontrol : MonoBehaviour
{

   
 

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "karakter") // karakter paraya �arpt���nda
        { 
            oyunAyar.skorSayi++; // oyunayar.cs i�indeki puan� bir artt�r.

            Destroy(this.gameObject); // paray� g�t�r. ��nk� bu script untiy'de para eleman�n�n i�ine at�ld�...

        }

    }

   

}
