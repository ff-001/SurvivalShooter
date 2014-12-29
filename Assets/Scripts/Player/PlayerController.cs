using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody player;
	int floor;
	float CamRayLength = 100f;
	PlayerHealth playerHealth;

	void Awake(){
		floor = LayerMask.GetMask(Tags.Ground);
		anim = GetComponent<Animator>();
		player = GetComponent<Rigidbody>();
		playerHealth = GetComponent<PlayerHealth>();
	}

//	void OnEnable()  
//		
//	{  
//		
//		EasyJoystick.On_JoystickMove += OnJoystickMove;  
//		
//		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;  
//
//		EasyJoystick.On_JoystickMove += OnJoystickForward;  
//		
//	}  
//
//	void OnDisable()  
//	{  
//		EasyJoystick.On_JoystickMove -= OnJoystickMove;  
//		EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;  
//		EasyJoystick.On_JoystickMove += OnJoystickForward;  
//	}    
//
////	移动摇杆结束  
//	
//	void OnJoystickMoveEnd(MovingJoystick move)  
//		
//	{  
//		
//		//停止时，角色恢复idle  
//		
//		if ((move.joystickName == "MoveJoystick")  && (anim != null)&& (playerHealth.PlayerDead == false))
//			
//		{  
//			
//			anim.SetBool("IsWalking",false);
//			
//		}  
//
//
//	} 
//
//	void OnJoystickForward(MovingJoystick move){
//		if ((move.joystickName == "ForwardJoystick") && (player != null)&& (playerHealth.PlayerDead == false))
//			
//		{  
//			
//			transform.LookAt(new Vector3(transform.position.x + move.joystickAxis.x, transform.position.y, transform.position.z + move.joystickAxis.y));  
//			
//		}  
//
//	}
//
//
//
//	void OnJoystickMove(MovingJoystick move)  
//		
//	{  
//		
//		if (move.joystickName != "MoveJoystick")  
//			
//		{  
//			
//			return;  
//			
//		}  
//		
//		
//		
//		//获取摇杆中心偏移的坐标  
//		
//		float joyPositionX = move.joystickAxis.x;  
//		
//		float joyPositionY = move.joystickAxis.y;  
//		
//		
//		
//		
//		
//		if ((joyPositionY != 0 || joyPositionX != 0) && (player != null)&& (playerHealth.PlayerDead == false))
//			
//		{  
//			
//			//设置角色的朝向（朝向当前坐标+摇杆偏移量）  
//			
////			transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));  
//			
//			//移动玩家的位置（按朝向位置移动）  
//			movement.Set(joyPositionX ,0f,joyPositionY);
//			movement = movement.normalized * speed * Time.deltaTime;
////			transform.Translate(Vector3.forward * Time.deltaTime * 5); 
//			player.MovePosition (transform.position + movement);
//			
//			//播放奔跑动画  
//			
//			anim.SetBool("IsWalking",true);
//			
//		}  
//		
//	}  

	void Move (float h, float v){
		movement.Set(h,0f,v);
		movement = movement.normalized * speed * Time.deltaTime;
		player.MovePosition (transform.position + movement);
	} 


	void FixedUpdate(){
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Move (h,v);
		Turning();
		Animating(h,v);
	}

	void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
		if(Physics.Raycast(camRay,out floorHit,CamRayLength,floor)){
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			player.MoveRotation(newRotation);
		}
	}


	void Animating(float h, float v){
		bool walking = h!= 0f || v != 0f;
		anim.SetBool("IsWalking",walking);
	}
}
