using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    private ARSessionOrigin arOrigin;
    private ARRaycastManager arRaycast; // unity에서 arOrign raycast를 지원했는데 ar raycast manager로 따로 뺌
    private Pose placementPose; // 카메라가 어딜 포인팅 하고있는지 알기 위함 
    private bool placementPoseIsVaild = false;
    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        arRaycast = arOrigin.GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        // 평면 인식이 되어있고, 터치를 했으며, 첫번째 터치 동작이 시작 단계일 경우
        if(placementPoseIsVaild && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        if(placementPoseIsVaild) {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycast.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        // raycast로 측정된 plane이 한개 이상 있을시 첫 오브젝트 pose를 placementPose에 갱신
        placementPoseIsVaild = hits.Count > 0;

        if(placementPoseIsVaild) {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
