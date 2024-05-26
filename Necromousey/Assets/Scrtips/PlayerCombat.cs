using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]private Needle m_needle;
    [SerializeField]private Transform m_WeaponSlot;
    private PlayerHealth m_playerHealth;
    void Start()
    {
        m_playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Needle")
        {
            if(!m_needle._IsLanded)
                return;
            
            m_needle.ParentToPlayer(m_WeaponSlot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_needle._IsLanded)
            return;

        if(Input.GetMouseButton(0))
            m_needle.AimToMouse();
        if(Input.GetMouseButtonUp(0))
            m_needle.Throw();
    }
}
