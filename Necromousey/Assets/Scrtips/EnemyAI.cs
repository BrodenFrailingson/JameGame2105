using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float speed = 3f; 
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Needle")
        {
            Needle needle = other.GetComponent<Needle>();
            if(needle._IsLanded)
                return;
            if(needle._EnemiesPeirced >= needle._MaxPeirce)
                return;

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    
}
