using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   public float mesafe;

    public float mesafeAralik;

    public Transform target;

    Vector3 pos;

    public AudioSource SesKaynak2;
    public AudioClip OlumSesi;
 
 
    void Start()
    {
        SesKaynak2 = GetComponent<AudioSource>();
        
    }
 
    void Update()
    {
        mesafe = Vector3.Distance(transform.position, target.position);

        pos = new Vector3(target.position.x,transform.position.y,target.position.z);

        if (mesafe < mesafeAralik)
        {
            transform.LookAt(pos);
          
        }

      
 
    }
 
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "karakter") // karakter düþmana çarptýðýnda
        {
            oyunAyar.kalanCanSayi--; // oyunayar.cs içindeki kalan Caný 1 azalt

          
                //SesKaynak2.Play(2);
                //SesKaynak2.clip = OlumSesi;
             


        }



    }
     

    

}
