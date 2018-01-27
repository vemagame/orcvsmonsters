using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTank : MonoBehaviour {
   
    public float speed = 1f;
    public GameObject txtgameover;
    public GameObject exp;
	// Use this for initialization
	void Start () {
		
	}
    public int rotationOffset = 0;
	// Update is called once per frame
	void Update () {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.25f,5.25f),Mathf.Clamp(transform.position.y, -2.85f,2.85f), transform.position.z);


        if (move != Vector3.zero)
        {
            float heading = Mathf.Atan2(move.x, move.y);
            //Debug.Log(heading * Mathf.Rad2Deg);
            transform.rotation = Quaternion.Euler(0f, 0f, -heading * Mathf.Rad2Deg);
        }
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            GameObject explosion = Instantiate(exp, gameObject.transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
           

            txtgameover.active = true;
            Time.timeScale = 1;
        }
    }


}
