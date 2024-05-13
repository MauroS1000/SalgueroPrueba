using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    private void Update()
    {
        if (player == null)
            return;
        transform.position = 
            new Vector3(player.transform.position.x, transform.position.y,transform.position.z);
    }
}
