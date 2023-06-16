using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    GameObject mainCamera;
    MainCameraMovement cameraScript;
    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
        cameraScript = mainCamera.GetComponent<MainCameraMovement>();
    }

    private void OnMouseDown()
    {

        cameraScript.setTarget(this.gameObject);

    }
}

