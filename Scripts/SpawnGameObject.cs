using UnityEngine;
using System.Collections;

public class SpawnGameObject : MonoBehaviour {
    // public variables
    public float secondsBetweenSpawning;
	public Transform topLeftCorner;
	public Transform downRightCorner;
    public GameObject[] spawnObjects; // what prefabs to spawn

    private float timeToSpawn;

    // Use this for initialization
    void Start()
    {
        // determine when to spawn the next object
        timeToSpawn = secondsBetweenSpawning;
    }

    // Update is called once per frame
    void Update()
    {
		switch (GameManager.gm.gameState) {
		case GameManager.gameStates.Play:
			if (Time.time>=timeToSpawn) {
				// Spawn the game object through function below
				makeThingToSpawn ();

				// determine the next time to spawn the object
				timeToSpawn += secondsBetweenSpawning;
			}
			break;
		default:
                if (Time.time >= timeToSpawn)
                    timeToSpawn += secondsBetweenSpawning;
			break;
		}   
    }

    void makeThingToSpawn()
    {
		// determine which object to spawn
		int objectToSpawn = Random.Range(0, spawnObjects.Length);

		if (spawnObjects [objectToSpawn] != null) {
			Vector2 spawnPosition;
			int dir = Random.Range(0, 3);
			switch(dir)
			{
			case 0:
				spawnPosition.y = topLeftCorner.position.y;
				spawnPosition.x = Random.Range(topLeftCorner.position.x, downRightCorner.position.x);
				break;
			case 1:
				spawnPosition.y = downRightCorner.position.y;
				spawnPosition.x = Random.Range(topLeftCorner.position.x, downRightCorner.position.x);
				break;
			case 2:
				spawnPosition.x = downRightCorner.position.x;
				spawnPosition.y = Random.Range(downRightCorner.position.y, topLeftCorner.position.y);
				break;
			default:
				spawnPosition.x = topLeftCorner.position.x;
				spawnPosition.y = Random.Range(downRightCorner.position.y, topLeftCorner.position.y);
				break;
			}
			// actually spawn the game object
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

			// make the parent the spawner so hierarchy doesn't get super messy
			spawnedObject.transform.parent = gameObject.transform;
		}
    }
}
