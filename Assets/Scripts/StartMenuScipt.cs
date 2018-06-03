using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuScipt : MonoBehaviour {

    IEnumerator ChangeLevel()
    {
        //GameObject a = GameObject.Find("GameController");
        GetComponent<FaderScript>().BeginFade(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        StartCoroutine(ChangeLevel());
     
    }

    public void ExitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }


}
