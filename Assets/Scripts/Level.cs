using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
  enum Elements { Empty, Obstacle };

  public static float MAX_BPM = 160.0f;
  public static float MIN_BPM = 60.0f;

  public static int BEATS_AHEAD_GENERATION = 30;
  public static float SPEED_FACTOR = 5.0f;

  private static float OBSTACLE_PROBABILITY = 0.8f;

  public float BPM { get; set; }

  private float currentBeat;

  private Queue<Elements>[] lanes;
  public List<GameObject> objects;

  public GameObject obstaclePrefab;

  private void GenerateRow() {
    int empty_lane = Random.Range(0, LaneController.NUM_LANES);

    float z = lanes[0].Count * Level.SPEED_FACTOR - currentBeat * BPM / 60.0f * Level.SPEED_FACTOR;
    Debug.Log(z);
    
    for (int i = 0; i < LaneController.NUM_LANES; i++) {
      Elements element = Elements.Empty;

      if (i != empty_lane) {
        if(Random.value < OBSTACLE_PROBABILITY) {
          element = Elements.Obstacle;
        }
      }

      lanes[i].Enqueue(element);

      if(element == Elements.Obstacle) {
        GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
        objects.Add(obstacle);
        float x = LaneController.LANE_DISTANCE * (i - LaneController.NUM_LANES / 2);
        obstacle.transform.position = new Vector3(x, 0, z);
      }
    }
  }

  private void DropRow() {
    for (int i = 0; i < LaneController.NUM_LANES; i++) {
      lanes[i].Dequeue();
    }
  }

  // Use this for initialization
  void Start () {
    currentBeat = -4;

    BPM = MIN_BPM;// Mathf.Floor(Random.value * (MAX_BPM - MIN_BPM)) + MIN_BPM;

    lanes = new Queue<Elements>[LaneController.NUM_LANES];
    objects = new List<GameObject>();

    for(int i = 0; i < LaneController.NUM_LANES; i++) {
      lanes[i] = new Queue<Elements>();
    }

    for(int i = 0; i < BEATS_AHEAD_GENERATION; i++) {
      GenerateRow();
    }
	}
	
	// Update is called once per frame
	void Update () {
    currentBeat += Time.deltaTime * BPM / 60.0f;

    if(currentBeat > 1) {
      DropRow();
      currentBeat -= 1;
      GenerateRow();
    }

    // TODO: check player collision
    
    for (int i = objects.Count - 1; i >= 0; i--) {
      Vector3 v = objects[i].transform.position;
      v.z -= Time.deltaTime * BPM / 60.0f * Level.SPEED_FACTOR;

      if(v.z < 0) {
        Destroy(objects[i]);
        objects.RemoveAt(i);
      }
      else {
        objects[i].transform.position = v;
      }
    }
	}
}
