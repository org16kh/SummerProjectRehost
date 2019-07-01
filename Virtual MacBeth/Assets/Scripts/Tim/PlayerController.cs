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
        playerRotate(xInput, yInput);
    }

    //Move Forward or Backward
    private void xMove(float input)
    {
        if (input != 0)
        {
            transform.Translate(transform.forward * input * moveSpeed * Time.deltaTime);
        }

    }

    //Move Left or Right
    private void yMove(float input)
    {
        // Our clamping system :)
        /*transform.Rotate(0, input * rotationRate * Time.deltaTime, 0, Space.World);
        
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
        }*/

        if (input != 0)
        {
            transform.Translate(transform.right * -input * moveSpeed * Time.deltaTime);
        }
    }
    private void playerRotate(float xInput, float yInput)
    {
        if (yInput != 0 && xInput != 0)
        {
            if (xInput < 0)
            {
                if (yInput < 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 225, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 135, 0);
                }
            }
            else
            {
                if (yInput < 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 315, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 45, 0);
                }
            }
        }
        else if (yInput == 0 && xInput != 0)
        {
            if (xInput < 0.0f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (yInput != 0 && xInput == 0)
        {
            if (yInput < 0.0f)
            {
                transform.localRotation = Quaternion.Euler(0, 270, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 90, 0);
            }
        }
        else 
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
