using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
    public float speed = 100f;
    public float normalSpeed = 100f;
    public float slowSpeed = 50f;
    public float fastSpeed = 1000f;
    public float sensitivity = 10f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            rotationRightMouseBotton();
        }
        else if(Input.GetMouseButton(2))
        {
            movementMiddleMouseButton();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        movementKey();
        rotationKey();
    }

    
    private void movementMiddleMouseButton()
    {
        
        Vector3 movement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        
        transform.Translate(-movement * speed * Time.deltaTime);
    }
    private void movementKey()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = fastSpeed;
        }else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = slowSpeed;
        }else { 
            speed = normalSpeed; 
        }
        
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0f)
        {
            movement += new Vector3(0,0, 30);
        }
        else if (scrollInput < 0f)
        {
            movement -= new Vector3(0, 0, 30);
        }
        transform.Translate(movement * speed * Time.deltaTime);
    }
    private void rotationKey()
    {
        float rotation = UnityEngine.Input.GetAxis("Rotate");
        transform.Rotate(Vector3.forward, -rotation * Time.deltaTime * 50);
    }
    private void rotationRightMouseBotton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        transform.Rotate(-mouseMovement * sensitivity * Time.deltaTime * 50);
        //   Vector3 eulerRotation = transform.rotation.eulerAngles;
        //    transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }
}

