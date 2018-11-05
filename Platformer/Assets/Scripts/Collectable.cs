using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

    public static int collectableQuantity = 0;
    //public Text collectableText;
    Text collectableText;

    ParticleSystem collectableParticle;
    AudioSource collectableAudio;

	// Use this for initialization
	void Start () {
        collectableParticle = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        collectableAudio = GetComponentInParent<AudioSource>();
        collectableText = GameObject.Find("CollectableQuantityText").GetComponent<Text>();
        //collectableText = GameObject.FindObjectOfType(Text);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collectableParticle.transform.position = transform.position;
            collectableParticle.Play();
            collectableAudio.Play();
            gameObject.SetActive(false);
            collectableQuantity++;
            collectableText.text = collectableQuantity.ToString();
        }
    }
}
