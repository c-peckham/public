﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_by_boundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}
