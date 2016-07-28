using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {
	// Use this for initialization
	void Start() {
		Connect();
	}

	void OnGUI() {
		if (PhotonNetwork.inRoom) {
			GameObject.Find("ConnectionStatus").GetComponent<Text>().GetComponent<Text>().text = "Connected to room - " + PhotonNetwork.room.name;
		} else {
			GameObject.Find("ConnectionStatus").GetComponent<Text>().GetComponent<Text>().text = PhotonNetwork.connectionState.ToString();
		}
	}

	// Connect to master server (photon cloud)
	void Connect() {
		PhotonNetwork.ConnectUsingSettings(GameManager.VERSION);
	}
	
	void OnJoinedLobby() {
		Debug.Log("Joined lobby.");
		GameObject.Find("ConnectButton").GetComponent<Button>().interactable = true;
		GameObject.Find("CreateButton").GetComponent<Button>().interactable = true;
	}
	
	public void JoinRoom() {
		Debug.Log("Attempting to join room...");
		PhotonNetwork.JoinRoom(GameObject.Find("RoomName").GetComponentInChildren<Text>().text);
	}

	void OnJoinedRoom() {
		Debug.Log("Joined room " + PhotonNetwork.room.name + ".");

		SpawnPlayer();
	}

	void OnPhotonJoinRoomFailed() {
		Debug.Log("Failed to join room. Does it exist?");
		GameObject.Find("ConnectionStatus").GetComponent<Text>().GetComponent<Text>().text = "Failed to join";
	}

	public void CreateRoom() {
		Debug.Log("Creating new room for you...");
		PhotonNetwork.CreateRoom(GameObject.Find("RoomName").GetComponentInChildren<Text>().text.ToLower());
	}

	void OnPhotonPlayerDisconnected(PhotonPlayer other) {
		Debug.Log(other.name + " disconnected."); // seen when other disconnects
	}

	void OnDisconnectedFromPhoton() {
		Debug.Log("Disconnected from photon.");
		GameObject.Find("ConnectionStatus").GetComponent<Text>().text = "Disconnected";
	}

	public void SpawnPlayer() {
		PhotonNetwork.Instantiate("Moneky", GameObject.Find("Spawnpoint").transform.position, Quaternion.identity, 0);
	}
}
