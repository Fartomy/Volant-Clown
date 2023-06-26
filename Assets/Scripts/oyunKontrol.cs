using System.Collections;
using UnityEngine;

public class oyunKontrol : MonoBehaviour
{
    public static bool gamePause = false;
    public GameObject pauseMenuUI;


    public GameObject gokyuzu1;
    public GameObject gokyuzu2;
    public GameObject gokyuzu3;
    public GameObject gokyuzu4;

    //-------------------------//

    GameObject gkyzu1child;
    GameObject gkyzu2child;
    GameObject gkyzu3child;
    GameObject gkyzu4child;

    public GameObject engel;
    GameObject[] engeller;

    public GameObject kayaEngel;
    GameObject[] kayaEngeller;

    AudioSource arkPlnMzk;
    
    Rigidbody2D fizik1;
    Rigidbody2D fizik2;
    Rigidbody2D fizik3;
    Rigidbody2D fizik4;

    public int engelKayaAdet;
    public int engelAdet;
    public float hiz;
    float uzunluk = 0;
    float degisimZaman = 0;
    int sayac = 0;
    int kayaSayac = 0;
    bool elliPuanKntrl = true;
    bool kayaKntrl = true;
    int rastKy;
    float ksrliSayi = 1.5f;

    void Start()
    {
        arkPlnMzk = GetComponent<AudioSource>();

        gkyzu1child = new GameObject();
        gkyzu1child.AddComponent<BoxCollider2D>();
        gkyzu1child.gameObject.tag = "suSicrama";

        gkyzu2child = new GameObject();
        gkyzu2child.AddComponent<BoxCollider2D>();
        gkyzu2child.gameObject.tag = "suSicrama";

        gkyzu3child = new GameObject();
        gkyzu3child.AddComponent<BoxCollider2D>();
        gkyzu3child.gameObject.tag = "suSicrama";

        gkyzu4child = new GameObject();
        gkyzu4child.AddComponent<BoxCollider2D>();
        gkyzu4child.gameObject.tag = "suSicrama";

        fizik1 = gokyuzu1.GetComponent<Rigidbody2D>();
        fizik2 = gokyuzu2.GetComponent<Rigidbody2D>();
        fizik3 = gokyuzu3.GetComponent<Rigidbody2D>();
        fizik4 = gokyuzu4.GetComponent<Rigidbody2D>();

        

        uzunluk = gokyuzu1.GetComponent<BoxCollider2D>().size.x;

        fizik1.velocity = new Vector2(hiz, 0);
        fizik2.velocity = new Vector2(hiz, 0);
        fizik3.velocity = new Vector2(hiz, 0);
        fizik4.velocity = new Vector2(hiz, 0);

        engeller = new GameObject[engelAdet];

        kayaEngeller = new GameObject[engelKayaAdet];


        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(hiz, 0);
        }

        for (int i = 0; i < kayaEngeller.Length; i++)
        {
            kayaEngeller[i] = Instantiate(kayaEngel, new Vector2(-25, -25), Quaternion.identity);
            Rigidbody2D fizikKayaEngel = kayaEngeller[i].AddComponent<Rigidbody2D>();
            fizikKayaEngel.gravityScale = 0;
            fizikKayaEngel.velocity = new Vector2(hiz, 0);
        }

        kayaKntrl = false;

