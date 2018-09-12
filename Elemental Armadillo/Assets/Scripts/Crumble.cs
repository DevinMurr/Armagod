using UnityEngine;
using System.Collections;

public class Crumble : MonoBehaviour
{
    public Animator animator;
    public float delayTime;

    private Elements playerElements;
    private GameObject targetPlayer;

    void Awake()
    {
        if (targetPlayer == null)
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            return;
        }

        if (playerElements == null)
        {
            playerElements = targetPlayer.GetComponent<Elements>();
        }
        else
        {
            return;
        }
    }

    void DeleteWall()
    {
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && playerElements.earth == true)
        {
            animator.SetBool("crumbleTime", true);
            Invoke("DeleteWall", delayTime);
        }
    }
}
