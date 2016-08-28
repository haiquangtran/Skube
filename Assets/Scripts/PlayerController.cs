using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PlayerController : MonoBehaviour {
    public AudioSource explosion_player;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {

        Debug.Log("PLAYER CUBE");
        if (other.collider.tag == Constants.Tags.ENEMY_TAG)
        {
            //We have colided with an enemy 
            Debug.Log("YOU LOOSE");
            explosion_player.Play();

            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
