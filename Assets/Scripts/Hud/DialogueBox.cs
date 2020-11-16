using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DialogueBox : MonoBehaviour
{

    public TMP_Text title;
    public TMP_Text subtitle;

    public GameObject prince;
    public GameObject dialogue;

    private Transform titleTransform;
    private Transform subtitleTransform;

    private Transform princeTransform;

    int countTitle = -1;


    // Start is called before the first frame update
    void Start()
    {
        titleTransform = title.transform;
        subtitleTransform = subtitle.transform;

        princeTransform = prince.transform;

        int counter = 0;




    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
            dialogue.SetActive(false);

        int countTitle = title.textInfo.characterCount;


        Debug.Log("count" + countTitle);



    }

    void LateUpdate()
    {
        fixPosition();
    
    }

    void fixPosition()
    {
        Vector3 temp = transform.position;
        temp.x = princeTransform.position.x;
        temp.y = princeTransform.position.y - 2.5f;

        transform.position = temp;

        temp.x = 470f;
        temp.y = 235f;
        titleTransform.position = temp;

        temp.x = 600f;
        temp.y = 190f;
        subtitleTransform.position = temp;

    }
}
