﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

  private CharacterController characterController;

  public void Awake() {
    characterController = GetComponent<CharacterController>();
  }
}