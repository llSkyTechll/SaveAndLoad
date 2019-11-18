using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptController : MonoBehaviour {

	// Use this for initialization
	public void NextScene() {
        SceneController.sceneControl.NextScene();
	}
	
	// Update is called once per frame
	public void PreviousScene() {
        SceneController.sceneControl.PreviousScene();
    }
}
