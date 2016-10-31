using UnityEngine;
using System.Collections;

public class ShieldCollection : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Barrier" || coll.gameObject.name=="Eye") {
            GameManager.gm.CollectShield(1,PlayerPrefManager.GetSupportTip());
			Destroy (gameObject);
		}
	}
}
