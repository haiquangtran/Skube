using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public static int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
	}
}
