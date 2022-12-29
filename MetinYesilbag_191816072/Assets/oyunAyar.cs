using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // oyundaki skor yaz�s�n� de�i��tirmek i�in ekledik....Text s�n�f� �al��s�n diye...
using UnityEngine.SceneManagement; // sahne ge�i�leri i�in ekledik...
using System;

public class oyunAyar : MonoBehaviour
{
    //Skor artt�rma----------------------------

    public Text skorYazi; // unity'de OyunAyar'a t�kay�nca  skorYazi tan�ms�z g�r�necek.
   // O y�zden, oyunayar componentine t�klad�ktan sonra
   // Hiyerar�i'deki skorYazi'yi, Inspector i�indeki skorYazi i�ine s�r�kleyip ataca��z...
    public static int skorSayi; // text format�na d�n��t�rmeden �nce say�n�n ka� oldu�unu bilmemiz laz�m...

    public Text kalanCan;   
    public static int kalanCanSayi=10; // bunu unity'de belirle (�rne�in 10)

    

    public int atlanacakSahneID;// bunu public yaparak, OyunAyar k�sm�ndan  her sahnede farkl� say� verebilme imkan� sunduk.
     // �rne�in, unity'de OyunAyar'a t�klyarak, Inspector da atlanacakSahneID k�sm�na Seviye1 de 2; Seviye2'de 3 yazaca��z...


    public GameObject panel; // Seviye atlarken gerekli olan panelin aktif edilmesi i�in gerekli...
    //unity de oyunAyar'a t�kla. Inspectordaki panel i�ine bitisPanelini  s�r�kle
    public GameObject karakter; // Seviye atlarken karakterin pasif edilmesi i�in gerekli... 
    //unity de oyunAyar'a t�kla. Inspectordaki karakter i�ine  tH�RDpERSONcONTROLL'�  S�R�KLE
    public int toplanacakPara=6; // level atlamak i�in gerekli olan yildiz say�s�...
     //Bunu public yapt�k ki, her sahnede unity'de kendimiz de�i�tirebilelim.
    public int dusunceKactanBaslasin;// yere d��erse yine ayn� leveldan ba�lamas� i�in burada public tan�mlad�k.
    // De�erleri unity de verece�iz.
    //�rne�in Seviye1 de 1, seviye_2'de 2 de�erini verece�iz...
 

    void Update()
    {
        skorYazi.text = skorSayi.ToString(); // skoru g�ncel �ekilde canvas i�ine yazs�n

        kalanCan.text = kalanCanSayi.ToString(); // Can'� g�ncel �ekilde canvas i�ine yazs�n

         

        //-----Biti� Panelini aktif etme--------------------

        //Not: UI-> Panel sekmesinden eklenen paneli pasif yapmak i�in, GameObject->Toggle Active State'i se�iyoruz.
        if (skorSayi == toplanacakPara)// �rne�in 1. levelda 5 para toplarsa oyun atlas�n.. toplanacakPara de�i�keni her sahnede unity de verilsin...
        {
            panel.SetActive(true); // panel g�r�ns�n
                                   
             
        }
        //------------Biti� Panelini aktif etme B�TT�--------------------------------


        //---- karakter d���nce oyunu yeniden ba�latma-----------------------------------------------

        if (karakter.transform.position.y < -6.0f) // karakter oyun alan�ndan a�a�� d��erse
        {
            SceneManager.LoadScene(dusunceKactanBaslasin); // unity de OyurAyar(Bos) i�indeki dusunceKactanBaslasin de�erinde sahneyi yeniden ba�lat�r...
            skorSayi = 0; // skoru s�f�rla

        }

        //-----oyunu yeniden ba�latma B�TT�---------------------------


        //---- CANLAR t�kenince oyunu yeniden ba�latma-----------------------------------------------

        if (kalanCanSayi==0) // karakter'in can� biterse
        {
            SceneManager.LoadScene(dusunceKactanBaslasin); // unity de OyurAyar(Bos) i�indeki dusunceKactanBaslasin de�erinde sahneyi yeniden ba�lat�r...
            skorSayi = 0; // skoru s�f�rla
            kalanCanSayi = 10; // canlar tekrar 10 olsun...
            AtesEtme.zombiSayi = 0;
        }

        //-----oyunu yeniden ba�latma B�TT�---------------------------

    }

    public void seviyeAtla()
    {

        SceneManager.LoadScene(atlanacakSahneID);

        //�ncelikle scene klas�r� i�ine yeni bir scene olu�turuyoruz.
        //unity de file->build settings'e girp bu scene'i (add open scene) ekliyoruz.
        //Oradaki ID'ye g�re (biz yeni scene'i 2 nolu ID'ye getirdik)atama yap�yoruz.
        //unity'de OyunAyar componentine bu scripti s�r�kl�yoruz. (Yoksa scripti unity g�rm�yor)
        // daha sonra unity de bitisButonuna t�klay�p, Inspector i�inde onClick'te + i�aretine bas�p OyunAyar component'ini i�ine s�r�kl�yorz.
        //Son olarak da onclick i�in de function b�l�m�nde bu seviyeAtla fonksiyonumuzu se�iyoruz ki, butona t�klan�nca hangi fonksiyon devreye girecek buton bilsin...

        skorSayi = 0; // yeni level da paralar 0 dan ba�las�n...
        kalanCanSayi = 10; // canlar tekrar 10 olsun...
       // AtesEtme.zombiSayi = 0;
    }



    public void oyunaBasla()
    {

        SceneManager.LoadScene(atlanacakSahneID);
 
        skorSayi = 0; // yeni level da paralar 0 dan ba�las�n...
        kalanCanSayi = 10; // canlar tekrar 10 olsun...
    }


    public void oyunBitir()
    {
         Application.Quit();

        
    }


}
