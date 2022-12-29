using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class paraKontrol : MonoBehaviour
{

   
 

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "karakter") // karakter paraya çarptýðýnda
        { 
            oyunAyar.skorSayi++; // oyunayar.cs içindeki puaný bir arttýr.

            Destroy(this.gameObject); // parayý götür. Çünkü bu script untiy'de para elemanýnýn içine atýldý...

        }

    }

   

}
