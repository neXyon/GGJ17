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
    Vector3 v = transform.position;

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
      v.x = (currentLane - LaneController.NUM_LANES / 2) * LaneController.LANE_DISTANCE;

      audioSource.pitch = LaneController.FREQUENCIES[currentLane];
    }

    GameObject lane = laneController.lanes[currentLane];

    float frequency = LaneController.FREQUENCIES[currentLane] * 2 * Mathf.PI;
    float amplitude = lane.GetComponent<Lane>().Amplitude * 0.25f;
    float phi = (lane.transform.position.z - v.z) * frequency;

    v.y = -amplitude * Mathf.Sin(phi);

    transform.position = v;
    transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(-amplitude * frequency * Mathf.Cos(phi), 1), Vector3.right);
  }
}
