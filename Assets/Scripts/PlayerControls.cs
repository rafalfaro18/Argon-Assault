using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        Debug.Log(xThrow);

        float yThrow = Input.GetAxis("Vertical");
        Debug.Log(yThrow);
    }
}
