using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform targetPlayer;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (targetPlayer.position.x + offset.x, targetPlayer.position.y + offset.y, -10); // Camera follows the player with specified offset position
    }
}
