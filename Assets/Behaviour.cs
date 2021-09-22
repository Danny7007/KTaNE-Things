using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Behaviour : MonoBehaviour {
	// Use this for initialization
	void Start () {
		CreateCruelBinary();
	}

	void CreateCruelBinary(int columnCount = 4)
    {
		var cBin = new CruelBinary();
		cBin.GenerateAllAnswers();
		Debug.Log(cBin.FormatTable(columnCount));
		GUIUtility.systemCopyBuffer = cBin.FormatTable(columnCount);
	}
	void CreateInfiniteLoop(int columnCount = 2)
    {
		var iLoop = new InfiniteLoop();
		iLoop.GenerateAllAnswers();
		Debug.Log(iLoop.FormatTable(columnCount));
    }
}
