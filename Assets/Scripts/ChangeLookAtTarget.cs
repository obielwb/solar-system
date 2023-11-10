using UnityEngine;
using System.Collections;

public class ChangeLookAtTarget : MonoBehaviour {

	public GameObject target; // the target that the camera should look at
	public AudioSource[] listOfSounds;

	void Start() {
		if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("ChangeLookAtTarget target not specified. Defaulting to parent GameObject");
		}
	}

	void OnMouseDown () {
		// change the target of the LookAtTarget script to be this gameobject.
		LookAtTarget.target = target;
		Camera.main.fieldOfView = 60*target.transform.localScale.x;

		StopSoundsFromOtherBodies();
		target.GetComponent<AudioSource>().Play();
	}
	void StopSoundsFromOtherBodies() {
			listOfSounds = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
			foreach( AudioSource audioS in listOfSounds) {
					audioS.Stop();
			}
	}
}
