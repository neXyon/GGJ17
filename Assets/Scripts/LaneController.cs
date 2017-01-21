using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LaneController : MonoBehaviour {
  private GameObject[] lanes;

  private static int NUM_LANES = 5;

  [SerializeField]
  private GameObject wavePrefab;

  LaneController() {
    lanes = new GameObject[NUM_LANES];
  }

  private void Start() {
    for(int i = 0; i < NUM_LANES; i++) {
      lanes[i] = GameObject.Instantiate(wavePrefab);
      Lane lane = lanes[i].GetComponent<Lane>();
      //lane.wavePrefab = wavePrefab;
      //Lane lane = lanes[0].GetComponent<Lane>();
      lane.Frequency = 1.5f;
      lane.Amplitude = 0.5f;
      lanes[i].transform.position += new Vector3((i - 2) * 2.0f, 0);
    }
  }

  private void Update() {
  }
}