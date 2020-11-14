using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lettering : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    private float widthX = 0.00009f;

    private float widthY = 0.000029f;


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

        //if (up.y > -3)
        //{
            Vector3 scale = transform.localScale;
            scale.x = scale.x * 0.99995f; //- widthX;
            scale.y = scale.y * 0.999870f; //- widthY;
            transform.localScale = scale;
//        }


        //if (transform.localScale.y <= 0)
        //{
        //    Destroy(this);
        //}

    }
}
