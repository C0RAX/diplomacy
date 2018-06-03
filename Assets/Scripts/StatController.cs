    using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour {

    public Text aText;
    public Text eText;
    public Text fText;
    public Text gText;
    public Text iText;
    public Text rText;
    public Text tText;

    public void Awake()
    {
        if (PlayerData.isAustria == true)
        {
            string t;
            PlayerData.players.TryGetValue("Austria", out t);
            aText.text = t;
        }

        if (PlayerData.isEngland == true)
        {
            string t;
            PlayerData.players.TryGetValue("England", out t);
            eText.text = t;
        }

        if (PlayerData.isFrance == true)
        {
            string t;
            PlayerData.players.TryGetValue("France", out t);
            fText.text = t;
        }

        if (PlayerData.isGermany == true)
        {
            string t;
            PlayerData.players.TryGetValue("Germany", out t);
            gText.text = t;
        }

        if (PlayerData.isItaly == true)
        {
            string t;
            PlayerData.players.TryGetValue("Italy", out t);
            iText.text = t;
        }

        if (PlayerData.isRussia == true)
        {
            string t;
            PlayerData.players.TryGetValue("Russia", out t);
            rText.text = t;
        }

        if (PlayerData.isTurkey == true)
        {
            string t;
            PlayerData.players.TryGetValue("Turkey", out t);
            tText.text = t;
        }
    }

}
