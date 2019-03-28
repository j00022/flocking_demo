using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Controller : MonoBehaviour {
    public void ExitNow() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }
}
