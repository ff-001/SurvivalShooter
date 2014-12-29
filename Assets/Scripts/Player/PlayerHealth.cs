using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float hp = 100;
	public float smoothing = 5;
	public Slider healthSlider;
	private Animator anim;
	private PlayerController playerController;
	private SkinnedMeshRenderer bodyRenderer;
	public bool PlayerDead;
	GameObject Elight;
	public Color color;


	void Awake(){
		PlayerDead = false;
		anim = this.GetComponent<Animator>();
		playerController = this.GetComponent<PlayerController>();
		Elight = GameObject.FindGameObjectWithTag("Light");
		bodyRenderer = transform.Find(Tags.Player).renderer as SkinnedMeshRenderer;
	}



	void Update(){
//		if(Input.GetMouseButtonDown(0)){
//			TakeDamage(30);
//		}
		Elight.light.color = Color.Lerp(Elight.light.color,color,0.05f*Time.deltaTime);
		bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color,Color.white,smoothing*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Heart"){
			if(hp<70){
				hp += 30;
			}else{
				hp = 100;
			}
			Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "Damn"){
			Elight.light.color = Color.black;
			Destroy(other.gameObject);
		}
	}

	public void TakeDamage(float damage){
		if (hp <= 0) return;
		this.hp -= damage;
		audio.Play();
		healthSlider.value = this.hp;
		bodyRenderer.material.color = Color.red;
		if(this.hp <= 0){
			anim.SetBool("Die",true);
			Death();
		}
	}

	public void Death(){
		PlayerDead = true;
		playerController.enabled = false;
	}
}
