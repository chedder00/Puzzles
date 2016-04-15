using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.position = Input.mousePosition;
	}
}
