using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 playerOffset;
    public Transform playerTransform;

    void Start()
    {
        transform.position = playerTransform.position + playerOffset;
    }

    private void LateUpdate()
    {
        transform.position = playerTransform.position + new Vector3(playerOffset.x, 0, playerOffset.z);
        transform.position = playerTransform.position + playerOffset;
    }
}
