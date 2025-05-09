using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class networkController : MonoBehaviour
{
    [Header("Go")]
    public GameObject loginGO;
    public GameObject partidaGO;
    public GameObject informactionGO;
    
    [Header("Player")]
    public InputField playerNameInput;
    string playerNameTemp;
    public GameObject myPlayer;

    [Header("Room")]
    public InputField roomName;
    
    [Header("inforMaction")]
    public Text Info;
    public Text TextInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion("sp");

        playerNameTemp = "Player" + Random.Range(1000,9999);
        playerNameInput.text = playerNameTemp;

        roomName.text = "Room" + Random.Range(1000,9999);

        loginGO.SetActive(true);
        partidaGO.SetActive(false);
        informactionGO.SetActive(false);

    }

    public void BtLogin()
    {
        if (playerNameInput.text != "")
        {
            PhotonNetwork.NickName = playerNameInput.text;
            Debug.Log("Usuario foi conectado com sucesso " + PhotonNetwork.NickName);
        }
        else
        {
            PhotonNetwork.NickName = playerNameTemp;
            Debug.Log("Usuario foi conectado com sucesso " + PhotonNetwork.NickName);
        }

        PhotonNetwork.ConnectUsingSettings();
        //partidaGO.gameObject.SetActive(true);

    }

    public void BtBuscarPartidaRapida()
    {
        PhotonNetwork.JoinLobby();
    }

    public void BtCriarSala()
    {
        string roomNameTemp = roomName.text;
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 20 };

    }

    public override void OnConnected()
    {
        Debug.Log("Conectado ao Servidor");
    }

    public override void OnConnectedToMaster()
    {
        
    }

}
