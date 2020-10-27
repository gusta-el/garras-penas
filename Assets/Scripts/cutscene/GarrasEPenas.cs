using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarrasEPenas : MonoBehaviour
{

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = rectTransform.localScale;
        Quaternion rotation = rectTransform.rotation;


        pos.x = pos.x * 0.9995f;
        pos.y = pos.y * 0.9995f;
        

        if(pos.y <= 0.35 && rotation.x <= 0.58)
        {
            rotation.x = rotation.x + 0.0008f;
            rectTransform.rotation = rotation;
        }

        rectTransform.localScale = pos;

    }
}
