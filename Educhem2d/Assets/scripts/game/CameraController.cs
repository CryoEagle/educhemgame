using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviourPun
{
    public GameObject followTarget;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private float cameraZ = 0;

    private new Camera camera;
    public PhotonView PV;

    void Start()
    {
        camera = GetComponent<Camera>();
        if (PV.IsMine)
        {
            cameraZ = transform.position.z;
        } else
        {
            camera.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (PV.IsMine)
        {
            if (followTarget)
            {
                Vector3 delta = followTarget.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraZ));
                Vector3 destination = transform.position + delta;
                destination.z = cameraZ;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
        }
    }
}
