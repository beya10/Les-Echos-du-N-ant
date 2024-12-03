namespace lesEchoDuNeant.Models
{
    public class Guerrier : Personnages
    {
        public Guerrier() : base("Guerrier", 10, 5, 3, 120)
        {

        }

        public string CoupPuissant()
        {
            return $"{Nom} utilise Coup Puissant ! Force augmenté temporairement";
        }
    }
}
