// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using UnityEngine;

public class ChangeLookAtTarget : MonoBehaviour {
	public GameObject target; // the target that the camera should look at
    public AudioSource[] listDeSons;

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

    ImpedirSonsDeOutrosCorpos();
		target.GetComponent<AudioSource>().Play();
	}

	void ImpedirSonsDeOutrosCorpos () {
			listDeSons = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
			foreach( AudioSource audioS in listDeSons) {
					audioS.Stop();
			}
	}
}
