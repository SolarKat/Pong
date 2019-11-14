using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    float shakeDuration = 0f;
    float shakeMagnitude = 0.5f;
    float dampeningSpeed = 1.0f;
    Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0)
        {
            transform.localPosition = initialPos + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampeningSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPos;
        }
    }

    public void OnEnable()
    {
        initialPos = transform.localPosition;
    }

    public void shake()
    {
        shakeDuration = 0.5f;
    }
}
