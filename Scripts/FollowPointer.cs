using UnityEngine;
using System.Collections;

public class FollowPointer : MonoBehaviour {
	public Transform target;
	public GameObject[] supports;
	private Vector2 mousePos;
	// Use this for initialization
	void Start () {
		mousePos = Vector2.up;
	}

	// Update is called once per frame
	void Update () {
		switch (GameManager.gm.gameState) {
		case GameManager.gameStates.Play:
			#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WEBGL || UNITY_EDITOR
			if (Input.GetMouseButton (0))
				mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			#else
			if (Input.touchCount > 0)
				mousePos = Camera.main.ScreenToWorldPoint (Input.touches [Input.touchCount - 1].position);
			#endif
			float sign = Mathf.Sign (Vector3.Cross (transform.up, mousePos).z);
			float speed = 10 * (sign * Vector2.Angle (transform.up, mousePos));
			transform.RotateAround (Vector3.zero, Vector3.forward, speed * Time.deltaTime);
			for (int i = 0; i < supports.Length; i++) {
				supports[i].transform.RotateAround (Vector3.zero, Vector3.forward, speed * Time.deltaTime);
			}
			break;
		case GameManager.gameStates.Over:
			sign = Mathf.Sign (Vector3.Cross (transform.up, Vector2.up).z);
			speed = 10 * (sign * Vector2.Angle (transform.up, Vector2.up));
			transform.RotateAround (Vector3.zero, Vector3.forward, speed * Time.deltaTime);
			break;
		default:
			break;
		}
	}

	public void RestorePosition()
	{
		mousePos = Vector2.up;
	}
}
