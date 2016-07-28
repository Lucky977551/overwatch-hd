using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour {
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;

	// Use this for initialization
	void Start() {
		if (photonView.isMine) {
			gameObject.GetComponent<PlayerController>().enabled = true;
			gameObject.transform.FindChild("Camera").gameObject.SetActive(true);
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}

	void Update() {
		if (!photonView.isMine) {
			transform.position = Vector3.Lerp(transform.position, correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, correctPlayerRot, Time.deltaTime * 5);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);

		} else {
			// Network player, receive data
			correctPlayerPos = (Vector3)stream.ReceiveNext();
			correctPlayerRot = (Quaternion)stream.ReceiveNext();
		}
	}
}
