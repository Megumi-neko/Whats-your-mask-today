using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Emeny : MonoBehaviour
{

    [SerializeField] protected bool isAttack;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float maxSpeed=5f;
    [SerializeField] protected List<GameObject> targetList;
    [SerializeField] protected bool moveState;
    [SerializeField] protected Vector2 moveDirection;
    [SerializeField] protected int targetIndex;

    [SerializeField]protected int rotateIndex;
    [SerializeField] protected List<float> rotateAngleList;
    [SerializeField] protected float rotateSpeed;
    [SerializeField] protected bool isRotate;
    [SerializeField]protected bool isArrive;
    public float re;
    [SerializeField]protected float time;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = targetList[0].transform.position;
        targetIndex = 1;
        rotateIndex = 1;
        isAttack=false;
        moveState = true;
        isRotate = false;
        isArrive = false;
        moveSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttack)
        {
            Isarrive();
            Isrotate();
            Ismove();
            RotateWhenStay();
            Move();
        }
  
    }

    public void Move()
    {
        moveDirection = transform.InverseTransformDirection((targetList[targetIndex].transform.position - this.transform.position).normalized);
        //moveDirection=(targetList[ttargetIndex].transform.position - this.transform.position).normalized;
        this.transform.Translate(moveDirection * moveSpeed * Time.deltaTime,Space.Self);
    }
    public void RotateWhenStay()
    {

        if (isRotate)
        {
            moveSpeed = 0;
            this.transform.Rotate(0, 0, rotateSpeed*Time.deltaTime,Space.Self);
            time+= Time.deltaTime;
        }
    }
    //public void Changestate()
    //{
    //    re= Vector2.Distance(this.transform.position, targetList[targetIndex].transform.position);
    //    if (Vector2.Distance(this.transform.position, targetList[targetIndex].transform.position) < 0.3f)
    //    {
    //        isArrive = true;
    //        isRotate = true;
    //    }
    //    else isArrive = false;
    //    float rotateTime =Math.Abs(rotateAngleList[rotateIndex] / rotateSpeed);
    //    if (time >= rotateTime)
    //    {
    //        moveSpeed = maxSpeed;
    //        time = 0;
    //        isRotate = false;
    //        rotateIndex++;
    //        if(rotateIndex>rotateAngleList.Count-1)
    //        {
    //            rotateIndex =0;
    //        }
    //    }
    //    if (isArrive&&!isRotate)
    //    {
    //        if (moveState)
    //        {
    //            targetIndex++;
    //            if(targetIndex>=targetList.Count)
    //            {
    //                targetIndex = targetList.Count-2;
    //                moveState= false;
    //            }
    //        }
    //        else
    //        {
    //            targetIndex--;
    //            if(targetIndex < 0)
    //            {
    //                targetIndex =1;
    //                moveState = true;
    //            }   
    //        }
    //    }
    //}
    public virtual void Isarrive()
    {
        re = Vector2.Distance(this.transform.position, targetList[targetIndex].transform.position);
        if (Vector2.Distance(this.transform.position, targetList[targetIndex].transform.position) < 0.3f)
        {
            isArrive = true;
            isRotate = true;
        }
        else isArrive = false;
    }
    public void Isrotate()
    {
        float rotateTime = Math.Abs(rotateAngleList[rotateIndex] / rotateSpeed);
        if (time >= rotateTime)
        {
            moveSpeed = maxSpeed;
            time = 0;
            isRotate = false;
            rotateIndex++;
            if (rotateIndex > rotateAngleList.Count - 1)
            {
                rotateIndex = 0;
            }
        }
    }
    public virtual void Ismove()
    {
        if (isArrive && !isRotate)
        {
            if (moveState)
            {
                targetIndex++;
                if (targetIndex >= targetList.Count)
                {
                    targetIndex = targetList.Count - 2;
                    moveState = false;
                }
            }
            else
            {
                targetIndex--;
                if (targetIndex < 0)
                {
                    targetIndex = 1;
                    moveState = true;
                }
            }
        }
    }
}
