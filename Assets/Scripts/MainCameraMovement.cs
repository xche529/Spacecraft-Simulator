using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCameraMovement : MonoBehaviour
{
    public float speed = 100f;
    public float normalSpeed = 100f;
    public float slowSpeed = 50f;
    public float fastSpeed = 1000f;
    public float sensitivity = 10f;
    public float followDistance = 10f;
    public GameObject targetGameObject;
    public Vector3 offset = Vector3.zero;
    public Vector3 viewCenterPosition = Vector3.zero;
    public Quaternion viewCenterRotation = new Quaternion();
    public Vector3 desiredPosition = Vector3.zero;

    void Update()
    {
        if (targetGameObject != null)
        {
            updateTargetValue();
            autoFollowing();
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                rotationRightMouseBotton();
            }
            else if (Input.GetMouseButton(2))
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
    }


    private void movementMiddleMouseButton()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        transform.Translate(-movement * speed * Time.deltaTime + offset);
    }
    private void movementKey()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = fastSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = slowSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0f)
        {
            movement += new Vector3(0, 0, 30);
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

    //Rotate method when no gameobject is selected
    private void rotationRightMouseBotton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        transform.Rotate(-mouseMovement * sensitivity * Time.deltaTime * 50);
        //   Vector3 eulerRotation = transform.rotation.eulerAngles;
        //    transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }



    public void setTarget(GameObject target)
    {
        this.targetGameObject = target;
        this.viewCenterRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
        viewCenterPosition = targetGameObject.transform.position + offset;
        desiredPosition = viewCenterPosition - viewCenterRotation * Vector3.forward * followDistance;
        Debug.Log("desiredPosition:" + desiredPosition);
    }



    private void updateTargetValue()
    {
        viewCenterPosition = targetGameObject.transform.position + offset;
    }

    //rotate the camera around
    private void setViewCenterRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, viewCenterRotation, sensitivity * Time.deltaTime);
    }


    //Follow the selected object if there is one
    private void autoFollowing()
    {
        transform.position = Vector3.Lerp(desiredPosition, transform.position, 0.1f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(viewCenterRotation, transform.rotation, 0.1f * Time.deltaTime);
    }


}