        int rastgeleKayaS = Random.Range(4, 7);
        rastKy = rastgeleKayaS;
        
    }

    
    void Update()
    {

        if (gokyuzu1.transform.position.x<=-uzunluk)
        {
            gokyuzu1.transform.position+= new Vector3(uzunluk*1.5f,0);
        }
        if (gokyuzu2.transform.position.x <= -uzunluk)
        {
            gokyuzu2.transform.position += new Vector3(uzunluk*1.5f, 0);
        }
        if (gokyuzu3.transform.position.x <= -uzunluk)
        {
            gokyuzu3.transform.position += new Vector3(uzunluk *1.5f, 0);
        }
        if (gokyuzu4.transform.position.x <= -uzunluk)
        {
            gokyuzu4.transform.position += new Vector3(uzunluk * 1.5f, 0);
        }


        //----------------------------------------------------------------------

        engellerFonk();
        
    }

   public void oyunBitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        for (int i = 0; i < kayaEngeller.Length; i++)
        {
            kayaEngeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        arkPlnMzk.Stop();
        fizik1.velocity = Vector2.zero;
        fizik2.velocity = Vector2.zero;
        fizik3.velocity = Vector2.zero;
        fizik4.velocity = Vector2.zero;

    }

   public void elliskorFonk()
    {

        elliPuanKntrl = false;
        kayaKntrl = true;
        ksrliSayi = 2f;

        gokyuzu1.transform.GetChild(3).GetComponent<BoxCollider2D>().offset = new Vector2(5.76f,12.28f);
        gokyuzu2.transform.GetChild(3).GetComponent<BoxCollider2D>().offset = new Vector2(5.76f, 12.28f);
        gokyuzu3.transform.GetChild(3).GetComponent<BoxCollider2D>().offset = new Vector2(5.76f, 12.28f);
        gokyuzu4.transform.GetChild(3).GetComponent<BoxCollider2D>().offset = new Vector2(5.76f, 12.28f);    

        //----------------------------------------------------------------------------------------------//

        gkyzu1child.transform.parent = gokyuzu1.transform;
        gkyzu1child.transform.localPosition = new Vector3(0, 0, 0);
        gkyzu1child.transform.localScale = new Vector3(1, 1, 1);
        gkyzu1child.GetComponent<BoxCollider2D>().isTrigger = enabled;
        gkyzu1child.GetComponent<BoxCollider2D>().offset = new Vector2(5.76f, 3.58f);
        gkyzu1child.GetComponent<BoxCollider2D>().size = new Vector2(23.04f, 0.01f);

        //----------------------------------------------------------------------------------------------//

        gkyzu2child.transform.parent = gokyuzu2.transform;
        gkyzu2child.transform.localPosition = new Vector3(0, 0, 0);
        gkyzu2child.transform.localScale = new Vector3(1, 1, 1);
        gkyzu2child.GetComponent<BoxCollider2D>().isTrigger = enabled;
        gkyzu2child.GetComponent<BoxCollider2D>().offset = new Vector2(5.76f, 3.58f);
        gkyzu2child.GetComponent<BoxCollider2D>().size = new Vector2(23.04f, 0.01f);

        //----------------------------------------------------------------------------------------------//

        gkyzu3child.transform.parent = gokyuzu3.transform;
        gkyzu3child.transform.localPosition = new Vector3(0, 0, 0);
        gkyzu3child.transform.localScale = new Vector3(1, 1, 1);
        gkyzu3child.GetComponent<BoxCollider2D>().isTrigger = enabled;
        gkyzu3child.GetComponent<BoxCollider2D>().offset = new Vector2(5.76f, 3.58f);
        gkyzu3child.GetComponent<BoxCollider2D>().size = new Vector2(23.04f, 0.01f);

        //----------------------------------------------------------------------------------------------//

        gkyzu4child.transform.parent = gokyuzu4.transform;
        gkyzu4child.transform.localPosition = new Vector3(0, 0, 0);
        gkyzu4child.transform.localScale = new Vector3(1, 1, 1);
        gkyzu4child.GetComponent<BoxCollider2D>().isTrigger = enabled;
        gkyzu4child.GetComponent<BoxCollider2D>().offset = new Vector2(5.76f, 3.58f);
        gkyzu4child.GetComponent<BoxCollider2D>().size = new Vector2(23.04f, 0.01f);

        

    }


   public void engellerFonk()
    {
        if (elliPuanKntrl)
        {
            degisimZaman += Time.deltaTime;
            if (degisimZaman > ksrliSayi)
            {
                degisimZaman = 0;
                float Yeksen = Random.Range(-3.09f, -5.48f);
                engeller[sayac].transform.position = new Vector3(3f, Yeksen);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                    
                }
                if (kayaKntrl)
                {
                    if (sayac == rastKy)
                    {
                        engeller[rastKy-1].gameObject.SetActive(false);
                        kayaEngeller[kayaSayac].transform.position = new Vector3(3f, -2.36f);
                    }
                }
            }
        }      
    }


    public IEnumerator bekletme()
    {
        yield return new WaitForSeconds(7f);
        elliPuanKntrl = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
        arkPlnMzk.UnPause();
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
        arkPlnMzk.Pause();
    }
}
