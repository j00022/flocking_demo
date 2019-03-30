using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid_Controller : MonoBehaviour {

    public float speed = 30;
    public float turn_speed = 100;
    public GameObject target;
    public GameObject boid;

    public void Start() {
        boid = this.gameObject;
    }

    void Update () {
        Follow(boid, target);
	}

    public void Follow(GameObject boid, GameObject target) {
        Vector3 direction = target.transform.position - boid.transform.position;
        Quaternion newDir = Quaternion.LookRotation(direction);
        boid.transform.rotation = Quaternion.RotateTowards(boid.transform.rotation, newDir, turn_speed * Time.deltaTime);
        boid.transform.position += boid.transform.forward * speed * Time.deltaTime;
    }

    public void NewTarget(GameObject newTarget) {
        target = newTarget;
    }
}
