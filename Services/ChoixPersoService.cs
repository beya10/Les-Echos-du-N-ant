// Service pour le choix du personnage
// Dans Blazor les services peuvent être integrée dans le fichier Program.cs
namespace lesEchoDuNeant.Service
{
    public class ChoixPersoService
    {
        public string PersonnageChoisis{get;private set;}
        public void SaveChoice(string personnage)
        {
            PersonnageChoisis = personnage;
        }

        public bool PersonnageEstChoisis()
        {
            return !string.IsNullOrEmpty(PersonnageChoisis);
        }
    }
}