using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool wKey = Input.GetKey(KeyCode.W);
        bool aKey = Input.GetKey(KeyCode.A);
        bool sKey = Input.GetKey(KeyCode.S);
        bool dKey = Input.GetKey(KeyCode.D);
        bool space = Input.GetKey(KeyCode.Space);
        
        // W, A, S, D
        if (wKey)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
        };
        if (aKey)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-2, 0, 0);
        };
        if (sKey)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -2);
        };
        if (dKey)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0);
        };

        // Jalan Miring
        if (wKey && aKey)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-2, 0, 2);
        };
        if (wKey && dKey)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 2);
        };
        if (sKey && aKey)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-2, 0, -2);
        };
        if (sKey && dKey)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2, 0, -2);
        }

        // Lompat
        if (space)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        };
    }
}
