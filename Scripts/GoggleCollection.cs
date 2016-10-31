using UnityEngine;
using System.Collections;

public class GoggleCollection : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Barrier" || coll.gameObject.name=="Eye") {
            GameManager.gm.CollectGoggle (1,PlayerPrefManager.GetGoggleTip());
			Destroy (gameObject);
		}
	}
}
