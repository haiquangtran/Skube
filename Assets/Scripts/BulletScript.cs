using UnityEngine;
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
        }
    }
}
