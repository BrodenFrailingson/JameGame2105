using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class Needle : MonoBehaviour
{
    /*TODO: Have needle follow player, attactch to tail
            Have needle rotate towards mouse cursor when aiming
            have needle move in aiming direction for range seconds one left click released
            have needle reattach to mouse when mouse walks over*/
    private int m_MaxPeirce = 3;
    private int m_EnemiesPeirced = 0;
    private float m_Speed = 5.0f;
    private float m_Range = 1.0f;
    private bool m_HasString = false;
    private bool m_islanded = false;
    private bool m_IsAiming = false;

    public int _MaxPeirce {get {return m_MaxPeirce;} set{m_MaxPeirce = value;} }
    public int _EnemiesPeirced {get {return m_EnemiesPeirced;}}
    public float _Speed {get {return m_Speed;} set{m_Speed = value;} }
    public float _Range {get {return m_Range;} set{m_Range = value;} }
    public bool _HasString {get {return m_HasString;} }
    public bool _IsLanded {get {return m_islanded;}}
    public bool _IsAiming {get{return m_IsAiming;} set{m_IsAiming = value;}}
    private Vector2 m_MousePos = new();
    private Rigidbody2D m_rb;
    private Transform m_Original;
    [SerializeField]private Transform m_transform;
    // Start is called before the first frame update
    void Start()
    {
        m_Original = m_transform;
        m_rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    public void Throw()
    {
        Vector2 newVel = new Vector2(m_transform.position.x - m_MousePos.x, m_transform.position.y - m_MousePos.y).normalized * m_Speed;
        m_rb.velocity = -newVel;
        m_IsAiming = false;

        transform.SetParent(null, true);
        StartCoroutine(Travel());
    }

    public void ParentToPlayer(Transform parent)
    {
        transform.SetParent(parent, true);
        m_islanded = !m_islanded;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            m_EnemiesPeirced +=1;
            if(m_EnemiesPeirced == m_MaxPeirce)
            {
                m_rb.velocity = new(0,0);
                m_islanded = !m_islanded;
                m_EnemiesPeirced=0;
            }
        }
    }
    private void Update() {
        if(m_islanded)
            return;
        if(m_transform.parent == null)
            return;

        m_transform.position = m_transform.parent.position;
        if(!m_IsAiming)
            m_transform.rotation = m_transform.parent.rotation;
    }
    private IEnumerator Travel()
    {
        yield return new WaitForSeconds(m_Range);
        m_rb.velocity = new(0,0);
        m_islanded = !m_islanded;
        yield break;
    }
    public void AimToMouse()
    {
        m_IsAiming = true;
        m_MousePos = new(Input.mousePosition.x, Input.mousePosition.y);
        m_MousePos = Camera.main.ScreenToWorldPoint(m_MousePos);

        float pointToMouse = Mathf.Atan2(m_transform.position.y - m_MousePos.y, m_transform.position.x - m_MousePos.x) * 180/Mathf.PI + 90;
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.AngleAxis(pointToMouse, new Vector3(0,0,1)), 20.0f);


    }
}
