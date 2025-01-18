namespace lesEchoDuNeant.Map
{
    // Brique de base de la carte. Chaque case est représentée par l'objet cellule
    public class Cellule
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string TypeTerrain { get; set; }
        public string Image { get; set; }
        public bool HasPlayer { get; set; } // Ajout de la propriété HasPlayer
        public string PersonnageImage { get; set; } // Ajout de la propriété PersonnageImage

        public Cellule(int x, int y, string typeTerrain, string image)
        {
            X = x;
            Y = y;
            TypeTerrain = typeTerrain;
            Image = image;
            HasPlayer = false; // Initialisation par défaut
            PersonnageImage = string.Empty; // Initialisation par défaut
        }
    }
}