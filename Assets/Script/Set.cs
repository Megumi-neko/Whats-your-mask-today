using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    [SerializeField]private Esc menu;
    [SerializeField] AudioManager audioManager;
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
        menu.ChangePaused();
        audioManager.CilpPlay(0);
    }
}
