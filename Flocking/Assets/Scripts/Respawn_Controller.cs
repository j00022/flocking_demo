using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Controller : MonoBehaviour {
    GameObject obj;
    GameObject spawn_me;

    public void Start() {
        obj = this.gameObject;
    }

    void OnCollisionEnter(Collision other) {
        if (obj.tag == "Terrain")
            spawn_me= other.gameObject;
        else
            spawn_me = obj;
        Respawn();
        
    }

    public void OnTriggerEnter(Collider other) {
        if (obj.tag == "Terrain")
            spawn_me = other.gameObject;
        else
            spawn_me = obj;
        Respawn();
    }

    //X = -100 - 170
    //Y = 20 - 100
    //Z = -100 - 100
    public void Respawn() {
        float x = Random.Range(-100, 170);
        float y = Random.Range(30, 100);
        float z = Random.Range(-100, 100);

        spawn_me.transform.position = new Vector3(x, y, z);
    }
}
