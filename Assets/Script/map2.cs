using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map2 : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            sceneController.GameOver();
        }
    }
}
