using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPushka : MonoBehaviour {


    public Rigidbody2D bulletPrefab;
    public Transform bulletSpawn;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, (rotZ + 90 + 180));

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }

    public float speed = 20f;	
    void Fire()
    {
        Rigidbody2D bulletInstance = Instantiate(bulletPrefab,bulletSpawn.position, bulletSpawn.rotation) as Rigidbody2D;
        bulletInstance.velocity = bulletInstance.transform.up * speed;
    }
}
