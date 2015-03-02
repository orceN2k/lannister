using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
		
	public void ChangeToScene(string sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
