using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emeny : MonoBehaviour
{
    [SerializeField] private float confusion = 0f;
    [SerializeField] private float maxConfusion = 100f;
    [SerializeField] private float upConfusionSecond = 10f;
    [SerializeField] private bool isAttack;
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<GameObject> targetList;
    [SerializeField] private bool moveState = true;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private int targetIndex;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = targetList[0].transform.position;
        targetIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && isAttack)
        {
            if (isAttack)
            {
                confusion += upConfusionSecond * Time.deltaTime;
                if (confusion >= maxConfusion)
                {
                    Player.Instance.Gameover();
                }
            }
        }
    }
    public void Move()
    {
        if(this.transform.position==targetList[targetIndex].transform.position)
        {
            if (moveState)
            {
                targetIndex++;
            }
            else
            {
                targetIndex--;
            }
        }
        moveDirection=(targetList[targetIndex].transform.position - this.transform.position).normalized;
        this.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
