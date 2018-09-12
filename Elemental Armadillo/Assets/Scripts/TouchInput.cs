using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour
{
    public AudioClip fireSwitch, waterSwitch, earthSwitch, airSwitch;
    public float volume;

    private bool isTransformed;
    private int touchID;
    private Elements playerElements;

    private AudioSource source;

    void Awake()
    {
        playerElements = GetComponent<Elements>();

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        TouchControls();
    }

    void TouchControls()
    {
        foreach (Touch touch in Input.touches)
        {

            if (touch.phase == TouchPhase.Ended && touch.fingerId == touchID)
            {
                //playerElements.fire = false;
                //playerElements.water = false;
                //playerElements.earth = false;
                //playerElements.air = false;
                playerElements.UpdateActiveElement("");

                isTransformed = false;
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

                if (hit)
                {
                    if (hit.collider.gameObject.tag == "Button")
                    {

                        print("button touching");
                        //touchID = touch.fingerId;

                        if (touch.fingerId >= touchID)
                        {
                            if (hit.collider.gameObject.name == "Fire" && touch.phase == TouchPhase.Stationary)
                            {
                                playerElements.UpdateActiveElement("Fire");
                                //playerElements.fire = true;

                                if (!isTransformed)
                                {
                                    source.PlayOneShot(fireSwitch, volume);
                                }

                                print("fire button touching");
                            }
                            else if (hit.collider.gameObject.name == "Water" && touch.phase == TouchPhase.Stationary)
                            {
                                playerElements.UpdateActiveElement("Water");
                                //playerElements.water = true;

                                if (!isTransformed)
                                {
                                    source.PlayOneShot(waterSwitch, volume);
                                }

                                print("water button touching");
                            }
                            else if (hit.collider.gameObject.name == "Earth" && touch.phase == TouchPhase.Stationary)
                            {
                                playerElements.UpdateActiveElement("Earth");
                                //playerElements.earth = true;

                                if (!isTransformed)
                                {
                                    source.PlayOneShot(earthSwitch, volume);
                                }

                                print("earth button touching");
                            }
                            else if (hit.collider.gameObject.name == "Air" && touch.phase == TouchPhase.Stationary)
                            {
                                playerElements.UpdateActiveElement("Air");
                                //playerElements.air = true;

                                if (!isTransformed)
                                {
                                    source.PlayOneShot(airSwitch, volume);
                                }

                                print("air button touching");
                            }

                            isTransformed = true;
                        }

                        touchID = touch.fingerId;
                    }
                }
            }
        }
    }
}
