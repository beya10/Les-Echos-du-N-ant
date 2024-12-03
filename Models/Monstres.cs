namespace lesEchoDuNeant.Models
{
    public abstract class Monstres
    {
        public string Nom { get; set; }
        public int Force { get; set; }
        public int Agilite { get; set; }
        public int PointsDeVie { get; set; }

        public Monstres(string nom, int force,int agilite,int pointsDeVie)
        {
            Nom = nom;
            Force = force;
            Agilite = agilite;
            PointsDeVie = pointsDeVie;
        }

        public string AfficherStats()
        {
            return $"{Nom} : Force = {Force} : Agilité = {Agilite} : Point de Vie = {PointsDeVie}";
        }
    }
}