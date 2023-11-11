// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using UnityEngine;

public class LookAtTarget : MonoBehaviour {
	static public GameObject target;
	public AudioSource audioSol; 

	void Start () {
		if (target == null) 
		{
			target = gameObject;
			Debug.Log ("LookAtTarget target not specified. Defaulting to parent GameObject");
		}

        OuvirApenasAudioSol();
	}

	void Update () {
		if (target)
			transform.LookAt(target.transform);
	}

	void OuvirApenasAudioSol() {
		var todosOsAudios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource audio in todosOsAudios) {
			if (audio != audioSol)
				audio.Stop();
		}

		target.GetComponent<AudioSource>().Play();
	}
}
