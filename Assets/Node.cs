using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

  public enum Type { Start, End, Wall, Path };

  public GameObject Presentation { get; set; }
  public int X { get; set; }
  public int Y { get; set; }
  public Type type { get; set; }

  public Node(GameObject presentation, int x, int y) {
    this.Presentation = presentation;
    this.X = x;
    this.Y = y;
    this.type = Type.Path;
  }



public void color(Color newColor){
    Presentation.GetComponent<changeColor>().color(newColor);
  }

public void alpha(float newAlpha){
    Presentation.GetComponent<changeColor>().alpha(newAlpha);
  }
}
