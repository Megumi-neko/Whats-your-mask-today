using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer1 : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField] Player player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (player.Mask == PlayerMask.Son)
            {
                animator.speed = 1;
                return;
            }
            animator.speed = 0;
            player.confusion += 5 * Time.deltaTime;
            Debug.Log("found");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            animator.speed = 1;
        }
    }
}
