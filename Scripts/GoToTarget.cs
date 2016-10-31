using UnityEngine;
using System.Collections;

public class GoToTarget : MonoBehaviour {
	
	public Transform target;
	public float speed;

	private Vector2 dir;
	// Use this for initialization
	void Start () {
		dir = target.position - transform.position;
		dir.Normalize ();
		float sign = Mathf.Sign (Vector3.Cross (Vector2.up, transform.position).z);
		float angle = sign * Vector2.Angle (Vector2.up, transform.position);
		transform.Rotate (0, 0, angle);
	}
	
	// Update is called once per frame
	void Update () {
		switch (GameManager.gm.gameState) {
		case GameManager.gameStates.Play:
			gameObject.GetComponent<Rigidbody2D> ().velocity = speed*dir;
			break;
		default:
			break;
		}
	}
}
