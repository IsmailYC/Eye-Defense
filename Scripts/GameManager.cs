using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public enum gameStates {Menu, Play, Over};
	public static GameManager gm;

	public GameObject camera1;
	public GameObject pupil;
	public GameObject player;

	public GameObject menuCanvas;
	public GameObject storeCanvas;
	public GameObject mainCanvas;
	public Text mainScoreDisplay;
	public GameObject pauseCanvas;
	public Text shieldPauseDisplay;
	public Text supportPauseDisplay;
	public Text gogglePauseDisplay;
	public Text pillPauseDisplay;
	public GameObject overCanvas;
	public Text overScoreDisplay;
	public Text overHighScoreDisplay;
    public GameObject shieldTipPanel;
    public GameObject supportTipPanel;
    public GameObject pillTipPanel;
    public GameObject goggleTipPanel;
    public GameObject storeTipPanel;

	public int score=0;
	public int highscore=0;
	public int shields = 0;
	public int supports= 0;
	public int pills= 0;
	public int goggles= 0;
	public int dna=0;
	public gameStates gameState=gameStates.Menu;

	FollowPointer fp;
	PlayerController pc;
	Animator cameraAnimator;
	Animator pupilAnimator;
	// Use this for initialization
	void Start () {
		if (gm == null)
			gm = GetComponent<GameManager> ();

		if (camera1 == null)
			camera1 = GameObject.Find ("MainCamera");
		cameraAnimator = camera1.GetComponent<Animator> ();

		if (pupil == null)
			pupil = GameObject.Find ("Pupil");
		pupilAnimator = pupil.GetComponent<Animator> ();

		if (player == null)
			player = GameObject.Find ("Eye");

		dna = PlayerPrefManager.GetDNA ();
		highscore = PlayerPrefManager.GetHighScore ();
		shields = PlayerPrefManager.GetShields ();
		supports = PlayerPrefManager.GetSupports ();
		pills = PlayerPrefManager.GetPills ();

		fp = pupil.GetComponent<FollowPointer> ();
		pc = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (gameState) {
            case gameStates.Menu:
                break;
            case gameStates.Play:
                if (Input.GetButtonDown("Jump"))
                    pauseCanvas.SetActive(true);
                break;
            case gameStates.Over:
                break;
		}
	}

	public void Collect(int c)
	{
		score = score + c;
		mainScoreDisplay.text = score.ToString ();
		if (score > highscore)
			highscore = score;
	}

	public void StartGame()
	{
		StartCoroutine (Starting ());
	}

	IEnumerator Starting()
	{
		menuCanvas.SetActive (false);
		cameraAnimator.SetTrigger ("Start");
		pupilAnimator.SetTrigger ("Start");
		yield return new WaitForSeconds (0.5f);
		pupilAnimator.enabled = false;
		gameState = gameStates.Play;
		mainCanvas.SetActive (true);
		Collect (0);
		CollectGoggle (0,false);
		CollectPill (0,false);
		CollectShield (0,false);
		CollectSupport (0,false);
	}

	public void EndGame()
	{
		StartCoroutine (Ending ());
	}

	IEnumerator Ending()
	{
		gameState = gameStates.Over;
		mainCanvas.SetActive (false);
		cameraAnimator.SetTrigger("End");
		yield return new WaitForSeconds(0.5f);
		overCanvas.SetActive (true);
		overScoreDisplay.text = score.ToString ();
		if (highscore == score) {
			overHighScoreDisplay.text= "New Record";
			overHighScoreDisplay.color = Color.green;
		} else {
			overHighScoreDisplay.text = highscore.ToString ();
			overHighScoreDisplay.color = Color.red;
		}
		score = 0;
		goggles = 0;
	}

	public void ReplayGame()
	{
		StartCoroutine (Replaying ());
	}

	IEnumerator Replaying()
	{
		overCanvas.SetActive (false);
		cameraAnimator.SetTrigger ("Replay");
		yield return new WaitForSeconds (0.5f);
		pc.RestoreLife ();
		fp.RestorePosition ();
		gameState = gameStates.Play;
		mainCanvas.SetActive (true);
        goggles = 0;
        CollectGoggle(0, false);
		Collect (0);
	}

	public void RestartGame()
	{
		PlayerPrefManager.SetHighScore (highscore);
		PlayerPrefManager.SetDNA (dna);
		PlayerPrefManager.SetShields (shields);
		PlayerPrefManager.SetSupports (supports);
		PlayerPrefManager.SetPills (pills);
		SceneManager.LoadScene ("Test");
	}

    public void ToggleMenuCanvas()
    {
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }

    public void ReloadParameters(bool rldHighscore)
    {
        if (rldHighscore)
            highscore = PlayerPrefManager.GetHighScore();
        dna = PlayerPrefManager.GetDNA();
        pills = PlayerPrefManager.GetPills();
        shields = PlayerPrefManager.GetShields();
        supports = PlayerPrefManager.GetSupports();
    }
	public void ActivateBarrier()
	{
		if (shields > 0) {
			if (pc.ActivateBarrier ()) {
				CollectShield(-1,false);
                pauseCanvas.SetActive(false);
			}
		}
	}

	public void ActivateSupport()
	{
		if (supports > 0) {
			if (pc.ActivateSupport ()) {
				CollectSupport (-1,false);
                pauseCanvas.SetActive(false);
            }
		}
	}

	public void RestorePlayer()
	{
		if (pills > 0) {
			if (pc.RestoreLife ()) {
				CollectPill (-1,false);
                pauseCanvas.SetActive(false);
            }
		}
	}

	public void ActivateBeam()
	{
		if (goggles > 0) {
			if (pc.ActivateBeam ()) {
				CollectGoggle (-1,false);
                pauseCanvas.SetActive(false);
            }
		}
	}

	public void CollectShield(int i, bool tip){
        if (tip)
        {
            shieldTipPanel.SetActive(true);
            PlayerPrefManager.SetShieldTip(false);
        }
        shields +=i;
		shieldPauseDisplay.text = shields.ToString ();
	}

	public void CollectSupport(int i, bool tip)
	{
        if(tip)
        {
            supportTipPanel.SetActive(true);
            PlayerPrefManager.SetSupportTip(false);
        }
        supports +=i;
		supportPauseDisplay.text = supports.ToString ();
	}

	public void CollectPill(int i, bool tip)
	{
        if (tip)
        {
            pillTipPanel.SetActive(true);
            PlayerPrefManager.SetPillTip(false);
        }
        pills +=i;
		pillPauseDisplay.text = pills.ToString ();
	}

	public void CollectGoggle(int i,bool tip)
	{
        if (tip)
        {
            goggleTipPanel.SetActive(true);
            PlayerPrefManager.SetGoggleTip(false);
        }
        goggles +=i;
		gogglePauseDisplay.text = goggles.ToString ();
	}

	public void CollectDNA(int i, bool tip)
	{
        if (tip)
        {
            storeTipPanel.SetActive(true);
            PlayerPrefManager.SetStoreTip(false);
        }
        dna += i;
	}

	public void CloseGame()
	{
		PlayerPrefs.Save ();
		Application.Quit ();
	}
}
