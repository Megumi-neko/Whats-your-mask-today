using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] Camera mainCamera;
    public float volumn;
    // Start is called before the first frame update
    void Start()
    {
        volumn = 1f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CilpPlay(int count)
    {
        AudioClip clip = audioClips[count];
        AudioSource.PlayClipAtPoint(clip,mainCamera.transform.position, audioSource.volume);
    }
    public void BgmPlay()
    {
        audioSource.Play();
    }
}
