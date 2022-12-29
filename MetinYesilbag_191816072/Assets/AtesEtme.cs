using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // oyundaki skor yazısını değişştirmek için ekledik....Text sınıfı çalışsın diye...

public class AtesEtme : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject MermiCikisNoktasi;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public ParticleSystem MuzzleFlash;
   
    AudioSource SesKaynak;
    public AudioClip AtesSesi;
   
    public float Menzil;
     
    public Text zombi;
    public static int zombiSayi = 0;
 
 
    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        zombi.text = zombiSayi.ToString();  


        if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir == true && Time.time > GunTimer)
        {
            Fire();
            GunTimer = Time.time + TaramaHizi;
            ;
        }
    }

    void Fire()
    {

        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
        {
            MuzzleFlash.Play();
            SesKaynak.Play();
            SesKaynak.clip = AtesSesi;
            Debug.Log(hit.transform.name);


            if (hit.transform.gameObject.tag == "enemy") // mermi düşmana çarptığında
            {

                Destroy(GameObject.FindWithTag("enemy"));//bu da tag'a göre yok etme

                zombiSayi++;

            }



        }
    }

    

}