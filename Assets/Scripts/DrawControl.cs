using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawControl : MonoBehaviour
{
    public GameObject pixelPrefab;
    public GameObject pixelPoint;

    bool isDrawing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
        if(isDrawing) {
            CreatePixel();
        }
    }

    void CheckTouch() {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            isDrawing = true;
        }
        else if(Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)) {
            isDrawing = false;
        }
    }

    void CreatePixel() {
        Instantiate(pixelPrefab, pixelPoint.transform.position, pixelPoint.transform.rotation);
    }
}
