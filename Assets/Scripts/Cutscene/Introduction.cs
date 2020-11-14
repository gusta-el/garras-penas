using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Introduction : MonoBehaviour
{
    [SerializeField]
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        
        DateTime datenow = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (timer <= 0)
        {
            Debug.Log("foiii");
            Destroy(this.gameObject);
        }
    }
}
