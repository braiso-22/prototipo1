using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCoche : MonoBehaviour
{
    Vector3 move;
    public float vel;
    public float giro;
    private float horizontalInput;
    private float forwardInput;
    public KeyCode key;

    public Camera mainCamera;
    public Camera secondCamera;
    public int controles;
    void Start()
    {
        secondCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + controles);
        forwardInput = Input.GetAxis("Vertical" + controles);

        transform.Translate(Vector3.forward * Time.deltaTime * vel * forwardInput);

        transform.Rotate(Vector3.up * Time.deltaTime * giro * horizontalInput);

        if (Input.GetKeyDown(key))
        {
            mainCamera.enabled = !mainCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
        }
    }
}
