using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour {
	// Use this for initialization
	void Start () {
		if (photonView.isMine) {
			gameObject.GetComponent<PlayerController>().enabled = true;
			gameObject.transform.FindChild("Camera").gameObject.SetActive(true);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			// Network player, receive data
			this.transform.position = (Vector3)stream.ReceiveNext();
			this.transform.rotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
