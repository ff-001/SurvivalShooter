using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	EnemyHealth enemyHealth;
	PlayerHealth playerHealth;

	void Awake(){
		player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
		enemyHealth = this.GetComponent<EnemyHealth>();
		playerHealth = player.GetComponent<PlayerHealth>();
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if((enemyHealth.currentHealth > 0)&&(playerHealth.hp > 0)){
			nav.SetDestination(player.position);
		}else{
			nav.enabled = false;
		}
	}
}
