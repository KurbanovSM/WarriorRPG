using _Scripts.Infrastructure.AssetManagement;
using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreatePlayer(Vector3 initialPoint)
        {
            return _assetProvider.Instantiate(AssetPath.PlayerPath, initialPoint);
        }

        public GameObject CreateHud()
        {
            return _assetProvider.Instantiate(AssetPath.HudScreenPath);
        }
    }
}