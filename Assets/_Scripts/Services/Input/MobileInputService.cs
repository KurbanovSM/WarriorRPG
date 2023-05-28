using UnityEngine;

namespace _Scripts.Services.Input
{
    class MobileInputService : InputService
    {
        public override Vector2 Axis => GetSimpleAxis();
    }
}