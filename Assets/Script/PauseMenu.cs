using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject LearnUI;
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
    }

    public void ChangePaused()
    {
        if (!LearnUI.activeSelf)
        {
            if (isPaused == true)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = false;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = true;
            }
        }
    }
}