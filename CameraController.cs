using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;


    void Start()
    {
        
    }
    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 1.5f, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        
    }
}
