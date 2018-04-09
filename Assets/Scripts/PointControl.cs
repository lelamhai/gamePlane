using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointControl : MonoBehaviour {
    private Text PointUI;
    // Use this for initialization
    void Start () {
        PointUI = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        PointUI.text = "Point: " + Singleton.Instance.Point;
    }
}
