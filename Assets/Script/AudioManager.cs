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
    void Awake()
    {
        Object.DontDestroyOnLoad(this);
    }
    void Start()
    {
        volumn = 1f;
        audioSource = GetComponent<AudioSource>();
        BgmPlay();
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public void CilpPlay(int count)
    {
        AudioClip clip = audioClips[count];
        AudioSource.PlayClipAtPoint(clip,mainCamera.transform.position, audioSource.volume*2);
    }
    public void BgmPlay()
    {
        audioSource.Play();
    }
}
