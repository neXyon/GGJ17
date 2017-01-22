using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Lane : MonoBehaviour {
  /*private GameObject[] waves;

  private static int NUM_WAVES = 10;*/

  public float Frequency {
    get {
     return 1 / transform.localScale.y;
    }
    set {
      var v = transform.localScale;
      v.y = 1 / value;
      transform.localScale = v;
    }
  }

  public float Amplitude {
    get {
      return transform.localScale.z;
    }
    set {
      var v = transform.localScale;
      v.z = value;
      transform.localScale = v;
    }
  }

  public float Width {
    get {
      return transform.localScale.x;
    }
    set {
      var v = transform.localScale;
      v.x = value;
      transform.localScale = v;
    }
  }

  /*public GameObject wavePrefab;

  public Lane() {
  }*/

  private Level level;

  public void Start() {
    level = GetComponent<Level>();
    /*waves = new GameObject[NUM_WAVES];

    for (int i = 0; i < NUM_WAVES; i++) {
      waves[i] = GameObject.Instantiate(wavePrefab);
      waves[i].transform.SetParent(transform);
      waves[i].transform.localPosition = new Vector3(0, 0, i);
      waves[i].transform.localScale = Vector3.one;
    }*/
  }

  public void Update() {
    Vector3 v = transform.position;
    v.z -= Time.deltaTime * level.BPM / 60.0f * Level.SPEED_FACTOR;

    if(v.z < -transform.localScale.y) {
      v.z += transform.localScale.y;
    }

    transform.position = v;
  }
}
