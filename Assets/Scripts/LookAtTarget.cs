// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using UnityEngine;

public class LookAtTarget : MonoBehaviour {
	static public GameObject target;
	public AudioSource[] listDeAudios;
	public AudioSource audioSol;
	void Start () {
		if (target == null) 
		{
			target = gameObject;
			Debug.Log ("LookAtTarget target not specified. Defaulting to parent GameObject");
		}

    OuvirApenasAudioSol();
		audioSol = GetComponent<AudioSource>();
    audioSol.Play(0);
	}

	void Update () {
		if (target)
			transform.LookAt(target.transform);
	}

	void OuvirApenasAudioSol() {
		listDeAudios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach( AudioSource audioS in listDeAudios) {
				if (audioS != audioSol)
					audioS.Stop();
		}

	}
}
