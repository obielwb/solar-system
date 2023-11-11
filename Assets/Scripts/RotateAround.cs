// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using UnityEngine;

public class RotateAround : MonoBehaviour {
	public Transform target; 
	public int velocidade; 
	
	void Start() {
		if (target == null) 
		{
			target = this.gameObject.transform;
			Debug.Log ("RotateAround target not specified. Defaulting to parent GameObject");
		}
	}

	void Update () {
		transform.RotateAround(target.transform.position,
			target.transform.up,
            velocidade * Time.deltaTime
		);
	}
}
