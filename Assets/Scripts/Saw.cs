using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    AudioManager audioManager;

    float sawSpeed = 300;

    void Start()
    {
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, sawSpeed * Time.deltaTime);
        audioManager.PlaySound("saw running");
    }
}
