using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform Player;

    private float Xmouse;
    private float Ymouse;
    private float Xrotation;
    public float speed = 800f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Xmouse = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        Ymouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        Xrotation -= Ymouse;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
        Player.Rotate(Vector3.up * Xmouse);
    }
}
