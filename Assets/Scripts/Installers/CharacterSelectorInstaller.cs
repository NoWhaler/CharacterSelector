using Presenters;
using Zenject;

namespace Installers
{
    public class CharacterSelectorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterSelectorPresenter>().AsSingle().NonLazy();
        }
    }
}