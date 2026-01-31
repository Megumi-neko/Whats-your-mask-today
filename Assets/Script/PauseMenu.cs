using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused = true;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePaused();
        }
            Pause();
    }
    public void Pause()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void ChangePaused()
    {
        if(isPaused==true)
        {
            isPaused = false;
        }
        else
        {
            isPaused =true;
        }
    }
}