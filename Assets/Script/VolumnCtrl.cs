using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumnCtrl : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider Slider;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();    
    }
    void Start()
    {
        Slider=GetComponent<Slider>();
        Slider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VolumnChange()
    {
        audioSource.volume = Slider.value/2;
    }
}
