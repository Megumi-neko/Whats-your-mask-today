using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PlayerMask
{
    Me,
    Son,
    PasserbyL,
    PasserbyR,
    Student,
    Teacher,
}
public class Player : MonoBehaviour
{
    [SerializeField]float movex, movey;
    [SerializeField]private float moveSpeed;
    [SerializeField]private PlayerMask mask;
    [SerializeField]private SpriteRenderer spriteRenderer;
    private Color oricolor;
    public  float confusion;
    public float maxConfusion;
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
        oricolor = spriteRenderer.color;
    }
    public void Update()
    {
        Move();
        SetMask();
        NPCbehaviour();
    }
    public void Move()
    {
        if (mask != PlayerMask.Me) return;
        movex = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movey = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(movex, movey, 0);
    }

    public void NPCbehaviour()
    {
        if(mask == PlayerMask.Me) return;
        else if(mask == PlayerMask.PasserbyL)
        {
            movey = -4f;
            transform.Translate(0, movey, 0);
        }
        else if(mask == PlayerMask.PasserbyR)
        {
            movey = 4f;
            transform.Translate(0, movey, 0);
        }
        else if(mask == PlayerMask.Teacher)
        {

        }
    }

    public void SetMask()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            mask = PlayerMask.Me;
            spriteRenderer.color = oricolor;
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            spriteRenderer.color = Color.white;
            if (this.gameObject.scene == SceneManager.GetSceneByBuildIndex(1))
            {
                mask = PlayerMask.Son;
            }
            else if (this.gameObject.scene == SceneManager.GetSceneByBuildIndex(2))
            {
                mask = PlayerMask.PasserbyL;
            }
            else if (this.gameObject.scene == SceneManager.GetSceneByBuildIndex(3))
            {
                mask = PlayerMask.Student;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(this.gameObject.scene == SceneManager.GetSceneByBuildIndex(2))
            {
                mask = PlayerMask.PasserbyR;
                spriteRenderer.color = Color.blue;
            }
            else if (this.gameObject.scene == SceneManager.GetSceneByBuildIndex(3))
            {
                mask = PlayerMask.Teacher;
                spriteRenderer.color = Color.blue;
            }
        }
    }
    public PlayerMask Mask
    {
        get { return mask; }
    }
}
