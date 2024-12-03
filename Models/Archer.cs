namespace lesEchoDuNeant.Models
{
    public class Archer : Personnages
    {
        public Archer() : base("Archer", 5, 10, 4, 110)
        {

        }

        public string TirPrecis()
        {
            return $"{Nom}: Lance Tir Précis ! Agilité x1.5 ";
        }
    }
}