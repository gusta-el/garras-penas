using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuMotor : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    [SerializeField]
    private Animator transitionAnimator;


    public void ChangeScene()
    {
        //StartCoroutine(LoadScene());
        SceneManager.LoadScene(sceneName);
    }

    //IEnumerator LoadScene()
    ///{
    //    transitionAnimator.SetTrigger("FadeOut");
    //    yield return new WaitForSeconds(1.5f);
    //    SceneManager.LoadScene(sceneName);

    //}



    public void QuitGame() 
    {
        Application.Quit();
    }



}
