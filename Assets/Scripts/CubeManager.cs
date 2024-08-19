using UnityEngine;

public class CubeManager : MonoBehaviour, ICubeObserver
{
  private CubeSubject _subject;
  private GameObject _cube;

  private void Start()
  {
    _subject = new CubeSubject();
    _subject.RegisterObserver(this);
        
    _cube = CubePool.Instance.GetCube();
    _cube.SetActive(true);
  }

  public void HideCube()
  {
    if (_cube != null)
    {
      _cube.SetActive(false);
      _subject.NotifyCubeHidden();
    }
  }

  public void DestroyCube()
  {
    if (_cube != null)
    {
      CubePool.Instance.ReturnCube(_cube);
      _subject.NotifyCubeDestroyed();
      _cube = null;
    }
  }

  public void RespawnCube()
  {
    if (_cube == null)
    {
      _cube = CubePool.Instance.GetCube();
      _cube.SetActive(true);
      _subject.NotifyCubeRespawned();
    }
  }

  public void OnCubeHidden()
  {
    Debug.Log("Cube has been hidden.");
  }

  public void OnCubeDestroyed()
  {
    Debug.Log("Cube has been destroyed.");
  }

  public void OnCubeRespawned()
  {
    Debug.Log("Cube has been respawned.");
  }
}