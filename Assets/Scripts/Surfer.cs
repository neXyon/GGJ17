using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surfer : MonoBehaviour {
  private int currentLane = 2;
  private LaneController laneController;
  private AudioSource audioSource;

	// Use this for initialization
	void Start () {
    laneController = GetComponent<LaneController>();
    audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
    int switchLane = -1;

		if(Input.GetKeyDown(KeyCode.A)) {
      switchLane = 0;
    }
    else if (Input.GetKeyDown(KeyCode.S)) {
      switchLane = 1;
    }
    else if (Input.GetKeyDown(KeyCode.D)) {
      switchLane = 2;
    }
    else if (Input.GetKeyDown(KeyCode.F)) {
      switchLane = 3;
    }
    else if (Input.GetKeyDown(KeyCode.Space)) {
      switchLane = 4;
    }

    if(switchLane != -1 && switchLane != currentLane) {
      currentLane = switchLane;
      Vector3 v = transform.position;
      v.x = (currentLane - 2) * 2.25f;
      transform.position = v;

      audioSource.pitch = LaneController.FREQUENCIES[currentLane];
    }
  }
}
