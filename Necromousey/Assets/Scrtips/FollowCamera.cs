using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   
    public Transform Player;
    public Vector3 OffSet;


    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position + OffSet;
    }
}
