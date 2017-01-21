using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
  [SerializeField]
  private GameObject playerPrefab;

  private Player player;

  public void Start() {
    player = GameObject.Instantiate(playerPrefab).GetComponent<Player>();
  }
}
