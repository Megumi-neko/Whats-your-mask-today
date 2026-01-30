using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Emeny : MonoBehaviour
{
    [SerializeField] private float confusion;
    [SerializeField] private float maxConfusion;
    [SerializeField] private float upConfusionSecond;
    [SerializeField] private bool isAttack;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private List<GameObject> targetList;
    [SerializeField] private bool moveState;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private int targetIndex;
    [SerializeField]private int rotateIndex;
    [SerializeField] private List<float> rotateAngleList;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private bool isRotate;
    [SerializeField]private bool isArrive;
    public float re;
    private float time;
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
            Changestate();
           RotateWhenStay();
            Move();
        }
  
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player"&&isAttack
            && Vector2.Angle(collision.transform.position - this.transform.position, moveDirection) < 45f)
        {
            confusion += upConfusionSecond * Time.deltaTime;
        }
        //if(confusion>=maxConfusion)
        //{
        //    collision.gameObject.GetComponent<Player>().Gameover();
        //}
    }
    public void Move()
    {
        moveDirection = new Vector2(Math.Abs((targetList[targetIndex].transform.position - this.transform.position).normalized.x),
            -Math.Abs((targetList[targetIndex].transform.position - this.transform.position).normalized.y));
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
    public void Changestate()
    {
        re= Vector2.Distance(this.transform.position, targetList[targetIndex].transform.position);
        if (Vector2.Distance(this.transform.position, targetList[targetIndex].transform.position) < 0.3f)
        {
            isArrive = true;
            isRotate = true;
        }
        else isArrive = false;
        float rotateTime =Math.Abs(rotateAngleList[rotateIndex] / rotateSpeed);
        if (time >= rotateTime)
        {
            moveSpeed = maxSpeed;
            time = 0;
            isRotate = false;
            rotateIndex++;
            if(rotateIndex>rotateAngleList.Count-1)
            {
                rotateIndex =0;
            }
        }
        if (isArrive&&!isRotate)
        {
            if (moveState)
            {
                targetIndex++;
                if(targetIndex>=targetList.Count)
                {
                    targetIndex = targetList.Count-2;
                    moveState= false;
                }
            }
            else
            {
                targetIndex--;
                if(targetIndex < 0)
                {
                    targetIndex =1;
                    moveState = true;
                }   
            }
        }
    }
}
