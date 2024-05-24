using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    /*TODO: Have needle follow player, attactch to tail
            Have needle rotate towards mouse cursor when aiming
            have needle move in aiming direction for range seconds one left click released
            have needle reattach to mouse when mouse walks over*/
    private int m_Peirce = 3;
    private float m_Range = 3.0f;
    private bool m_HasString = false;
    private bool m_islanded = false;

    private Vector3 Position = new();
    // Start is called before the first frame update
    void Start()
    {
        Position = gameObject.transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = new(Input.mousePosition.x, Input.mousePosition.y);
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);

        float pointToMouse = Mathf.Atan2(Position.y - MousePos.y, Position.x - MousePos.x) * 180/Mathf.PI + 90;
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.AngleAxis(pointToMouse, new Vector3(0,0,1)), 20.0f);
    }
}
