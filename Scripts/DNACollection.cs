using UnityEngine;
using System.Collections;

public class DNACollection : MonoBehaviour {
    public GameObject storeTipPanel;
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Barrier" || coll.gameObject.name=="Eye") {
            GameManager.gm.CollectDNA(1, PlayerPrefManager.GetStoreTip());
			Destroy (gameObject);
		}
	}
}