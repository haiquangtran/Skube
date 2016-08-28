using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ErrorText : MonoBehaviour {

    public Text npeText;
    public static string errorText;

    // Use this for initialization
    void Start () {
        npeText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        npeText.text = errorText;
    }
}
