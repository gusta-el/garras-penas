using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private CameraFollow2 cam;
    [SerializeField]
    private GameObject _dialogBox;
    [SerializeField]
    private GameObject [] dialogs;

    private bool _isActive;
    private int _dialogSequence;

    public bool IsActive { get => _isActive; set => _isActive = value; }
    public int DialogSequence { get => _dialogSequence; set => _dialogSequence = value; }

    // Update is called once per frame
    void Update()
    {
        MoveDialogBox();
    }

    public void MoveDialogBox()
    {

        Vector3 finalPos = _dialogBox.transform.position;
        finalPos.x = cam.transform.position.x;
        finalPos.y = cam.transform.position.y - 3.7f;
        _dialogBox.transform.position = finalPos;

    }

    public void StartDialog(int _dialogSequence)
    {
        DialogSequence = _dialogSequence;
        dialogs[_dialogSequence].SetActive(true);
        _dialogBox.SetActive(true);
        _isActive = true;
    }

    public void ResetDialog()
    {
        dialogs[DialogSequence].SetActive(false);
        _dialogBox.SetActive(false);
        _isActive = false;
    }

}
