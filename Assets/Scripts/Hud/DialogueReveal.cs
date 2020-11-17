using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueReveal : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    [SerializeField]
    private CameraFollow2 player;
    [SerializeField]
    private GameObject dialogBox;

    [SerializeField]
    private DialogueManager dialogManager;


    private int countSpaceTyped = 0;
    private bool textActive = true;


    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           countSpaceTyped = countSpaceTyped + 1;
        }

        if (countSpaceTyped > 1)
        {
            NextSentence();
        }

        MoveDialogBox();

    }

        public void NextSentence()
        {

            textDisplay.text = "";
            if (index < sentences.Length - 1)
            {
                countSpaceTyped = 0;
                index++;
                StartCoroutine(Type());
            } else
            {
                dialogManager.ResetDialog();
                dialogBox.SetActive(false);

            }

        }

        IEnumerator Type()
        {

            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;

                if (countSpaceTyped == 1)
                {
                    textDisplay.text = sentences[index];
                    break;

                }

                yield return new WaitForSeconds(typingSpeed);

            }

        }

    public void MoveDialogBox()
    {

        Vector3 finalPos = dialogBox.transform.position;
        finalPos.x = player.transform.position.x;
        finalPos.y = player.transform.position.y - 3.7f;
        dialogBox.transform.position = finalPos;

    }

}
