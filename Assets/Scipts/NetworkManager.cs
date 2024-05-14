using UnityEngine;
using Photon.Pun;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
