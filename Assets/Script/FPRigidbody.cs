using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPRigidbody : MonoBehaviour {

    Vector3 InputVector;
    Rigidbody rb;
    public float moveSpeed = 10f;
    public float gravity = -0.5f;
    public float mouseSensitivity = 100f;
    float mouseY;

    void Start() {
        rb = GetComponent<Rigidbody>();

    }
        void Update() {

            InputVector.x = Input.GetAxis("Horizontal");
            InputVector.y = gravity;
            InputVector.z = Input.GetAxis("Vertical");


            transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0f);
            mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
            mouseY = Mathf.Clamp(mouseY, -60f, 60f);
            Camera.main.transform.localEulerAngles = new Vector3(mouseY, 0f, 0f);

            if (Input.GetMouseButtonDown(0)) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }



        void FixedUpdate() {

            Vector3 worldVector = transform.right * InputVector.x + transform.forward * InputVector.z + transform.up * InputVector.y;



            rb.velocity = worldVector * moveSpeed;


        }
    }


