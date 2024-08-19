using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
  public static CubePool Instance;

  [SerializeField] private GameObject cubePrefab;
  [SerializeField] private int poolSize = 5;

  private Queue<GameObject> _cubePool;

  private void Awake()
  {
    Instance = this;
    
    _cubePool = new Queue<GameObject>();

    for (int i = 0; i < poolSize; i++)
    {
      GameObject cube = Instantiate(cubePrefab);
      cube.SetActive(false);
      _cubePool.Enqueue(cube);
    }
  }

  public GameObject GetCube()
  {
    if (_cubePool.Count > 0)
    {
      return _cubePool.Dequeue();
    }
    else
    {
      GameObject newCube = Instantiate(cubePrefab);
      newCube.SetActive(false);
      return newCube;
    }
  }

  public void ReturnCube(GameObject cube)
  {
    cube.SetActive(false);
    _cubePool.Enqueue(cube);
  }
}