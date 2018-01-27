using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEnemy : MonoBehaviour {



    public float Speed = 0;
    private Transform _playerTransform;
    private Transform _myTransform;
    private GameObject objSpawn;
    public GameObject exp;

    void Start()
    {

        var player = GameObject.FindGameObjectWithTag("Player");

        objSpawn = GameObject.FindGameObjectWithTag("Respawn");
        

        if (!player)
        {
            _playerTransform = gameObject.transform;
          
        }
        else
        {

            _playerTransform = player.transform;
        }
        _myTransform = this.transform;
    }
    void Update()
    {

        if (_playerTransform != null)
        {
            var moveAmount = Speed * Time.deltaTime;
            _myTransform.position = Vector2.MoveTowards(_myTransform.position,
                                                        _playerTransform.position, moveAmount);

            // get the angle
            Vector3 norTar = (_playerTransform.position - _myTransform.position).normalized;
            float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
            // rotate to angle
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(0, 0, angle - 90);
            transform.rotation = rotation;
        }
 
    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            objSpawn.GetComponent<scriptSpawn>().AddScore();

            GameObject explosion = Instantiate(exp, gameObject.transform.position, Quaternion.identity);
             Destroy(explosion,1f);
            Destroy(gameObject);
           // score.text = "Score " + 
           

        }
    }
}
