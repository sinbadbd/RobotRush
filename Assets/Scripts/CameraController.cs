using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;


    public bool YMaxEnable = false;
    public float YMaxValue = 0;

    public bool YMinEnable = false;
    public float YMinValue = 0;

    public bool XMaxEnable = false;
    public float XMaxValue = 0;

    public bool XMinEnable = false;
    public float XMinValue = 0;



    private void FixedUpdate()
    {
        Vector3 targetPos = target.position;



        // Camera Horizontal
        if(YMinEnable && YMaxEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);

        }else if (YMinEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);

        }else if (YMaxEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);
        }


        // Verticle Camera

        if(XMinEnable && XMaxEnable)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);
        }else if (XMinEnable)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);
        }
        else if (XMaxEnable)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);
        }



        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

    }
}
