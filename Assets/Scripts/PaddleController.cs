using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       var mousePosX = Input.mousePosition.x / Screen.width * 16f;

        //erstellt ein zwei dimensionales Vector objekt mit einer X und einer Y Koordinate
        //X: mousePosx
        //Y: 0,25

        Vector2 mouseVector = new Vector2(mousePosX, 0.5f);
        transform.position = mouseVector;

    }
}
