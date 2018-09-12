using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public GameObject exitPortal;
    public float force;

    private bool activated;
    private GameObject target;
    private Elements myElement;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        myElement = target.GetComponent<Elements>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && activated == true && myElement.water == true)
        {
            other.gameObject.transform.position = new Vector2(exitPortal.transform.position.x, exitPortal.transform.position.y);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
        }
        else
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (myElement.water == true)
        {
            activated = !activated;
        }
    }
}
