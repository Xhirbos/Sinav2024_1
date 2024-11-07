using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KarakterKontrol : MonoBehaviour
{
    // Ad Soyad: Ahmet Yılmaz   
    // Öğrenci Numarası: 232011035


    // Soru 1: Karakteri yön tuşları ile hareket ettiren kodu, HareketEt fonksiyonu içerisine yazınız.
    // Soru 2: Karakterin zıplamasını sağlaması beklenen Zipla metodu doğru bir şekilde çalışmıyor, koddaki hatayı düzeltin.
    // Soru 3: Karakterin 'Engel' tag'ine sahip objeye temas ettiğinde metin objesine "Oyun Bitti!" yazısını yazdırınız.
    // Soru 4: Karakterin 'Puan' tag'ine sahip objeye temas ettiğinde skoru 1 arttırınız ve metin objesine yazdırınız.

    // Not: Engel ve Puan nesnelerinin isTrigger özelliği aktiftir.


    public TMP_Text metin;
    private Rigidbody2D karakterRb;

    public float hiz = 5f;
    public float ziplamaGucu = 5f;

    public int skor = 0;

    void Start()
    {
        karakterRb = GetComponent<Rigidbody2D>();
    }

    void HareketEt()
    {
        if (Input.GetKey(KeyCode.A))
        {
            karakterRb.AddForce(Vector2.left * (hiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            karakterRb.AddForce(Vector2.right * (hiz * Time.deltaTime));
        }

    }
    void Zipla()
    {
        // Space tuşuna basınca karakter zıplamalı ancak aşağıdaki kod hatalı.
        if (Input.GetKeyDown(KeyCode.Space))
        {


            Vector3 ziplamaYonu = new Vector3(0, 1, 0);
            karakterRb.AddForce(ziplamaYonu * ziplamaGucu, ForceMode2D.Impulse);


        }
    }

    void Update()
    {
        HareketEt();
        Zipla();

        // Yazdığınız metodları çağırınız.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {



        // burası anahtarı aldığımızda anahtarı aldığımızı belirler
        if (collision.gameObject.CompareTag("Engel"))
        {


            Destroy(collision.gameObject);
            metin.text = "OYUN BİTTİ!";
        }
        if (collision.gameObject.CompareTag("Puan"))// burası score ve anahtar kodu
        {
            //burası scoremizi arttırmak için kulllanılır
            skor += 1;
            Destroy(collision.gameObject);
            metin.text = "score: " + skor;



        }



       
    }
}