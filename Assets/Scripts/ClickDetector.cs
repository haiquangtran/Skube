using UnityEngine;
using System.Collections;

public class ClickDetector : MonoBehaviour {
    public int button = 0;
    public float clickSize = 50; // this might be too small


    // Use this for initialization
    void Start () {
	
	}
    
    void ClickHappened()
    {
        Debug.Log("CLICK!");
    }

    Vector3 pos;
    void Update()
    {
        if (Input.GetMouseButtonDown(button))
            pos = Input.mousePosition;

        if (Input.GetMouseButtonUp(button))
        {
            var delta = Input.mousePosition - pos;
            if (delta.sqrMagnitude < clickSize * clickSize)
                ClickHappened();
        }
    }
}
