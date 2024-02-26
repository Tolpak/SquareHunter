using System;
using UnityEngine;
using Zenject;

// Main installer
public class GameInstaller : MonoInstaller
{
    [Inject]
    Settings settings = null;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ProgressManager>().AsSingle();
        Container.BindInterfacesTo<EnemySpawner>().AsSingle();
        BindFactories();
    }

    void BindFactories()
    {
        Container.BindFactory<Enemy, Enemy.Factory>()
            .FromComponentInNewPrefab(settings.EnemyPrefab)
            .WithGameObjectName("Enemy")
            .UnderTransformGroup("Enemies");
    }

    [Serializable]
    public class Settings
    {
        public GameObject EnemyPrefab;
    }
}
