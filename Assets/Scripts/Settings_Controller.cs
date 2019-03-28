using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Controller : MonoBehaviour {

    public GameObject settings;

	// Use this for initialization
	void Start () {
        if (settings == null) {
            settings = GameObject.FindWithTag("SettingsUI");
            settings.SetActive(false);
        }
    }
	
	public void Toggle_settings() {
        settings.SetActive(!settings.activeSelf);
    }
}
