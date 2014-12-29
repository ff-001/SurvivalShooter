using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float shootRate = 8;
	private float timer = 0;
	private ParticleSystem particleSystem;
	private LineRenderer lineRenderer;
	public int damagePerShot = 50;

	public PlayerController player;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Awake(){
		playerHealth = player.GetComponent<PlayerHealth>();
	}

	void Start () {
		particleSystem = this.GetComponentInChildren<ParticleSystem>();
		lineRenderer = this.renderer as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > 1 / shootRate){
			timer -= 1 / shootRate;
			if(playerHealth.hp > 0 ){
				Shoot();
			}
		}
	}

	void Shoot(){
		light.enabled = true;
		particleSystem.Play();

		this.lineRenderer.enabled = true;
		lineRenderer.SetPosition(0,transform.position);
		Ray ray = new Ray(transform.position,transform.forward);
		RaycastHit hitInfo;
		if(Physics.Raycast(ray,out hitInfo)){

			EnemyHealth enemyHealth = hitInfo.collider.GetComponent <EnemyHealth> ();
			
			// If the EnemyHealth component exist...
			if(enemyHealth != null)
			{
				// ... the enemy should take damage.
				enemyHealth.TakeDamage (damagePerShot,hitInfo.point);
			}
			lineRenderer.SetPosition(1,hitInfo.point);
		}else{
			lineRenderer.SetPosition(1,transform.position + transform.forward * 100);
		}
		audio.Play();
		Invoke("ClearEffect",0.05f);
	}

	void ClearEffect(){
		light.enabled = false;
		lineRenderer.enabled = false;
	}
}
