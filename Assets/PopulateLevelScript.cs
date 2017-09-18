using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulateLevelScript : MonoBehaviour {

  static int gridWidth = 5;
  static int gridHeight = 9;
  static Node[,] grid = new Node[gridWidth, gridHeight];

  // Use this for initialization
  void Start() {
    List<GameObject> cubes = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects().Where(gameObject => gameObject.tag == "Node").ToList();
    cubes.Sort((gameObject1, gameObject2) => gameObject1.name.CompareTo(gameObject2.name));
    for (int i = 0, y = 0; y < gridHeight; ++y) {
      for (int x = 0; x < gridWidth; ++x, ++i) {
        Node node = new Node(cubes[i], x, y);
        cubes[i].GetComponent<changeColor>().node = node;
        grid[x, y] = node;
      }
    }
  }

  // Update is called once per frame
  void Update() {


  }


  public void testMe() {
    Node start = firstOfType(Node.Type.Start);
    Node finish = firstOfType(Node.Type.End);
    if (start != null && finish != null) {
      StartCoroutine(bfs(start, finish));
    }
  }

  static Node firstOfType(Node.Type desiredType) {
    Node first = null;
    for (int y = 0; y < gridHeight; ++y) {
      for (int x = 0; x < gridWidth; ++x) {
        if (grid[x, y].type == desiredType) {
          if (first != null) {
            grid[x, y].type = Node.Type.Path;
            grid[x, y].color(Color.white);
          } else {
            first = grid[x, y];
          }
        }
      }
    }
    return first;
  }

  IEnumerator bfs(Node start, Node finish) {
    HashSet<Node> visited = new HashSet<Node>();
    Queue<Node> considerations = new Queue<Node>();
    considerations.Enqueue(start);

    while (considerations.Count > 0) {
      yield return new WaitForSeconds(.5f);
      Node consideration = considerations.Dequeue();
      if (consideration != finish) {
        foreach (Node neighbor in getNeighbors(consideration)) {
          if (neighbor.type != Node.Type.Wall && !visited.Contains(neighbor)) {
            considerations.Enqueue(neighbor);
            visited.Add(neighbor);
          }
        }
        visited.Add(consideration);
        consideration.alpha(.5f);
      } else {
        break;
      }
    }
  }

  static List<Node> getNeighbors(Node root) {
    List<Node> neighbors = new List<Node>();
    if (root.Y > 0) {
      neighbors.Add(grid[root.X, root.Y - 1]);
    }
    if (root.X < gridWidth - 1) {
      neighbors.Add(grid[root.X + 1, root.Y]);
    }
    if (root.Y < gridHeight - 1) {
      neighbors.Add(grid[root.X, root.Y + 1]);
    }
    if (root.X > 0) {
      neighbors.Add(grid[root.X - 1, root.Y]);
    }
    return neighbors;
  }
}

