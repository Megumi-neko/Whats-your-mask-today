using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Player player;
    [SerializeField] float cameraMoveSpeed;
    [SerializeField] float viewingTime = 2f;
    [SerializeField] float curField;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        if(viewingTime>0)
        viewingTime -= Time.deltaTime;
        follow();
    }

    private void follow()
    {
        if (viewingTime > 0) return;
        if (camera.fieldOfView>50)
        camera.fieldOfView -= (curField-60)/3*Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, cameraMoveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
