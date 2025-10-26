namespace Models
{
    public class CharacterModel
    {
        public string PrefabPath { get; private set; }

        public CharacterModel(string prefabPath)
        {
            PrefabPath = prefabPath;
        }
    }
}