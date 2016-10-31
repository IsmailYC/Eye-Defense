using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject barrier;
	public GameObject support;
	public GameObject beam;
	public int life;
	public Sprite[] sprites;
	public float refreshTime;
	public float[] barrierTimes;
	public float[] supportTimes;
	public float beamTime;

	bool damaged= false;
	bool barriered= false;
	bool supported= false;
	bool beaming= false;
	float barrierTime;
	float supportTime;
	float timeToDeactivateBarrier;
	float timeToDeactivateRefreshing;
	float timeToDeactivateSupport;
	float timeToDeactivateBeam;
	Animator animator;
	// Use this for initialization
	void Start () {
		if (barrier == null)
			barrier = GameObject.Find ("Barrier");
		if (support == null)
			support = GameObject.Find ("Support");
		if (beam == null)
			beam = GameObject.Find ("Beam");
		
		GetComponent<SpriteRenderer> ().sprite = sprites [life];
		animator = GetComponent<Animator> ();
		barrierTime = barrierTimes [PlayerPrefManager.GetBarrierBoostLvl()];
		supportTime = supportTimes [PlayerPrefManager.GetSupportBoostLvl()];
	}
	
	// Update is called once per frame
	void Update () {
		switch (GameManager.gm.gameState) {
		case GameManager.gameStates.Play:
			if (damaged) {
				if (Time.time>=timeToDeactivateRefreshing) {
					damaged = false;
					animator.SetTrigger ("Refresh");
				}
			}
			if (barriered) {
				if (Time.time>=timeToDeactivateBarrier) {
					barriered = false;
					barrier.SetActive (false);
				}
			}
			if (supported) {
				if (Time.time>= timeToDeactivateSupport) {
					supported = false;
					support.SetActive (false);
				}
			}
			if (beaming) {
				if (Time.time >= timeToDeactivateBeam) {
					beaming = false;
					beam.SetActive (false);
				}
			}
			break;
		case GameManager.gameStates.Over:
			if (damaged) {
				damaged = false;
				animator.SetTrigger ("Refresh");
			}
			if (barriered) {
				barriered = false;
				barrier.SetActive (false);
			}
			if (supported) {
				supported = false;
				support.SetActive (false);
			}
			if (beaming) {
				beaming = false;
				beam.SetActive (false);
			}
			break;
		default:
			break;
		}

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy") {
			if (!damaged) {
				ReduceLife ();
			}
			Destroy (coll.gameObject);
		}


	}

	private void ReduceLife()
	{
		if (life > 0) {
			life = life - 1;
			damaged = true;
			GetComponent<SpriteRenderer> ().sprite = sprites [life];
			animator.SetTrigger ("Damage");
			timeToDeactivateRefreshing = Time.time+refreshTime;
		} else
			GameManager.gm.EndGame();
	}

	public bool ActivateBarrier()
	{
		if (barriered)
			return false;
		else {
			barriered = true;
			barrier.SetActive (true);
            timeToDeactivateBarrier = Time.time + barrierTime;
			return true;
		}
	}

	public bool ActivateSupport()
	{
		if (supported)
			return false;
		else {
			supported = true;
			support.SetActive (true);
            timeToDeactivateSupport = Time.time + supportTime;
			return true;
		}
	}

	public bool RestoreLife()
	{
		if (life == 3)
			return false;
		else {
			life = 3;
			GetComponent<SpriteRenderer> ().sprite = sprites [life];
			return true;
		}
	}

	public bool ActivateBeam()
	{
		if (beaming)
			return false;
		else {
			beaming = true;
            timeToDeactivateBeam = Time.time + beamTime;
			beam.SetActive (true);
			return true;
		}
	}
}
