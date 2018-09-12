using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float normalSpeed;
    public float speedBoost;

    public float setGravity;

    public AudioClip rolling, fireSound, waterSound, earthSound, airSound;
    public float volume;

    private bool fireTrigger, waterTrigger, earthTrigger, airTrigger;
    private bool isSubmerged;
    private Elements elements;

    private Vector3 acceleration;
    private float direction;

    private AudioSource source;

    private Rigidbody2D myBody;

    void Awake()
    {
        elements = GetComponent<Elements>();
        myBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        acceleration = Input.acceleration;
        direction = acceleration.x;
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float currentSpeed = normalSpeed;

        print(fireTrigger + " " + elements.fire);

        if (elements.fire == true && fireTrigger == true)
        {
            currentSpeed = speedBoost;
        }
        else
        {
            currentSpeed = normalSpeed;
        }

        if (elements.air == true && airTrigger == true)
        {
            myBody.gravityScale = -setGravity;
        }
        else
        {
            myBody.gravityScale = setGravity;
        }

        //using AddForce gives a more responsive feel
        //because of of mid air moveability, things can defy physics
        myBody.AddForce(new Vector2(direction * currentSpeed, 0f));

        if (acceleration.x > -0.1f && acceleration.x < 0.1f)
        {
            myBody.AddForce(new Vector2(-(direction * currentSpeed), 0f));
        }

        //using AddTorque is less responsive, but cannot move mid air
        //gets a lot of air off of curveed jumps
        //rigidbody2D.AddTorque (-direction * speed);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.tag == "Fire")
        {
            fireTrigger = true;
            if (!isSubmerged)
            {
                source.PlayOneShot(fireSound, volume);
            }
        }
        else if (other.gameObject.tag == "Water")
        {
            waterTrigger = true;

            if (!isSubmerged)
            {
                source.PlayOneShot(waterSound, volume);
            }

        }
        else if (other.gameObject.tag == "Earth")
        {
            earthTrigger = true;

            if (!isSubmerged)
            {
                source.PlayOneShot(earthSound, volume);
            }

            if (elements.earth == true)
            {
                other.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
        }
        else if (other.gameObject.tag == "Air")
        {
            airTrigger = true;

            if (!isSubmerged)
            {
                source.PlayOneShot(airSound, volume);
            }

        }

        if (other.gameObject.tag == "Fire" || other.gameObject.tag == "Water" || other.gameObject.tag == "Earth" || other.gameObject.tag == "Air")
        {
            isSubmerged = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            fireTrigger = false;
        }
        else if (other.gameObject.tag == "Water")
        {
            waterTrigger = false;
        }
        else if (other.gameObject.tag == "Earth")
        {
            earthTrigger = false;
        }
        else if (other.gameObject.tag == "Air")
        {
            airTrigger = false;
        }

        if (other.gameObject.tag == "Fire" || other.gameObject.tag == "Water" || other.gameObject.tag == "Earth" || other.gameObject.tag == "Air")
        {
            isSubmerged = false;
        }
    }
}