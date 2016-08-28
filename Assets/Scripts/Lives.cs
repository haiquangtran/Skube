using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour {
    public static int NumberOfLives;
    public Text LivesText;

	// Use this for initialization
	void Start () {
        LivesText = GetComponent<Text>();
        NumberOfLives = 3;
    }
	
	// Update is called once per frame
	void Update () {
        LivesText.text = "Lives: " + NumberOfLives;
	}
}
