using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Controller : MonoBehaviour {
    GameObject obj;

    public void Start() {
        obj = this.gameObject;
    }

    void OnCollisionEnter(Collision other) {
        Respawn();
    }

    public void OnTriggerEnter(Collider other) {
        Respawn();
    }

    //X = -100 - 170
    //Y = 20 - 100
    //Z = -100 - 100
    public void Respawn() {
        float x = Random.Range(-100, 170);
        float y = Random.Range(30, 100);
        float z = Random.Range(-100, 100);

        obj.transform.position = new Vector3(x, y, z);
    }
}
