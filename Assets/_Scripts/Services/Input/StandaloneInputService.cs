using UnityEngine;

namespace _Scripts.Services.Input
{
    class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                var axis = GetJoystickAxis();

                if (axis == Vector2.zero)
                {
                    axis = GetUnityAxis();
                }
                
                return axis;
            }
        }
    }
}