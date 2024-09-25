using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;  
    [SerializeField] float heightOfTheCamera = -50f;

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, heightOfTheCamera);
    }
}
