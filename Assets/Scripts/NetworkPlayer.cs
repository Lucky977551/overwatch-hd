using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour {
	// Use this for initialization
	void Start () {
		if (photonView.isMine) {
			gameObject.GetComponent<PlayerController>().enabled = true;
			gameObject.transform.FindChild("Camera").gameObject.SetActive(true);
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}
}
