using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Controller : MonoBehaviour {

    GameObject settings;

	// Use this for initialization
	void Start () {
        settings = GameObject.FindWithTag("SettingsUI");
        settings.SetActive(false);

    }
	
	public void Toggle_settings() {
        settings.SetActive(!settings.activeSelf);
    }


}
