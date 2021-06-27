using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Level_1 : MonoBehaviour
{
    //Variabel
    Rigidbody2D rb;                 //Variabel rigidbody
    public float moveSpeed;         //Variabel kecepatan gerak player
    public float rotateAmount;      //Variabel jumlah berputar
    float rot;                      //Variabel nilai berputar
    int score;                      //Variabel nilai = objek yang berhasil diambil
    public GameObject Panel;        //Variabel gameobject untuk panel/complete menu
    public AudioSource Hit;

    //Dijalankan ketika awal mulai
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   //player menjadi rigidbody
    }

    // Start is called before the first frame update
    void Start()
    {
        Hit = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))    //jika layar tersentuh
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     //posisi kanan kiri untuk input

            if(mousePos.x < 0)      //jika posisi sentuh layar dikiri
            {
                rot = rotateAmount;
            }
            else                    //jika posisi sentuh layar dikanan
            {
                rot = -rotateAmount;
            }

            transform.Rotate(0, 0, rot);    //koordinat gerak player. x, y, rot = nilai sentuhan player
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;     //untuk terus bergerak maju
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Junkfood")      //jika player menabrak objek junkfood
        {
            Hit.Play();
            Destroy(collision.gameObject);      //junkfood hilang
            score++;                            //skor bertambah

            if(score >= 4)      //jika skor sama dengan 4
            {
                Debug.Log("Level Complete!!");
                Time.timeScale = 0f;
                AudioListener.volume = 0f;
                Panel.SetActive(true);      //complete menu tampil
            }
        }
        else if(collision.gameObject.tag == "Vegetable")    //jika player menabrak objek vegetable
        {
            SceneManager.LoadScene("Level_1");      //mengulang level kembali
            Time.timeScale = 1f;
            AudioListener.volume = 1f;
        }
    }
}
