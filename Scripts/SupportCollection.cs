using UnityEngine;
using System.Collections;

public class SupportCollection : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Barrier" || coll.gameObject.name=="Eye") {
            GameManager.gm.CollectSupport (1, PlayerPrefManager.GetSupportTip());
			Destroy (gameObject);
		}
	}
}
