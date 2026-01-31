using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Complete : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] Player player;
    [SerializeField] GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            panel.SetActive(true);
            if(player.Mask == PlayerMask.Student)
            {
                sceneController.Thanks();
            }
        }
    }
}
