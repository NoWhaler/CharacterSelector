using Interfaces;
using Models;

namespace State
{
    public class SessionService : ISessionService
    {
        public CharacterModel SelectedCharacter { get; private set; }

        public void SetSelectedCharacter(CharacterModel characterModel)
        {
            SelectedCharacter = characterModel;
        }
    }
}