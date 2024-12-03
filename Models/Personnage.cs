namespace lesEchoDuNeant.Models
{
    public abstract class Personnages
    {
        public string Nom { get; set; }
        public int Force { get; set; }
        public int Agilite { get; set; }
        public int Intelligence { get; set; }
        public int PointsDeVie { get; set; }

        public Personnages(string nom, int force, int agilite, int intelligence, int pointsDeVie)
        {
            Nom = nom;
            Force = force;
            Agilite = agilite;
            Intelligence = intelligence;
            PointsDeVie = pointsDeVie;
        }

        public virtual string AfficherStats()
        {
            return $"Nom: {Nom} \n" +
                $"Force: {Force} \n" +
                $"Agilité: {Agilite} \n" +
                $"Intelligence: {Intelligence}" +
                $"Points de Vie: {PointsDeVie}";
        }

        public virtual string Attaquer(Monstres cible)
        {
            cible.PointsDeVie -= Force;
            if (cible.PointsDeVie < 0)
            {
                cible.PointsDeVie = 0; // Limite les PDV
            }
            return $"{Nom} attaque {cible.Nom} et inflige {Force} de dégat";
        }

        public virtual string Defendre()
        {
            return $"{Nom} se met en position défensive";
        }

        public virtual string Esquiver()
        {
            return $"{Nom} tente d'esquivé l'attaque"; // A metre en point (pas une comptétence mais une chance d'esqiver l'attaque)
        }
    }
}