using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum PlayerMask
{
    Me,
    Son,
    Passerby,
    Student,
    Teacher,
}
public class Player : MonoBehaviour
{
    [SerializeField]float movex, movey;
    [SerializeField]private float moveSpeed;
    [SerializeField]private PlayerMask mask;
    // Start is called before the first frame update
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        moveSpeed = 5f;
    }
    public void Update()
    {
        Move();
    }
    public void Move()
    {
        if(mask!=PlayerMask.Son)
        movex = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movey = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(movex, movey, 0);
    }
    public void Gameover()
    {
        SceneManager.LoadScene(5);
    }
}
