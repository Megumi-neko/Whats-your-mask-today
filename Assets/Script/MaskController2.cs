using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskController2 : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image image1 = null;
    [SerializeField] Image image2 = null;

    void Update()
    {
        MaskCheck();
    }

    private void MaskCheck()
    {
        if (player.Mask == PlayerMask.Me)
        {
            image1.color = Color.gray;
            image2.color = Color.gray;
        }
        else if (player.Mask == PlayerMask.Teacher||player.Mask == PlayerMask.PasserbyR)
        {
            image1.color = Color.gray;
            image2.color = Color.white;
        }
        else
        {
            image1.color = Color.white;
            image2.color = Color.gray;
        }

    }
}
