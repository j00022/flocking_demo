using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Controller : MonoBehaviour {

    GameObject settings;
    GameObject lazy_target;
    GameObject[] boids;
    public int total_boids;

	void Start () {
        total_boids = 5;
        boids = new GameObject[total_boids + 1];

        settings = GameObject.FindWithTag("SettingsUI");
        settings.SetActive(false);

        lazy_target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lazy_target.name = "lazy_target";
        lazy_target.GetComponent<SphereCollider>().isTrigger = true;
        lazy_target.AddComponent<Respawn_Controller>();
        lazy_target.transform.position = new Vector3(50, 50, 50);
        Destroy(lazy_target.GetComponent<MeshRenderer>());

        for (int i = 0; i < total_boids; i++) {
            boids[i] = Make_boid();
            boids[i].name = "boid" + i;
        }
        Lazy_flight();
    }
	
	public void Toggle_settings() {
        settings.SetActive(!settings.activeSelf);
    }
    
    public void Lazy_flight() {
        for (int i = 0; i < total_boids; i++) {
            boids[i].GetComponent<Boid_Controller>().NewTarget(lazy_target);
        }
    }

    GameObject Make_boid() {
        GameObject boid;
        boid = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        boid.tag = "Snitch";
        boid.GetComponent<Renderer>().material.color = Color.green;

        boid.AddComponent<Rigidbody>().useGravity = false;
        boid.AddComponent<Boid_Controller>();

        boid.transform.localScale += new Vector3(-.25f, -.25f, -.25f);

        float x = Random.Range(-100, 170);
        float y = Random.Range(30, 100);
        float z = Random.Range(-100, 100);

        boid.transform.position = new Vector3(x, y, z);

        return boid;
    }
}
