using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class President :Emeny
{
    [SerializeField]private float stayTime;
    [SerializeField] private bool isStay;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = targetList[0].transform.position;
        targetIndex = 1;
        isAttack = false;
        isArrive = false;
        isStay= false;
        moveSpeed =maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Isarrive();
        IsStay();
        Ismove();
        Stay();
        Move();
    }
    public override void Ismove()
    {
        if (isArrive&&time>=stayTime)
        {
            moveSpeed = maxSpeed;
            targetIndex++;
            if (targetIndex >= targetList.Count)
            {
                targetIndex =0;
            }
        }
    }
    public void Stay()
    {
        if (isStay)
        {
            moveSpeed = 0;
            time += Time.deltaTime;
        }
    }
    public override void Isarrive()
    {
        re = Vector2.Distance(this.transform.position, targetList[targetIndex].transform.position);
        if (Vector2.Distance(this.transform.position, targetList[targetIndex].transform.position) < 0.3f)
        {
            isArrive = true;
            isStay = true;
        }
        else isArrive = false;
    }
    public void IsStay()
    {
        if (time >= stayTime)
        {
            time = 0;
            isStay = false;
        }
    }
}
