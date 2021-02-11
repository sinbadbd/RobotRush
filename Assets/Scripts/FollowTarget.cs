using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

    }
}
