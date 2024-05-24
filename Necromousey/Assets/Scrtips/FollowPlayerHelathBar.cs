using UnityEngine;

public class FollowPlayerHelathBar : MonoBehaviour
{
     [SerializeField] public Transform player;
     [SerializeField] public Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offSet;
    }
}
