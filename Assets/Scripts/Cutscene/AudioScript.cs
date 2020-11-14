using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    private AudioSource audioData;
    [SerializeField]
    private int timer; 

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(timer <= 1000)
        {
            timer--;
        }


        if (timer <= 0)
        {
            audioData.Play(0);
            timer = 1500;
        }

    }
}
