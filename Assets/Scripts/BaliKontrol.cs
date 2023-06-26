using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaliKontrol : MonoBehaviour
{
    public Sprite[] balikSprite;
    public Sprite[] balikAirSprite;

    SpriteRenderer spriterndr;
    bool hrktKontrol = true;
    int blkSayac;
    float balikHiz;
    Rigidbody2D fizik;
    bool oyunBitti = true;
    oyunKontrol oyunKontroll;
    Blok blokcs;
    public Text puanText;
    public Text oyunBittitext;
    public Image yonerge;
    int puan = 0;
    AudioSource []sesler;
    bool havadanDusme = true;
    bool ucurtmaKntrl = true;
    bool sprtKontrol = true;
    bool yonergeKntrl = true;
    int highScore = 0;
    int rstgleSayi2;
    
    ParticleSystem baloncuk;
    ParticleSystem suSicrama;

    void Start()
    {
        sesler = GetComponents<AudioSource>();
        oyunKontroll = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<oyunKontrol>();
        spriterndr = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        baloncuk = GameObject.Find("Baloncuk").GetComponent<ParticleSystem>();
        suSicrama = GameObject.Find("SuSicrama").GetComponent<ParticleSystem>();
        highScore = PlayerPrefs.GetInt("kayit");
        int rstgleSayi = Random.Range(10, 20);
        rstgleSayi2 = rstgleSayi;
        yonergeKntrl = true;
        yonerge.enabled = false;
    }
    
    void Update()
    {
        if (highScore>rstgleSayi2+5)
        {
            yonergeKntrl = false;
        }
        yuzme();
        Hrkt();
        elliskorfonk();
        StartCoroutine(yonergeFonk());
    }

    public void Hrkt()
    {
        if (sprtKontrol)
        {
            balikHiz += Time.deltaTime;

        if (balikHiz>0.08)
        {
            balikHiz = 0;
        if (hrktKontrol)
        {
            spriterndr.sprite = balikSprite[blkSayac];
            blkSayac++;
            if (blkSayac==balikSprite.Length)
            {
                hrktKontrol = false;
            }
        }
        else
        {
            blkSayac--;
            spriterndr.sprite = balikSprite[blkSayac];
            if (blkSayac==0)
            {
                hrktKontrol = true;
            }
        }
        }

        }
      
    }

    public void Hrkt2()
    {
        balikHiz += Time.deltaTime;

        if (balikHiz>0.08)
        {
            balikHiz = 0;
            if (hrktKontrol)
            {
                spriterndr.sprite = balikAirSprite[blkSayac];
                blkSayac++;
                if (blkSayac==balikAirSprite.Length)
                {
                    hrktKontrol = false;
                }
            }
            else
            {
                blkSayac--;
                spriterndr.sprite = balikAirSprite[blkSayac];
                if (blkSayac==0)
                {
                    hrktKontrol = true;
                }
            }
        }
    } 

    public void yuzme()
    {
        if (Input.GetMouseButtonDown(0) && oyunBitti && havadanDusme)
        {  
            fizik.velocity = new Vector2(0,0);
            fizik.AddForce(new Vector2(0,175));
            sesler[0].Play();
            baloncuk.Play();    
        }
        if (fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 20);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="puan")
        { 
            puan++;
            puanText.text = puan + "";
            sesler[1].Play();
            
        }
        if (col.gameObject.tag=="engel")
        {
            oyunBitti = false;
            sesler[2].Play();
            oyunBittitext.text = "game over!";
            oyunKontroll.oyunBitti();
            GetComponent<BoxCollider2D>().enabled = false;

            if (puan>highScore)
            {
                highScore = puan;
                PlayerPrefs.SetInt("kayit",highScore);
            }
            Invoke("anaMenuDns", 2);
        }
        if (col.gameObject.tag=="suSicrama")
        {
            suSicrama.Play();
            sesler[3].Play();
            havadanDusme = true;
            ucurtmaKntrl = true;
            fizik.gravityScale = 0.5f;
            sprtKontrol = true;
        }
        if (col.gameObject.tag=="ucurtma" && ucurtmaKntrl)
        {
            fizik.AddForce(new Vector2(0, 400));
            fizik.gravityScale = 0.8f;
            ucurtmaKntrl = false;
        }
    }

    void anaMenuDns()
    {
        PlayerPrefs.SetInt("puankayit", puan);
        SceneManager.LoadScene("AnaMenu");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="havadaUcma")
        {
            sprtKontrol = false;
            Hrkt2();
            havadanDusme = false;
        }
    }


    void elliskorfonk()
    {
        if (puan==rstgleSayi2)
        {
            oyunKontroll.elliskorFonk();
            StartCoroutine(oyunKontroll.bekletme());
            
        }
    }

    IEnumerator yonergeFonk()
    {
        if (puan==rstgleSayi2+2)
        {
            if (yonergeKntrl)
            {
                yonerge.enabled = true;
                yield return new WaitForSeconds(5f);
                yonerge.enabled = false;
            }
        }
    }
}
