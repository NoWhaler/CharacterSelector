using Enums;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class ViewFactory : IViewFactory
    {
        private const string VIEW_PREFABS_FOLDER = "Prefabs/Views";

        public GameObject GetViewPrefab(ViewType viewType)
        {
            string prefabPath = $"{VIEW_PREFABS_FOLDER}/{viewType}";
            GameObject prefab = Resources.Load<GameObject>(prefabPath);

            return prefab;
        }
    }
}