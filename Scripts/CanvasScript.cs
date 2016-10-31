using UnityEngine;

public class CanvasScript : MonoBehaviour {
    public GameObject prompt;
    public GameObject predecessor;
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (prompt == null)
                gameObject.SetActive(false);
            else
                prompt.SetActive(true);
        }
	}

    void OnEnable()
    {
        Time.timeScale = 0.0f;
        if(predecessor!=null)
            predecessor.SetActive(false);
    }

    void OnDisable()
    {
        Time.timeScale = 1.0f;
        if(predecessor!=null)
            predecessor.SetActive(true);
    }
}