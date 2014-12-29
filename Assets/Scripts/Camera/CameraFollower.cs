using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	public KeyCode cameraUp;
	public KeyCode cameraDown;

	Vector3 offset;
	
	void Start(){
		offset = transform.position - target.position;
	}

	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position,targetCamPos,smoothing * Time.deltaTime);

		if(Input.GetKeyDown(cameraUp)){
			camera.orthographic = true;
			if(camera.orthographicSize <= 11){
				camera.orthographicSize += 1;
			}
		}
		if(Input.GetKeyDown(cameraDown)){
			camera.orthographic = true;
			if(camera.orthographicSize >= 1){
				camera.orthographicSize -= 1;
			}
		}
	}
	

}
