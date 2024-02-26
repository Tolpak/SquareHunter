using System;
using Zenject;

    //[CreateAssetMenu(menuName = "Enemies/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public CharacterSettings Character;
        public EnemySpawnerSettings Enemy;
        public GameInstaller.Settings GameInstaller;

        [Serializable]
        public class CharacterSettings
        {
            public Character.Settings Speed;
        }

        [Serializable]
        public class EnemySpawnerSettings
        {
            public EnemySpawner.Settings Spawner;
        }

        public override void InstallBindings()
        {

            Container.BindInstance(Enemy.Spawner);
            Container.BindInstance(Character.Speed);
            Container.BindInstance(GameInstaller);
        }
    }


