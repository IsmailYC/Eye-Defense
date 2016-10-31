using UnityEngine;
using System.Collections;

public class PrefController : MonoBehaviour {
    public bool highscore;
    public bool boost;
    public bool tip;
    public void ResetPrefs()
    {
        PlayerPrefManager.ResetPrefs(highscore, boost, tip);
    }
}