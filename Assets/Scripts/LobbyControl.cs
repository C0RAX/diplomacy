using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyControl : MonoBehaviour {

    public Text aText;
    public Text eText;
    public Text fText;
    public Text gText;
    public Text iText;
    public Text rText;
    public Text tText;

    public Toggle aToggle;
    public Toggle eToggle;
    public Toggle fToggle;
    public Toggle gToggle;
    public Toggle iToggle;
    public Toggle rToggle;
    public Toggle tToggle;

    IEnumerator NextLevel()
    {
        //GameObject a = GameObject.Find("GameController");
        GetComponent<FaderScript>().BeginFade(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    IEnumerator MenuLevel()
    {
        //GameObject a = GameObject.Find("GameController");
        GetComponent<FaderScript>().BeginFade(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    public void Setupplayers()
    {
        int playercount = 0;
         if (aToggle.GetComponent<Toggle>().isOn == true)
         {
            PlayerData.players.Add("Austria",aText.text);
            PlayerData.isAustria = true;
            playercount++;
         }

        if (eToggle.GetComponent<Toggle>().isOn == true)
        {
            PlayerData.players.Add("England", eText.text);
            PlayerData.isEngland = true;
            playercount++;
        }

        if (fToggle.GetComponent<Toggle>().isOn == true)
        {
           PlayerData.players.Add("France", fText.text);
           PlayerData.isFrance = true;
           playercount++;
        }

        if (gToggle.GetComponent<Toggle>().isOn == true)
        {
           PlayerData.players.Add("Germany", gText.text);
           PlayerData.isGermany = true;
           playercount++;
        }

        if (iToggle.GetComponent<Toggle>().isOn == true)
        {
           PlayerData.players.Add("Italy", iText.text);
           PlayerData.isItaly = true;
           playercount++;
        }

        if (rToggle.GetComponent<Toggle>().isOn == true)
        {
           PlayerData.players.Add("Russia", rText.text);
           PlayerData.isRussia = true;
            playercount++;
        }

        if (tToggle.GetComponent<Toggle>().isOn == true)
        {
           PlayerData.players.Add("Turkey", tText.text);
           PlayerData.isTurkey = true;
            playercount++;
        }

        PlayerData.playerno = playercount;


            StartCoroutine(NextLevel());

    }

    public void BackToMenu() { StartCoroutine(MenuLevel()); }
}
