using _Scripts.Services.Input;
using UnityEngine;

namespace _Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string InitialSceneName = "Initial";
        private const string Level1SceneName = "Level1";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialSceneName, EnterLoadLevel);
            RegisterServices();
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(Level1SceneName);
        }

        public void Exit()
        {
        }
        
        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }
        
        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
            {
                return new StandaloneInputService();
            }
            else if(Application.isMobilePlatform)
            {
                return new MobileInputService();
            }
            else
            {
                return null;
            }
        }

    }
}