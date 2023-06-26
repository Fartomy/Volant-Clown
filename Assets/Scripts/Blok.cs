using UnityEngine;

public class Blok : MonoBehaviour
{
    SpriteRenderer blokSprt;
    void Start()
    {
        blokSprt = GetComponent<SpriteRenderer>();
        blokSprt.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="balik")
        {
            blokSprt.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
