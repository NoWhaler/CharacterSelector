using Enums;
using Interfaces;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneNavigationService : ISceneNavigationService
    {
        public void LoadGameScene(SceneType sceneType)
        {
            SceneManager.LoadScene(sceneType.ToString());
        }
    }
}