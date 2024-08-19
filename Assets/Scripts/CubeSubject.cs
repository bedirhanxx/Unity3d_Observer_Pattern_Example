using System.Collections.Generic;

public class CubeSubject
{
  private List<ICubeObserver> _observers = new List<ICubeObserver>();

  public void RegisterObserver(ICubeObserver observer)
  {
    if (!_observers.Contains(observer))
    {
      _observers.Add(observer);
    }
  }

  public void UnregisterObserver(ICubeObserver observer)
  {
    if (_observers.Contains(observer))
    {
      _observers.Remove(observer);
    }
  }

  public void NotifyCubeHidden()
  {
    foreach (var observer in _observers)
    {
      observer.OnCubeHidden();
    }
  }

  public void NotifyCubeDestroyed()
  {
    foreach (var observer in _observers)
    {
      observer.OnCubeDestroyed();
    }
  }

  public void NotifyCubeRespawned()
  {
    foreach (var observer in _observers)
    {
      observer.OnCubeRespawned();
    }
  }
}