using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementV2 : MonoBehaviourPun
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    PhotonView pv;

    Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pv = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (pv.IsMine)
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            Vector3 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
            var cam = GameObject.Find("MainCamera");
            cam.transform.position = this.transform.position;

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        if (pv.IsMine)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
