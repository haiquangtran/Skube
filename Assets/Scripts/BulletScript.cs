using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

public class BulletScript : MonoBehaviour {
    public GameObject remainsCube;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == Constants.Tags.ENEMY_TAG)
        {
            //We have colided with an enemy 
            Instantiate(remainsCube, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Debug.Log("shooooootttt");
            Score.score += 100;
        }
        else if (other.collider.tag == Constants.Tags.POWERUP_TAG)
        {
            Destroy(other.gameObject);
            Score.score += 50;
            float turnOffBullets = Random.Range(0, 1);
            if(turnOffBullets <= 0.5)
            {
                FireFire.turnOffBullets = true;
                Debug.Log("bad power up");
            } else
            {
                Debug.Log("good power up");
                FireFire.doubleBullets = true;
            }
        }
    }
}
