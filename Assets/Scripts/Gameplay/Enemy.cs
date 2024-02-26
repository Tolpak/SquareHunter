using System;
using UnityEngine;
using Zenject;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent Dead;
    public class Factory : PlaceholderFactory<Enemy>
    {
    }
    private void OnDestroy()
    {
        Dead.Invoke();
    }

    [Serializable]
    public class Settings
    {
    }
}
