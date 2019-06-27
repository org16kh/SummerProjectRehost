using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables for Input Axes
    private string xInput = "Vertical";
    private string yInput = "Horizontal";

    public float moveSpeed = 2;

    public float rotationRate = 360;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis(xInput);
        float yAxis = Input.GetAxis(yInput);
        applyInput(xAxis, yAxis);


    }

    //call for both inputs, I split these in case we need to script animations on playerMovement
    private void applyInput(float xInput, float yInput)
    {
        xMove(xInput);
        yMove(yInput);
    }

    //Move Forward or Backward
    private void xMove(float input)
    {
        transform.Translate(transform.forward * input * moveSpeed *Time.deltaTime);
    }

    //Move Left or Right
    private void yMove(float input)
    {
        // Our clamping system :)
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0, Space.World);
        
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        
        if(currentRotation.y < 260f)
        {
            currentRotation.y = Mathf.Clamp(currentRotation.y, 0, 90);
            transform.localRotation = Quaternion.Euler(currentRotation);
        }
        else
        {
            currentRotation.y = Mathf.Clamp(currentRotation.y, 270, 360);
            transform.localRotation = Quaternion.Euler(currentRotation);
        }

        transform.Translate(transform.right * input * moveSpeed*Time.deltaTime);

    }
}
