using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : MonoBehaviour
{
    [SerializeField] GameObject panel;
    void Start()
    {
       panel.SetActive(false);
       Invoke(nameof(Begin), 6f);
    }

    
    void Update()
    {
        
    }

    public void Close()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    public void Begin()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }
}
