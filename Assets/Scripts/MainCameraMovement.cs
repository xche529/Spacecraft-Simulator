using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCameraMovement : MonoBehaviour
{
    public float speed = 100f;
    public float normalSpeed = 100f;
    public float slowSpeed = 50f;
    public float fastSpeed = 1000f;
    public float sensitivity = 30f;
    public float minFollowDistance = 5f;
    public float maxFollowDistance = 100f;
    public float currentFollowDistance = 10f;
    public GameObject targetGameObject;
    public Transform cameraLocater;
    public Vector3 offSet = new Vector3(0, 0, 0);

    private void Start()
    {
        GameObject camera = transform.parent.gameObject;
        cameraLocater = camera.transform;
        transform.position = cameraLocater.position;
    }
    void Update()
    {
        if (targetGameObject != null)
        {
            targetMovement();
        }
        else
        {
            noTargetMovement();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            unloadTarget();
        }
    }


    private void noTargetMovement()
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

    private void targetMovement()
    {
        if (Input.GetMouseButton(1))
        {
            rotationRightMouseBotton();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        followTarget();
        changeFollowDistance();
        changeOffset();
        rotationKey();
    }

    //press the middle mouse button to translate the camera
    private void movementMiddleMouseButton()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        cameraLocater.Translate(-movement * speed * Time.deltaTime);
    }

    //press the movement key to translate the camera
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
        cameraLocater.Translate(movement * speed * Time.deltaTime);
    }
    private void rotationKey()
    {
        float rotation = UnityEngine.Input.GetAxis("Rotate");
        cameraLocater.Rotate(Vector3.forward, -rotation * Time.deltaTime * 50);
    }

    //rotate the camera with the right mouse button
    private void rotationRightMouseBotton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        cameraLocater.Rotate(-mouseMovement * sensitivity * Time.deltaTime * 50);
        //   Vector3 eulerRotation = transform.rotation.eulerAngles;
        //    transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }

    public void setTarget(GameObject target)
    {
        this.targetGameObject = target;
        offSet =  Vector3.zero;
        currentFollowDistance = 30f;
    }
    public void unloadTarget()
    {
        this.targetGameObject = null;
        cameraLocater.position = transform.position;
        transform.localPosition = Vector3.zero;
    }
    private void changeFollowDistance()
    {
        float input = Input.GetAxis("Mouse ScrollWheel");
        
        if (input > 0 && currentFollowDistance > minFollowDistance)
        {
            currentFollowDistance -= currentFollowDistance / 10;
        }
        else if (input < 0 && currentFollowDistance < maxFollowDistance)
        {
            currentFollowDistance += currentFollowDistance / 10;
        }
    }

    private void followTarget()
    {
        cameraLocater.position = Vector3.Lerp(cameraLocater.position, targetGameObject.transform.position + offSet, slowSpeed * Time.deltaTime);
        transform.localPosition = Vector3.Lerp(transform.localPosition, -currentFollowDistance * Vector3.forward, slowSpeed * Time.deltaTime);
    }
    private void changeOffset()
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

        Vector3 offSetChange = transform.TransformDirection(movement);
        offSet += offSetChange * speed * Time.deltaTime;
    }
   
}

