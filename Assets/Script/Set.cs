using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    [SerializeField]private Esc menu;
    [SerializeField] AudioManager audioManager;
    void Awake()
    {
        audioManager =GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetActiveObj()
    {
        audioManager.CilpPlay(0);
        menu.ChangePaused();
        audioManager.CilpPlay(0);
    }
}
