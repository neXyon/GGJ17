using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
  [SerializeField]
  private float timeBetweenObstacles;

  [SerializeField]
  private float obstacleProbability;

  private float lastObstacleTime;

  public void Update() {
    if (Time.time - lastObstacleTime > timeBetweenObstacles) {

    }
  }
}
