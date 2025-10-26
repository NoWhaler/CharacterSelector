using Presenters;
using Zenject;

namespace Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameScenePresenter>().AsSingle().NonLazy();
        }
    }
}