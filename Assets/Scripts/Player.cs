using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

  [SerializeField]
  private float speed = 13.8889f; // 13.88m/s = 50km/h

  private CharacterController characterController;

  public void Awake() {
    characterController = GetComponent<CharacterController>();
  }

  public void Update() {
    Vector3 moveDelta = Vector3.forward * speed * Time.deltaTime;
    characterController.Move(moveDelta);
  }
}
