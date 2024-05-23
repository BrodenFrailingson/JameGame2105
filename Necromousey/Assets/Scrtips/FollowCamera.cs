using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 OffSet;
    
    private Camera m_Camera;

    [Header("World Bounds")]
    //
    // Summary:
    //     distance form centre of map to outer edges.    
    [SerializeField] private Vector2 Bounds;

    void Start()
    {
        m_Camera = Camera.main;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 temppos = new();
        Vector3 newpos = new();
        temppos = Player.position + OffSet;
        TestWorldBounds(temppos, out newpos);
        transform.position = newpos;
    }

    private void TestWorldBounds(Vector3 pos, out Vector3 newpos)
    {
        float cameraWidth = m_Camera.orthographicSize * m_Camera.aspect;
        if(pos.y + m_Camera.orthographicSize >=Bounds.y)    {pos.y = Bounds.y - m_Camera.orthographicSize; }
        if(pos.y - m_Camera.orthographicSize <=-Bounds.y)  {pos.y = -Bounds.y  + m_Camera.orthographicSize; }
        if(pos.x - cameraWidth <=-Bounds.x)  {pos.x = -Bounds.x  + cameraWidth;  }
        if(pos.x + cameraWidth >= Bounds.x) {pos.x = Bounds.x - cameraWidth;  }
        
        newpos = pos;
    }
}
