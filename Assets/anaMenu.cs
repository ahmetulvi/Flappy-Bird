using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sahneler arası geçiş yapmak için kullanılıyor.
using UnityEngine.UI;

public class anaMenu : MonoBehaviour
{
    public Text puanText;
    public Text puan;
    void Start()
    {
        int enYuksekSkor = PlayerPrefs.GetInt("puanKayıt");
        int puanGelen = PlayerPrefs.GetInt("kayıt");

        puanText.text = "Puan= " + enYuksekSkor;
        puan.text = "En Yüksek Puan= " + puanGelen;
    }

    void Update()
    {
        
    }
   public void OyunaGit()
    {
        SceneManager.LoadScene("level");
    }
   public void OyundanÇık()
    {
        Application.Quit();
    }
}
