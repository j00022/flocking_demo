using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
    //Player variables
    public GameObject player;
    public GameObject cam;
    public Rigidbody rb;
    public MeshRenderer mesh;

    private Vector3 offset;
    private float speed;

    //Camera variables
    public float speedHori = 2.5f;
    public float speedVert = 3.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start() {
        speed = 15;

        //Create player
        player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        player.gameObject.tag = "Player";
        player.transform.localScale += new Vector3(-.25f, -.25f, -.25f);
        player.transform.position = new Vector3(0, 5, 0);

        //Turn off player gravity and adjust drag
        rb = player.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.drag = 0.75f;

        //Turn off player shadow
        mesh = player.GetComponent<MeshRenderer>();
        mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        //Create and place camera
        cam = new GameObject();
        cam.AddComponent<Camera>();
        offset = new Vector3(0, 0, 0);
    }

    void FixedUpdate() {
        //Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = cam.transform.forward;
        Vector3 horizontal = cam.transform.right;
        rb.AddForce(forward * speed * moveVertical);
        rb.AddForce(horizontal * speed * moveHorizontal);

        //Camera movement
        cam.transform.position = player.transform.position + offset;
        yaw += speedHori * Input.GetAxis("Mouse X");
        pitch -= speedVert * Input.GetAxis("Mouse Y");

        cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

}