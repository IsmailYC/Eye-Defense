using UnityEngine;
using System.Collections;

public class GoToOrigin2 : MonoBehaviour {
	
	public float speed;

	private Vector2 dir;
	// Use this for initialization
	void Start () {
		dir = - transform.position;
		dir.Normalize ();
		float sign = Mathf.Sign (Vector3.Cross (Vector2.up, transform.position).z);
		float angle = sign * Vector2.Angle (Vector2.up, transform.position);
		transform.Rotate (0, 0, angle);
	}
	
	// Update is called once per frame
	void Update () {
		switch (GameManager.gm.gameState) {
		case GameManager.gameStates.Play:
			transform.Translate (speed * dir * Time.deltaTime);
			break;
		default:
			break;
		}
	}
}
