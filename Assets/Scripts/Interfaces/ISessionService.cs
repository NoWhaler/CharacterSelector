using Models;

namespace Interfaces
{
    public interface ISessionService
    {
        CharacterModel SelectedCharacter { get; }
        void SetSelectedCharacter(CharacterModel characterModel);
    }
}