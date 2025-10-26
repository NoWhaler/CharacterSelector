using Interfaces;
using Services;
using State;
using Zenject;

namespace Installers
{
    public class SessionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISessionService>().To<SessionService>().AsSingle();
            Container.Bind<ICharacterRepository>().To<CharacterRepository>().AsSingle();
            Container.Bind<ICharacterService>().To<CharacterService>().AsSingle();
            Container.Bind<ISceneNavigationService>().To<SceneNavigationService>().AsSingle();
            Container.Bind<IViewFactory>().To<ViewFactory>().AsSingle();
        }
    }
}