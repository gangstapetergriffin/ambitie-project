using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsway : MonoBehaviour
{
    public float smooth;
    public float swayMultiplier;

    [Header("attack settings")]
    public float attackamount;
    public float attacksmooth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // sway rotation
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;
        float mouseZ = Input.GetAxisRaw("Mouse X") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.left);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion rotationZ = Quaternion.AngleAxis(mouseZ, Vector3.back);

        Quaternion targetRotation = rotationX * rotationZ;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

        Quaternion Attack = Quaternion.AngleAxis(attackamount, Vector3.right);

        if (Input.GetMouseButtonDown(0))
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Attack, attacksmooth * Time.deltaTime);
        }

    }
}
