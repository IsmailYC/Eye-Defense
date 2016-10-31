using UnityEngine;
using System.Collections;

public class VirusBehaviour : MonoBehaviour {
	public float[] damageBoosts;
	public int[] scoreBoosts;
	public float damageSpeed;
	public float life;
	public int score;
	public float speed;

	Vector2 dir;
	float damageBoost;
	int scoreBoost;
	bool takingDamage;
	// Use this for initialization
	void Start () {
		dir = - transform.position;
		dir.Normalize ();
		float sign = Mathf.Sign (Vector3.Cross (Vector2.up, transform.position).z);
		float angle = sign * Vector2.Angle (Vector2.up, transform.position);
		transform.Rotate (0, 0, angle);
		damageBoost = damageBoosts [PlayerPrefManager.GetDamageBoostLvl()];
		scoreBoost = scoreBoosts [PlayerPrefManager.GetScoreBoostLvl()];
	}
	
	// Update is called once per frame
	void Update () {
		switch (GameManager.gm.gameState) {
		case GameManager.gameStates.Play:
			if (takingDamage) {
				transform.Translate (new Vector3(0,-Time.deltaTime * speed / 2,0));
				life = life - damageBoost*damageSpeed * Time.deltaTime;
				if (life < 0) {
					GameManager.gm.Collect (score*scoreBoost);
					Destroy (gameObject);
				}
			} else
				transform.Translate (new Vector3(0,-Time.deltaTime * speed,0));
			break;
		case GameManager.gameStates.Over:
			Destroy (gameObject);
			break;
		default:
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Laser")
			takingDamage = true;
		if (coll.gameObject.name == "Barrier" || coll.gameObject.name=="Beam") {
			GameManager.gm.Collect (score*scoreBoost);
			Destroy (gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Laser")
			takingDamage = false;
	}
}
