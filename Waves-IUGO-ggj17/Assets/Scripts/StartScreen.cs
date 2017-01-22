﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

  Text Text;

  void Awake()
  {
    Text = transform.FindChild("Score").GetComponent<Text>();
    Text.text = "Best Dive: " + PlayerPrefs.GetInt("DepthScore") + "m";
  }

  public void StartGame()
  {
    SceneManager.LoadScene("2_Gameplay");
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}