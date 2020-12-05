using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kontrol : MonoBehaviour
{
    public Sprite []KusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKont = true;
    int kusSayac = 0;
    float kusAnimasyonZaman = 0;
    Rigidbody2D fizik;
    int puan = 0;
    public Text puanText;
    bool oyunBitti=true;
    Oyunkontrol oyunkontrol;
    AudioSource []sesler;
    int enYuksekPuan = 0;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunkontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<Oyunkontrol>();
        sesler = GetComponents<AudioSource>();
        enYuksekPuan = PlayerPrefs.GetInt("kayıt");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& oyunBitti)
        {
            fizik.velocity = new Vector2(0, 0);// hızı sıfır yaptık
            fizik.AddForce(new Vector2(0, 200));// kuvvet uyguladık
            sesler[0].Play();
            

        }
        if (fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 30);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -30);
        }
        Animasyon();

    }
    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.2f)
        {
            kusAnimasyonZaman = 0;
            if (ileriGeriKont)
            {
                spriteRenderer.sprite = KusSprite[kusSayac]; // 0 1 2
                kusSayac++; // 3
                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKont = false;

                }

            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac]; // 2 1 0
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKont = true;

                }


            }

        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Puan")
        {
            puan++;
            puanText.text = "Puan= " + puan;
            sesler[1].Play();

            Debug.Log(puan);
        }
        if (collision.gameObject.tag=="Engel")
        {
            sesler[2].Play();
            oyunBitti = false;
            oyunkontrol.oyunbitti();
            GetComponent<CircleCollider2D>().enabled = false;

            if (puan>enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("kayıt", enYuksekPuan);

            }
            Invoke("anaMenuyeDon", 2);
        }
    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puanKayıt",puan);
        SceneManager.LoadScene("anaMenu");
    }
}
