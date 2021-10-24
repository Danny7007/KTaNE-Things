using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour {

	public Color[] colors = new Color[16];
	// Use this for initialization
	void Start () {
        for (int ix = 0; ix < 16; ix++)
        {
			colors[ix] = Color.HSVToRGB((float)ix / 16, 1, 1);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
