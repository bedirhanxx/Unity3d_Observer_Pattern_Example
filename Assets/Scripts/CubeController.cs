using UnityEngine;

public class CubeController : MonoBehaviour
{
  [SerializeField] private CubeManager cubeManager;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.A))
    {
      cubeManager.HideCube();
    }
    else if (Input.GetKeyDown(KeyCode.S))
    {
      cubeManager.DestroyCube();
    }
    else if (Input.GetKeyDown(KeyCode.D))
    {
      cubeManager.RespawnCube();
    }
  }
}