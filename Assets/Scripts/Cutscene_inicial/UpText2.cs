using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpText2 : MonoBehaviour
{
    private float velocity = 0.0006f;

    private float widthX = 0.00005f;

    private float widthY = 0.0001f;

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

        if(up.y > -10)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x - widthX;
            scale.y = scale.y - widthY;
            transform.localScale = scale;
        }


        if (transform.localScale.y <= 0)
        {
            Destroy(this);
        }

    }
}
