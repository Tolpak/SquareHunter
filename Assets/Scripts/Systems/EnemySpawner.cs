using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : ITickable
{
    readonly Settings settings;
    private Camera mainCamera;
    private List<Enemy> enemies;
    readonly Enemy.Factory enemyFactory;

    float timeToNextSpawn;
    public EnemySpawner( Settings settings, Enemy.Factory enemyFactory)
    {
        this.settings = settings;
        this.enemyFactory = enemyFactory;
        mainCamera = Camera.main;
        enemies = new List<Enemy>();
    }

    private Vector2 GenerateRandomPosition()
    {
        return mainCamera.ScreenToWorldPoint(
            new Vector2(Random.Range(0, Screen.width),
            Random.Range(0, Screen.height)));
    }

    public void Tick()
    {
        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn < 0 && enemies.Count < settings.MaxEnemies)
        {
            timeToNextSpawn = settings.SpawnInterval;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = enemyFactory.Create();
        enemy.transform.position = GenerateRandomPosition();
        enemy.Dead.AddListener(delegate {OnEnemyKilled(enemy);});
        enemies.Add(enemy);
    }

    public void OnEnemyKilled(Enemy enemy)
    {
        enemies.Remove(enemy);
        Debug.Log("Reemoved");
    }

    [Serializable]
    public class Settings
    {
        public int MaxEnemies;
        public int SpawnInterval;
    }
}
