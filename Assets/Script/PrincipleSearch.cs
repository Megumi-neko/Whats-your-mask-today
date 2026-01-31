using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipleSearch : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Animator panimator;
    [SerializeField] Player player;
    [SerializeField] Teacher teacher;
    bool round = false;
    bool pround = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("teacher"))
        {
            teacher = collision.GetComponent<Teacher>();
            teacher.Rotate();          
        }
        if(collision.gameObject.CompareTag("player"))
        {            
            if(player.Mask == PlayerMask.Teacher)
            {
                panimator = collision.GetComponent<Animator>();
                player = collision.GetComponent<Player>();
                if (pround)
                {
                    panimator.Play("teacherL2");
                    pround = false;
                }
                else
                {
                    panimator.Play("teacherL1");
                    pround = true;
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (player.Mask == PlayerMask.Teacher)
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
