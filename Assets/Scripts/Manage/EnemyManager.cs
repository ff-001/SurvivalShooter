using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject enemy;                // The enemy prefab to be spawned.
	float spawnTime = 6f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public int level = 3;
	private float timer = 0;
	bool cancel;


	void Awake(){
		level = PlayerPrefs.GetInt ("level");

	}
	
	void Start ()
	{

		switch(level){
			// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		case 1:
			InvokeRepeating ("SpawnEasy", 6f, 6f);
			break;
		case 2:
			InvokeRepeating ("SpawnNormal", 3f, 3f);
			break;
		case 3:
			InvokeRepeating ("SpawnHard", 1f, 1f);
			break;
		}
	}

	void Update () {
//		Debug.Log(timer);
		timer += Time.deltaTime;
		if(timer > 10){

			cancel = !cancel;
			Debug.Log(cancel);
			timer = 0;
		}

	}

	void SpawnEasy ()
	{
		// If the player has no health left...
		if((playerHealth.hp <= 0f)||(cancel == true))
		{
			// ... exit the function.
			return;
		}
		
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, 1);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		if(enemy != null){
			Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}

	}

	void SpawnNormal ()
	{
		// If the player has no health left...
		if((playerHealth.hp <= 0f)||(cancel == true))
		{
			// ... exit the function.
			return;
		}
		
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, 2);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		if(enemy != null){
			Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}

	}

	void SpawnHard ()
	{
		// If the player has no health left...
		if((playerHealth.hp <= 0f)||(cancel == true))
		{
			// ... exit the function.
			return;
		}
		
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, 3);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		if(enemy != null){
			Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}

	}

}