using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
private Vector3 moveDirection = Vector3.zero;
private float verticalRotation = 0.0f;
private Camera playerCamera;
private CharacterController controller;
public float moveSpeed = 10.0f;
public float mouseSensitivity = 2.0f;
public float IsMoving;
public float Xies;
private Alteruna.Avatar _avatar;
private float distanciaParaTras=3f;
private float altura=2f;
public int atividade;
public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();
        if(!_avatar.IsOwner)
            return;

            controller = GetComponent<CharacterController>();
            playerCamera = Camera.main;
            playerCamera.transform.position = transform.position - transform.forward * distanciaParaTras + Vector3.up * altura;
            playerCamera.transform.SetParent(transform);
            playerCamera.transform.LookAt(transform.position);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
    }
     
        

    // Update is called once per frame
    void Update()
    {
        if(!_avatar.IsOwner)
            return;
            IsMoving = controller.velocity.magnitude + Xies;
            float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
            float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;
            Vector3 normalizedMoveDirection = (transform.forward * forwardSpeed).normalized + (transform.right * sideSpeed).normalized;
            moveDirection = normalizedMoveDirection * moveSpeed;
            if (!controller.isGrounded)
            {
                moveDirection += Physics.gravity;
            }
            if(Time.timeScale != 0){
            float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

            transform.Rotate(0, horizontalRotation, 0);
            playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
            }

            controller.Move(moveDirection * Time.deltaTime);
            if(isDead){
                Vaiprala();
            }
    }
    public void Vaiprala(){
        transform.position= new Vector3(91.05f,-2.4f,6.93f);
    }
}
