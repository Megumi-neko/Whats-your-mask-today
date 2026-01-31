using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class teacher : MonoBehaviour
{
    bool round = false;
    public bool isU;
    Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Rotate()
    {
        if (round && isU)
        {
            animator.Play("teacherU2");
        }
        else if (isU)
        {
            animator.Play("teacherU1");
        }
        else if (round)
        {
            animator.Play("teacherL2");
        }
        else
        {
            animator.Play("teacherL1");
        }
    }
}
