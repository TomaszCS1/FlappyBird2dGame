using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private BirdController followTarget;

    private Vector3 originalPosition;
    private float cameraOffset;

    

    // Start is called before the first frame update
    void Start()
    {
        followTarget = FindObjectOfType<BirdController>();    
        originalPosition= transform.position;
        cameraOffset = this.transform.localPosition.z;
    }


    private void FixedUpdate()
    {
        transform.position =  new Vector3(0,0,cameraOffset) + followTarget.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
