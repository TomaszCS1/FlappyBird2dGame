using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private BirdController followTarget;

    private Vector3 originalPosition;
    private float cameraOffset;

    public float shakeDuration = 3f;
    public float shakeMagnitude = 0.9f;
    public float dampingSpeed = 0.2f;

    private Vector3 initialPosition;
    private float currentShakeDuration;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = FindObjectOfType<BirdController>();    
        originalPosition= transform.position;
        cameraOffset = this.transform.localPosition.z;

        currentShakeDuration = shakeDuration;
        initialPosition = transform.localPosition;

    }


    private void FixedUpdate()
    {
        transform.position =  new Vector3(0,0,cameraOffset) + followTarget.transform.position;


    }

    public void CameraShake()
    {
        while(currentShakeDuration > 0)
        {
            transform.localPosition = /*initialPosition +*/ Random.insideUnitSphere * shakeMagnitude;

            currentShakeDuration -= Time.deltaTime * dampingSpeed;
        }
        currentShakeDuration = shakeDuration;
    }

}
