using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    Rigidbody2D enemyRb;
    float timeBeforeChange;
    public float delay = 3.5f;
    public float speed = 2.5f;

	// Use this for initialization
	void Start () {
        enemyRb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        enemyRb.velocity = Vector2.right * speed;

        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
	}
}
