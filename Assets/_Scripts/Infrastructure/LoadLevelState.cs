using _Scripts.CameraLogic;
using UnityEngine;

namespace _Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, OnLoaded);
        }

        private void OnLoaded()
        { 
            var player = Instantiate("Player");
            Instantiate("Hud");

            SetCameraFollow(player);
        }
        
        private void SetCameraFollow(GameObject following)
        {
            Camera.main.GetComponent<CameraFollow>().SetFollow(following);
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public void Exit()
        {
        }
    }
}