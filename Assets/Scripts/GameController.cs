using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {

    public TextMeshProUGUI BlockCount;

	// Use this for initialization
	void Start () {
        BlockCount.text = "Block Counts: " + "7";
	}

}
