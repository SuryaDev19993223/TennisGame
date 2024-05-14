using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadCharactersMultiplayer : MonoBehaviour {
	
	public Transform player1Position;
	public Transform Player2Position;
	
	public Animator comboLabel;
	public Text comboNumberLabel;
	public Animator swipeLabel;
	public Animator shootTip;
	public Animator startPanel;
	public GameObject gamePanel;
	public GameObject scoreTexts;
	public GameObject matchLabel;
	public CameraMovement cameraMovement;
	
	public bool playerOnly;
    
	GameObject playerPrefab;
	GameObject opponentPrefab;
	
	void Awake(){
		playerPrefab = Resources.Load<GameObject>("Character prefabs/Player base prefab");
		opponentPrefab = Resources.Load<GameObject>("Character prefabs/Opponent base prefab");
		
		if(playerPrefab == null || opponentPrefab == null){
			Debug.LogWarning("No player/opponent prefab in resources");
		}
		else{
			GameObject newPlayer = Instantiate(playerPrefab, player1Position.position, player1Position.rotation);
			Player player = newPlayer.GetComponent<Player>();
			
			GameManager manager = FindObjectOfType<GameManager>();
			manager.player = player;
			
			if(!playerOnly){
				GameObject newOpponent = Instantiate(opponentPrefab, Player2Position.position, Player2Position.rotation);
				Opponent opponent = newOpponent.GetComponent<Opponent>();
				
				manager.opponent = opponent;
			
				opponent.player = newPlayer.transform;
				opponent.lookAt = newPlayer.transform;
				
				player.opponent = opponent.transform;
			}
			
			Opponent op = FindObjectOfType<Opponent>();
			Transform opponentTransform = op.transform;
			player.lookAt = opponentTransform;
			
			if(playerOnly){
				player.opponent = opponentTransform;
				
				op.lookAt = player.transform;
				op.player = player.transform;
			}
			
			cameraMovement.camTarget = player.transform;
			
			AssignPlayerReferences(player);
		}
	}
	
	void AssignPlayerReferences(Player player){
		player.comboLabel = comboLabel;
		player.comboNumberLabel = comboNumberLabel;
		player.swipeLabel = swipeLabel;
		player.shootTip = shootTip;
		player.startPanel = startPanel;
		player.gamePanel = gamePanel;
		player.scoreTexts = scoreTexts;
		player.matchLabel = matchLabel;
		player.cameraMovement = cameraMovement;
	}
}
