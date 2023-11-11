// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using UnityEngine;

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
		LookAtTarget.target = target;
		// divisão da escala do FOV por 2 para aproximar o objeto
		Camera.main.fieldOfView = 60 * target.transform.localScale.x / 2;

		StopSoundsFromOtherBodies();
		target.GetComponent<AudioSource>().Play();
	}

	void StopSoundsFromOtherBodies() {
		listOfSounds = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource audioS in listOfSounds) {
			audioS.Stop();
		}
	}
}
