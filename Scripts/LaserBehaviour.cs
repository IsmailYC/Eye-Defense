using UnityEngine;
using System.Collections;

public class LaserBehaviour : MonoBehaviour {
	public GameObject laserMiddle;

	private GameObject middle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (GameManager.gm.gameState) {
		case GameManager.gameStates.Play:
			if (middle == null) {
				middle = Instantiate (laserMiddle, Vector2.zero, this.transform.rotation) as GameObject;
				middle.transform.parent = this.transform;
			}

			float maxLaserSize = 20.0f;
			float currentLaserSize = maxLaserSize;

			Vector2 laserDirection = this.transform.up;
			int layerMask = 1 << 8;
			RaycastHit2D hit = Physics2D.Raycast (this.transform.position, laserDirection, maxLaserSize, layerMask);
			if (hit) {
				currentLaserSize = Vector2.Distance (hit.point, this.transform.position);
			}
			middle.transform.localScale = new Vector2 (middle.transform.localScale.x, (currentLaserSize+0.5f) / 4.76f);
			middle.transform.localPosition = new Vector2 (0f, (currentLaserSize+0.5f)/2f);
			break;
		case GameManager.gameStates.Over:
			Destroy (middle);
			break;
		default:
			break;
		}
	}
}
