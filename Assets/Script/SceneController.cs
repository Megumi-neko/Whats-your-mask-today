using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject gameObject;
    [SerializeField] AudioManager audioManager;
    private void Start()
    {
        if(gameObject == null)  return;
        Invoke(nameof(Begin), 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            gameObject.SetActive(true);
            animator.Play("Switch");
            Invoke (nameof(LoadNextScene), 1f);
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Begin()
    {
        gameObject.SetActive(false);
    }
    public void GameOver()
    {
        gameObject.SetActive(true);
        animator.Play("Switch");
        Invoke(nameof(Reload), 1f);
    }
    public void Thanks()
    {
        SceneManager.LoadScene(4);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}
