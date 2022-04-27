using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    float offsetX = 0.0f;
    float offsetY = 16.0f;
    float offsetZ = -6.0f;

    float scrollSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(offsetX, offsetY, offsetZ);

        float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        if (scroll != 0)
        {
            Camera.main.fieldOfView -= scroll;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 30, 60);
        }
    }
}
