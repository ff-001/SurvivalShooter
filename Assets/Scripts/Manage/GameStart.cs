using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public void LevelSelect(int level){
		PlayerPrefs.SetInt ("level",level);
		Application.LoadLevel("main");
	}
}
