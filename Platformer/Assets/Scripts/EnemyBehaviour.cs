using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    Rigidbody2D enemyRb;
    SpriteRenderer enemySpriteRenderer;
    Animator enemyAnimator;
    float timeBeforeChange;
    public float delay = 3.5f;
    public float speed = 2.5f;

    ParticleSystem enemyParticle;

	// Use this for initialization
	void Start () {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();

        enemyParticle = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {

        enemyRb.velocity = Vector2.right * speed;

        if (speed > 0)
            enemySpriteRenderer.flipX = false;
        else if (speed < 0)
            enemySpriteRenderer.flipX = true;

        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(transform.position.y + .03f < collision.transform.position.y)
            {
                //enemyParticle.transform.position = new Vector3(transform.position.x, transform.position.y +1.55f, transform.position.z); 
                enemyParticle.transform.position = new Vector2(transform.position.x, transform.position.y + 1.55f);
                enemyParticle.Play();
                enemyAnimator.SetBool("isDead", true);
            }
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
