using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelObject : MonoBehaviour
{
    private Transform arCam;
    // Start is called before the first frame update
    void Start()
    {
        arCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(arCam);
    }
}
