using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teacher : MonoBehaviour
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
        //Debug.Log("触发了方法");
        if (round && isU)
        {
            animator.Play("teacherU2");
            round = false;
        }
        else if (isU)
        {
            animator.Play("teacherU1");
            round = true;
        }
        else if (round)
        {
            animator.Play("teacherL2");
            round = false;
        }
        else
        {
            animator.Play("teacherL1");
            round = true;
        }
    }
}
