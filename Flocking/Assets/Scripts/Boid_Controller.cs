using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid_Controller : MonoBehaviour {

    public float speed = 1000;
    public GameObject target;
    public GameObject boid;

    public void Start() {
        boid = this.gameObject;
    }

    // Update is called once per frame
    void Update () {
        Follow(boid, target);
	}

    public void Follow(GameObject boid, GameObject target) {
        //Get direction
        Vector3 direction = (target.transform.position - boid.transform.position).normalized;
        Vector3 newDir = Vector3.RotateTowards(boid.transform.forward, direction, 1.5f * Time.deltaTime, 0f);
        //Rotate
        boid.transform.rotation = Quaternion.LookRotation(newDir);

        boid.GetComponent<Rigidbody>().velocity = boid.transform.forward * speed * Time.smoothDeltaTime;
    }

    public void NewTarget(GameObject newTarget) {
        target = newTarget;
    }
}
