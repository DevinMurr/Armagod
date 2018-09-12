using UnityEngine;
using System.Collections;

public class Elements : MonoBehaviour
{
    //public bool keyControls;

    public Color fireRed;
    public Color waterBlue;
    public Color earthBrown;
    public Color greyAir;
   
    public Sprite nakedSnake, fireSprite, waterSprite, earthSprite, airSprite;

    public GameObject fireParticle, airParticle, earthParticle, waterParticle;

    public Animator elementIconsAnim;

    [HideInInspector]
    public bool fire, earth, water, air;

    private SpriteRenderer spriteRenderer;  

    private ParticleSystem fireSystem;
    private ParticleSystem airSystem;
    private ParticleSystem waterSystem;
    private ParticleSystem earthSystem;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        fireSystem = fireParticle.GetComponent<ParticleSystem>();
        waterSystem = waterParticle.GetComponent<ParticleSystem>();
        airSystem = airParticle.GetComponent<ParticleSystem>();
        earthSystem = earthParticle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //KeyboardInput();
        ElementUI();
        ElementColour();
        ElementParticle();
    }

    //void KeyboardInput()
    //{
    //    if (keyControls)
    //    {
    //        if (Input.GetKey("q"))
    //        {
    //            fire = true;
    //        }
    //        else if (Input.GetKey("w"))
    //        {
    //            water = true;
    //        }
    //        else if (Input.GetKey("e"))
    //        {
    //            earth = true;
    //        }
    //        else if (Input.GetKey("r"))
    //        {
    //            air = true;
    //        }
    //        else
    //        {
    //            fire = false;
    //            water = false;
    //            earth = false;
    //            air = false;
    //        }
    //    }
    //}

    void ElementUI()
    {
        elementIconsAnim.SetBool("isFireActive", fire);
        elementIconsAnim.SetBool("isWaterActive", water);
        elementIconsAnim.SetBool("isAirActive", air);
        elementIconsAnim.SetBool("isEarthActive", earth);
    }

    void ElementColour()
    {
        if (fire == true)
        {
            spriteRenderer.sprite = fireSprite;
        }
        else if (water == true)
        {
            spriteRenderer.sprite = waterSprite;
        }
        else if (earth == true)
        {
            spriteRenderer.sprite = earthSprite;
        }
        else if (air == true)
        {
            spriteRenderer.sprite = airSprite;
        }
        else
        {
            spriteRenderer.sprite = nakedSnake;
        }
    }

    void ElementParticle()
    {
        if (fire)
        {
            fireSystem.Emit(1);
        }
        else if (water)
        {
            waterSystem.Emit(1);
        }
        else if (air)
        {
            airSystem.Emit(1);
        }
        else if (earth)
        {
            earthSystem.Emit(1);
        }
    }

    public void UpdateActiveElement(string elementToActivate)
    {
        ResetActiveElements();

        if (elementToActivate == "Fire")
        {
            fire = true;
        }
        else if (elementToActivate == "Water")
        {
            water = true;
        }
        else if (elementToActivate == "Air")
        {
            air = true;
        }
        else if (elementToActivate == "Earth")
        {
            earth = true;
        }
        else
        {
            return;
        }
    }

    void ResetActiveElements()
    {
        fire = false;
        water = false;
        air = false;
        earth = false;
    }

}
