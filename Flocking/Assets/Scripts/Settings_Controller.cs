using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Controller : MonoBehaviour {

    GameObject settings;
    GameObject player;
    GameObject lazy_target;
    GameObject[] boids;
    public int total_boids;

    void Start() {
        total_boids = 10;
        boids = new GameObject[total_boids + 1];

        settings = GameObject.FindWithTag("SettingsUI");
        settings.SetActive(false);

        //Create Lazy_Target
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

    GameObject Make_boid() {
        GameObject boid;
        boid = Instantiate(Resources.Load("Missil_01")) as GameObject;
        boid.tag = "Snitch";
        boid.AddComponent<Rigidbody>().useGravity = false;
        boid.AddComponent<Boid_Controller>();
        boid.AddComponent<BoxCollider>();

        float x = Random.Range(-100, 170);
        float y = Random.Range(30, 100);
        float z = Random.Range(-100, 100);

        boid.transform.position = new Vector3(x, y, z);

        return boid;
    }

    public void Toggle_settings() {
        settings.SetActive(!settings.activeSelf);
    }

    public void Close_settings() {
        settings.SetActive(false);
    }

    public void Lazy_flight() {
        for (int i = 0; i < total_boids; i++) {
            boids[i].GetComponent<Boid_Controller>().NewTarget(lazy_target);
        }
    }

    public void Follow_the_leader() {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player.name);
        for (int i = 0; i < total_boids; i++) {
            boids[i].GetComponent<Boid_Controller>().NewTarget(player);
        }
    }

    public void OnValueChange() {
        Dropdown uiDropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        int option = uiDropdown.value;
        switch (option) {
            case 0: //Lazy flight
                Lazy_flight();
                break;
            case 1: //Circle a tree
                Debug.Log("not yet implemented");
                break;
            case 2: //Follow the leader
                Follow_the_leader();
                break;
        }
    }
}
