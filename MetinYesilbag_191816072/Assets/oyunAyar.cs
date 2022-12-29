using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // oyundaki skor yazýsýný deðiþþtirmek için ekledik....Text sýnýfý çalýþsýn diye...
using UnityEngine.SceneManagement; // sahne geçiþleri için ekledik...
using System;

public class oyunAyar : MonoBehaviour
{
    //Skor arttýrma----------------------------

    public Text skorYazi; // unity'de OyunAyar'a týkayýnca  skorYazi tanýmsýz görünecek.
   // O yüzden, oyunayar componentine týkladýktan sonra
   // Hiyerarþi'deki skorYazi'yi, Inspector içindeki skorYazi içine sürükleyip atacaðýz...
    public static int skorSayi; // text formatýna dönüþtürmeden önce sayýnýn kaç olduðunu bilmemiz lazým...

    public Text kalanCan;   
    public static int kalanCanSayi=10; // bunu unity'de belirle (Örneðin 10)

    

    public int atlanacakSahneID;// bunu public yaparak, OyunAyar kýsmýndan  her sahnede farklý sayý verebilme imkaný sunduk.
     // Örneðin, unity'de OyunAyar'a týklyarak, Inspector da atlanacakSahneID kýsmýna Seviye1 de 2; Seviye2'de 3 yazacaðýz...


    public GameObject panel; // Seviye atlarken gerekli olan panelin aktif edilmesi için gerekli...
    //unity de oyunAyar'a týkla. Inspectordaki panel içine bitisPanelini  sürükle
    public GameObject karakter; // Seviye atlarken karakterin pasif edilmesi için gerekli... 
    //unity de oyunAyar'a týkla. Inspectordaki karakter içine  tHÝRDpERSONcONTROLL'Ü  SÜRÜKLE
    public int toplanacakPara=6; // level atlamak için gerekli olan yildiz sayýsý...
     //Bunu public yaptýk ki, her sahnede unity'de kendimiz deðiþtirebilelim.
    public int dusunceKactanBaslasin;// yere düþerse yine ayný leveldan baþlamasý için burada public tanýmladýk.
    // Deðerleri unity de vereceðiz.
    //Örneðin Seviye1 de 1, seviye_2'de 2 deðerini vereceðiz...
 

    void Update()
    {
        skorYazi.text = skorSayi.ToString(); // skoru güncel þekilde canvas içine yazsýn

        kalanCan.text = kalanCanSayi.ToString(); // Can'ý güncel þekilde canvas içine yazsýn

         

        //-----Bitiþ Panelini aktif etme--------------------

        //Not: UI-> Panel sekmesinden eklenen paneli pasif yapmak için, GameObject->Toggle Active State'i seçiyoruz.
        if (skorSayi == toplanacakPara)// Örneðin 1. levelda 5 para toplarsa oyun atlasýn.. toplanacakPara deðiþkeni her sahnede unity de verilsin...
        {
            panel.SetActive(true); // panel görünsün
                                   
             
        }
        //------------Bitiþ Panelini aktif etme BÝTTÝ--------------------------------


        //---- karakter düþünce oyunu yeniden baþlatma-----------------------------------------------

        if (karakter.transform.position.y < -6.0f) // karakter oyun alanýndan aþaðý düþerse
        {
            SceneManager.LoadScene(dusunceKactanBaslasin); // unity de OyurAyar(Bos) içindeki dusunceKactanBaslasin deðerinde sahneyi yeniden baþlatýr...
            skorSayi = 0; // skoru sýfýrla

        }

        //-----oyunu yeniden baþlatma BÝTTÝ---------------------------


        //---- CANLAR tükenince oyunu yeniden baþlatma-----------------------------------------------

        if (kalanCanSayi==0) // karakter'in caný biterse
        {
            SceneManager.LoadScene(dusunceKactanBaslasin); // unity de OyurAyar(Bos) içindeki dusunceKactanBaslasin deðerinde sahneyi yeniden baþlatýr...
            skorSayi = 0; // skoru sýfýrla
            kalanCanSayi = 10; // canlar tekrar 10 olsun...
            AtesEtme.zombiSayi = 0;
        }

        //-----oyunu yeniden baþlatma BÝTTÝ---------------------------

    }

    public void seviyeAtla()
    {

        SceneManager.LoadScene(atlanacakSahneID);

        //Öncelikle scene klasörü içine yeni bir scene oluþturuyoruz.
        //unity de file->build settings'e girp bu scene'i (add open scene) ekliyoruz.
        //Oradaki ID'ye göre (biz yeni scene'i 2 nolu ID'ye getirdik)atama yapýyoruz.
        //unity'de OyunAyar componentine bu scripti sürüklüyoruz. (Yoksa scripti unity görmüyor)
        // daha sonra unity de bitisButonuna týklayýp, Inspector içinde onClick'te + iþaretine basýp OyunAyar component'ini içine sürüklüyorz.
        //Son olarak da onclick için de function bölümünde bu seviyeAtla fonksiyonumuzu seçiyoruz ki, butona týklanýnca hangi fonksiyon devreye girecek buton bilsin...

        skorSayi = 0; // yeni level da paralar 0 dan baþlasýn...
        kalanCanSayi = 10; // canlar tekrar 10 olsun...
       // AtesEtme.zombiSayi = 0;
    }



    public void oyunaBasla()
    {

        SceneManager.LoadScene(atlanacakSahneID);
 
        skorSayi = 0; // yeni level da paralar 0 dan baþlasýn...
        kalanCanSayi = 10; // canlar tekrar 10 olsun...
    }


    public void oyunBitir()
    {
         Application.Quit();

        
    }


}
