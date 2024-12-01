using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMove : MonoBehaviour
{
    public static float moveSpeed;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f,-moveSpeed,0f);
    }
}