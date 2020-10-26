using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private string TAG_PLAYER = "prince_player";
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(TAG_PLAYER).transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //current camera's position
        Vector3 temp = transform.position;

        //set camera's position the same of the player
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;
        transform.position = temp;

    }

}
