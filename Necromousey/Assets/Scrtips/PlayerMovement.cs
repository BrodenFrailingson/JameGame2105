using System.Xml.Schema;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float Speed =3f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float RotSpeed = 0.5f;

    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0.0f || vertical != 0.0f)
            lerpRotations(horizontal, vertical);
    }

    private void  FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, vertical * Speed);
        rb.velocity = new Vector2(horizontal * Speed,rb.velocity.y);
    }

    private void lerpRotations(float horizontal, float vertical)
    {
        Quaternion currot = new();
        currot = gameObject.transform.rotation;
        float targetRot;

        targetRot = Mathf.Atan2(vertical, horizontal) * 180/Mathf.PI - 90; // angles 0 - 180
        
        gameObject.transform.rotation = Quaternion.RotateTowards(currot, Quaternion.AngleAxis(targetRot, new Vector3(0, 0, 1)), RotSpeed);
    }
}
