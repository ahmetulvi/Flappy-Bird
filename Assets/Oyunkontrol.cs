using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyunkontrol : MonoBehaviour
{
   public GameObject GokyuzuBır;
   public GameObject GokyuzuIkı;
    Rigidbody2D fizik1;
    Rigidbody2D fizik2;
    float uzunluk = 0;
    public float ArkaPlanHız = 1.5f;

    public GameObject engel;
    public int kacAdetengel = 5;
    GameObject[] engeller;
    float degısımZamanı=0;
    int sayac;
    bool oyunBitti = true;
    void Start()
    {
        fizik1 = GokyuzuBır.GetComponent<Rigidbody2D>();
        fizik2 = GokyuzuIkı.GetComponent<Rigidbody2D>();

        fizik1.velocity = new Vector2(-ArkaPlanHız, 0);
        fizik2.velocity = new Vector2(-ArkaPlanHız, 0);
        uzunluk = GokyuzuBır.GetComponent<BoxCollider2D>().size.x;
        engeller = new GameObject[kacAdetengel];
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-10, -10), Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(-ArkaPlanHız, 0);
        }
    }

    void Update()
    {
        if (oyunBitti)
        {

            if (GokyuzuBır.transform.position.x <= -uzunluk)
            {
                GokyuzuBır.transform.position += new Vector3(uzunluk * 2.3f, 0);
            }
            if (GokyuzuIkı.transform.position.x <= -uzunluk)
            {
                GokyuzuIkı.transform.position += new Vector3(uzunluk * 2.3f, 0);
            }
            //////////////////////////////////////////////////////////////////////////

            degısımZamanı += Time.deltaTime;
            if (degısımZamanı > 1.5f)
            {
                degısımZamanı = 0;
                float Yeksenim = Random.Range(-6.40f, -4.5f);
                engeller[sayac].transform.position = new Vector3(17, Yeksenim);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }
            }

        }
    }
    public void oyunbitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizik1.velocity = Vector2.zero;
            fizik2.velocity = Vector2.zero;
        }
        oyunBitti = false;

    }
}
