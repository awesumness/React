using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }


  public void loadLevel1() {
    SceneManager.LoadScene("Level1");
  }

  public void loadMainMenu() {
    SceneManager.LoadScene("Main Menu");
  }


  public void quit() {
    Application.Quit();
  }
}
