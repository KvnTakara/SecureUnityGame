using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    #region Variables

    [SerializeField] Animator animator;

    [SerializeField] GameObject camera;

    float walkSpeed = 7.5f;
    float runSpeed = 15f;

    float horizontal;
    float vertical;

    #endregion

    #region Initialization

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!base.IsOwner) return;

        camera = GameObject.FindWithTag("CameraMain");
        camera.GetComponent<CameraController>().target = transform;
    }

    void Update()
    {
        if (!base.IsOwner) return;

        MovePlayer();
        RotatePlayer();
        AnimatePlayer();
    }

    #endregion

    #region Functions

    void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        if (Input.GetKey(KeyCode.LeftShift)) transform.Translate(movement * runSpeed * Time.deltaTime, Space.World);
        else transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);
    }

    void RotatePlayer()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    void AnimatePlayer()
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        float mouseHorizontal = Input.mousePosition.x > Screen.width / 2 ? 1 : -1;
        float mouseVertical = Input.mousePosition.y > Screen.height / 2 ? 1 : -1;
        Vector3 mouseDirection = new Vector3(mouseHorizontal, 0, mouseVertical);

        float velocity = (Input.GetKey(KeyCode.LeftShift)) ? 2 : 1;

        if (movement.z > 0)
        {
            if (mouseDirection.z > 0) animator.SetFloat("VelocityZ", velocity);
            if (mouseDirection.z < 0) animator.SetFloat("VelocityZ", -velocity);
        }
        else if (movement.z < 0)
        {
            if(mouseDirection.z < 0) animator.SetFloat("VelocityZ", velocity);
            if (mouseDirection.z > 0) animator.SetFloat("VelocityZ", -velocity);
        }
        else animator.SetFloat("VelocityZ", 0);

        if (movement.x > 0)
        {
            if (mouseDirection.x > 0) animator.SetFloat("VelocityX", velocity);
            if (mouseDirection.x < 0) animator.SetFloat("VelocityX", -velocity);
        }
        else if (movement.x < 0)
        {
            if (mouseDirection.x < 0) animator.SetFloat("VelocityX", velocity);
            if (mouseDirection.x > 0) animator.SetFloat("VelocityX", -velocity);
        }
        else animator.SetFloat("VelocityX", 0);
    }

    #endregion
}
