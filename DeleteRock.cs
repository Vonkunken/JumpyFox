using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRock : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 60)
        {
            Destroy(gameObject);
        }
    }
}
