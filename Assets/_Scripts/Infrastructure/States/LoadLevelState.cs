using _Scripts.CameraLogic;
using _Scripts.Infrastructure.AssetManagement;
using _Scripts.Infrastructure.Factory;
using _Scripts.ScreenLogic;
using UnityEngine;

namespace _Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string payload)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(payload, OnLoaded);
        }
        
        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            var initialPoint = GameObject.FindWithTag(AssetPath.PlayerInitialPointTag).transform.position;
            var player = _gameFactory.CreatePlayer(initialPoint);
            
            _gameFactory.CreateHud();

            SetCameraFollow(player);
            
            _stateMachine.Enter<GameLoopState>();
        }

        private void SetCameraFollow(GameObject following)
        {
            Camera.main.GetComponent<CameraFollow>().SetFollow(following);
        }
    }
}