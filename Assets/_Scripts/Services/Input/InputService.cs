using UnityEngine;

namespace _Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Fire = "Fire";
        
        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp()
        {
            return SimpleInput.GetButtonUp(Fire);
        }
        
        protected static Vector2 GetJoystickAxis()
        {
            return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        }
        
        protected static Vector2 GetUnityAxis()
        {
            return new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
        }
    }
}