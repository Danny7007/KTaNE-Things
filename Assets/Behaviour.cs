using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CreateInfiniteLoop();
	}
	
	void CreateCruelBinary()
    {
		var cBin = new CruelBinary();
		cBin.GenerateAllAnswers();
		Debug.Log(cBin.FormatTable(4));
	}
	void CreateInfiniteLoop()
    {
		var iLoop = new InfiniteLoop();
		iLoop.GenerateAllAnswers();
		Debug.Log(iLoop.FormatTable(2));
    }
}
