using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
    public float speed = 10f;
    public float sensitivity = 10f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            transform.Rotate(-mouseMovement* sensitivity * Time.deltaTime * 50);
            //Vector3 eulerRotation = transform.rotation.eulerAngles;
            //transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
            Movement();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


    private void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);
    }
    }

