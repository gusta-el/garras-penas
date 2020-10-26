using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpText : MonoBehaviour
{

    private float velocity = 0.00055f;

    private float widthX = 0.00003f;

    private float widthY = 0.00008f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 up = transform.position;
        up.y = up.y + velocity;
        transform.position = up;

        if (up.y > -10)
        {

            
            Vector3 scale = transform.localScale;
            scale.x = scale.x - widthX;
            scale.y = scale.y - widthY;
            transform.localScale = scale;
            Debug.Log("" + scale.y);
        }

        if (up.y > -2)
        {
            //widthY = 0.000075f;
            //widthX = 0.00008f;
        }


        if (transform.localScale.y <= 0)
        {
            Destroy(this);
        }

    }

}
