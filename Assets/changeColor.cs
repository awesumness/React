using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class changeColor : MonoBehaviour {

  public Node node { get; set; }
  float clickStart;

  // Use this for initialization
  void Start() {
  }

  // Update is called once per frame
  void Update() {
  }


  void OnMouseUp() {
    // Path -> Wall -> Start -> End
    switch (node.type) {
      case Node.Type.Path:
        color(Color.black);
        this.node.type = Node.Type.Wall;
        break;
      case Node.Type.Wall:
        color(Color.red);
        this.node.type = Node.Type.Start;
        break;
      case Node.Type.Start:
        if (Time.time - clickStart < 1f) {
          color(Color.green);
          this.node.type = Node.Type.End;
        } else {
          UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects().Where(gameObject => gameObject.name == "Logic").ToList()[0].GetComponent<PopulateLevelScript>().testMe();
        }
        break;
      default:
        color(Color.white);
        this.node.type = Node.Type.Path;
        break;
    }
  }

  void OnMouseDown() {
    clickStart = Time.time;
  }

  public void color(Color newColor) {
    this.gameObject.GetComponent<Renderer>().material.color = newColor;
  }

  public void alpha(float newAlpha) {
    Color currentColor = this.gameObject.GetComponent<Renderer>().material.color;
    this.gameObject.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
  }
}
