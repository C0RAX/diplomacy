using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour {

    CursorLockMode wantedMode = CursorLockMode.Confined;

    // Apply requested cursor state
    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }
	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (transform.position.z >= 1f)
            {
                GetComponent<Transform>().position = new Vector3(Mathf.Clamp(transform.position.x, -6.6f, 6.6f), Mathf.Clamp(transform.position.y + .2f * Time.deltaTime * 10, -2f, 9.61f), Mathf.Clamp(transform.position.z - .6f, 0f, 20f));
            }

            if (transform.eulerAngles.x >= -30)
            {
                //transform.Rotate(-2, 0, 0);
                //transform.rotation = Quaternion.Euler(Mathf.Clamp(transform.eulerAngles.x - 2f * Time.deltaTime * 10, -30f,0f), transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (transform.position.z <= 20f)
            {
                GetComponent<Transform>().position = new Vector3(Mathf.Clamp(transform.position.x, -6.6f, 6.6f), Mathf.Clamp(transform.position.y - .2f * Time.deltaTime * 10, -2f, 9.61f), Mathf.Clamp(transform.position.z + .6f, 0f, 20f));
            }

            if (transform.eulerAngles.x <= 0)
            {
                //transform.Rotate(2, 0, 0);
                //transform.rotation = Quaternion.Euler(Mathf.Clamp(transform.eulerAngles.x + 2f * Time.deltaTime * 10, -30f, 0f), transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }

    private void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");

        GetComponent<Transform>().position = new Vector3(
            Mathf.Clamp(transform.position.x - horAxis * Time.deltaTime * 10, -6.61f, 6.61f ), 
            Mathf.Clamp(transform.position.y + verAxis * Time.deltaTime * 10, -3f, 9.61f),
            Mathf.Clamp(transform.position.z,0,20f));
    }
}
