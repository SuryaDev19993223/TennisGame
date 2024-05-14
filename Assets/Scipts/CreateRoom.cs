using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    public GameObject roomName;
    public TMP_Text text;

    public void createRoom()
    {
        PhotonNetwork.CreateRoom(roomName.GetComponent<TMP_InputField>().text);
    }
    public override void OnCreatedRoom()
    {
        text.text = "Room Created";
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        text.text = "Room Creation Failed";
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
