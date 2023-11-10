using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	static public GameObject target; // the target that the camera should look at
	public AudioSource[] listOfSounds;
	public AudioSource sunAudioClip; 

	void Start () {
		if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("LookAtTarget target not specified. Defaulting to parent GameObject");
		}

		KeepOnlySunSound();
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
			transform.LookAt(target.transform);
	}

	void KeepOnlySunSound() {
		listOfSounds = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach( AudioSource audioS in listOfSounds) {
				if (audioS != sunAudioClip)
					audioS.Stop();
		}
		target.GetComponent<AudioSource>().Play();

	}

}
