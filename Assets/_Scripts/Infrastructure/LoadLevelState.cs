using _Scripts.CameraLogic;
using _Scripts.ScreenLogic;
using UnityEngine;

namespace _Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadState<string>
    {
        private const string PlayerInitialPointTag = "PlayerInitialPoint";
        private const string PlayerPath = "Player";
        private const string HudScreenPath = "HudScreen";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
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
            var initialPoint = GameObject.FindWithTag(PlayerInitialPointTag).transform.position;
            var player = Instantiate(PlayerPath, initialPoint);
            
            Instantiate(HudScreenPath);

            SetCameraFollow(player);
            
            _stateMachine.Enter<GameLoopState>();
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
        
        private static GameObject Instantiate(string path, Vector3 position)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}