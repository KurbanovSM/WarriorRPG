using _Scripts.Infrastructure.Services;
using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreateHud();
        public GameObject CreatePlayer(Vector3 initialPoint);
    }
}