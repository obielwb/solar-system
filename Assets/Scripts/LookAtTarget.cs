using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	static public GameObject target;
	public AudioSource[] listOfSounds;
	public AudioSource sunAudioClip; 

	void Start () {
		if (target == null) 
		{
			target = gameObject;
			Debug.Log ("LookAtTarget target not specified. Defaulting to parent GameObject");
		}

		KeepOnlySunSound();
	}

	void Update () {
		if (target)
			transform.LookAt(target.transform);
	}

	void KeepOnlySunSound() {
		listOfSounds = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource audio in listOfSounds) {
				if (audio != sunAudioClip)
					audio.Stop();
		}
		target.GetComponent<AudioSource>().Play();
	}
}
