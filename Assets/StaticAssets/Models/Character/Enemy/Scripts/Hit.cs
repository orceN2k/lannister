﻿using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public float killDelay = 2f;

	void Start() { 
		//Destroy this component only after killDelay-second passed 
		Destroy( this, killDelay ); 
	} 
}
