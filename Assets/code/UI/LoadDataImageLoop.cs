using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataImageLoop : MonoBehaviour {


	// [SerializeField]
	// RectTransform prefab_my = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3(0, 0, -2));
	}
}
