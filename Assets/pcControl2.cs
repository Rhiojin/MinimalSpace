using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcControl2 : MonoBehaviour {

    public Rigidbody2D rig;


	// Use this for initialization
	void Start () {
        Thrust();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Thrust();
        }
    }

    public void Thrust() {
        rig.AddForce(transform.right * 500);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("planet")) {
            transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("planet")) {
            transform.SetParent(null);
        }
    }

}
