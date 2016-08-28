using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Scripts;

public class BulletScript : MonoBehaviour {
    public GameObject remainsCube;
    public AudioSource explosion_astroid;
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
            explosion_astroid.Play();
            Score.score += 100;
        }
        else if (other.collider.tag == Constants.Tags.POWERUP_TAG)
        {
            Destroy(other.gameObject);
            Score.score += 50;

            int turnOffBullets = Random.Range(0, 3);
            if(turnOffBullets == 1)
            {
                FireFire.turnOffBullets = true;
                Debug.Log("bad power up");
            }
            else if (turnOffBullets == 2)
            {
                Debug.Log("good power up");
                FireFire.doubleBullets = true;
            }
            else
            {
                SceneManager.LoadScene("NPEscreen");       
            }
        }
    }
}
