using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarrasEPenas : MonoBehaviour
{

    private RectTransform rectTransform;
    [SerializeField]
    private AudioSource audioData;
    [SerializeField]
    private int timer;
    [SerializeField]
    private string sceneTutorial;


    [SerializeField]
    private Canvas canvasIntroduction;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = rectTransform.localScale;
        Quaternion rotation = rectTransform.rotation;


        pos.x = pos.x * 0.995f;
        pos.y = pos.y * 0.995f;
        

        if(pos.y <= 0.35 && rotation.x <= 0.58)
        {
            rotation.x = rotation.x + 0.0008f;
            rectTransform.rotation = rotation;
        }

        rectTransform.localScale = pos;


        if (timer <= 400)
        {
            timer--;
        }

        if (timer <= 0)
        {
            audioData.Play(0);
            Destroy(canvasIntroduction);
            timer = 1500;
        }

        if(audioData.time > 87)
            audioData.volume = audioData.volume * 0.99f;

        if (audioData.time >= 90) { 
            SceneManager.LoadScene(sceneTutorial);
            Destroy(this);
        }

        Debug.Log(audioData.time);

    }

}
