using UnityEngine;
using System.Collections;

public class PillCollection : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Barrier" || coll.gameObject.name=="Eye") {
			GameManager.gm.CollectPill (1, PlayerPrefManager.GetPillTip());
			Destroy (gameObject);
		}
	}
}
