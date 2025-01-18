// using System;
// using System.Collections.Generic;
//
// namespace lesEchoDuNeant.Map
// {
//     // Classe représentant une carte dans le jeu
//     public class Map
//     {
//         public int Largeur { get; }
//         public int Hauteur { get; }
//         public List<Cellule> Cellules { get; }
//
//         public Map(int largeur, int hauteur)
//         {
//             Largeur = largeur;
//             Hauteur = hauteur;
//             Cellules = new List<Cellule>();
//
//             // Génération aléatoire
//             var typesTerrain = new[]
//             {
//                 new { Type = "Herbe", Image = "/images/herbe.webp" },
//                 new { Type = "Eau", Image = "/images/eau.webp" },
//                 new { Type = "Montagne", Image = "/images/montagne.webp" }
//             };
//
//             var random = new Random();
//             for (int y = 0; y < Hauteur; y++)
//             {
//                 for (int x = 0; x < Largeur; x++)
//                 {
//                     var terrain = typesTerrain[random.Next(typesTerrain.Length)];
//                     Cellules.Add(new Cellule(x, y, terrain.Type, terrain.Image));
//                 }
//             }
//         }
//     }
// }

using System;
using System.Collections.Generic;
using lesEchoDuNeant.Models;

namespace lesEchoDuNeant.Map
{
    public class Map
    {
        public int Largeur { get; }
        public int Hauteur { get; }
        public List<Cellule> Cellules { get; }
        public List<Piege> Piege { get; }
        public List<Coffre> Coffres { get; }

        public Map(int largeur, int hauteur)
        {
            Largeur = largeur;
            Hauteur = hauteur;
            Cellules = new List<Cellule>();
            Piege = new List<Piege>();
            Coffres = new List<Coffre>();

            // Génération aléatoire des cellules
            var typesTerrain = new[]
            {
                new { Type = "Herbe", Image = "/images/herbe.webp" },
                new { Type = "Eau", Image = "/images/eau.webp" },
                new { Type = "Montagne", Image = "/images/montagne.webp" }
            };

            var random = new Random();
            for (int y = 0; y < Hauteur; y++)
            {
                for (int x = 0; x < Largeur; x++)
                {
                    var terrain = typesTerrain[random.Next(typesTerrain.Length)];
                    Cellules.Add(new Cellule(x, y, terrain.Type, terrain.Image));
                }
            }

            // Génération aléatoire des ennemis, pièges et coffres
            GenererPieges(random);
            GenererCoffres(random);
        }

        
        private void GenererPieges(Random random)
        {
            for (int i = 0; i < 5; i++) // Ajoute 5 pièges aléatoires
            {
                int x = random.Next(Largeur);
                int y = random.Next(Hauteur);
                Piege.Add(new Piege("Piège à loups", 20, x, y));
            }
        }

        private void GenererCoffres(Random random)
        {
            for (int i = 0; i < 5; i++) // Ajoute 5 coffres aléatoires
            {
                int x = random.Next(Largeur);
                int y = random.Next(Hauteur);
                Coffres.Add(new Coffre("Coffre en bois", 5, 20, x, y));
            }
        }

        // Ajout de la méthode PlacerPersonnage
        public (int, int) PlacerPersonnage(string personnage)
        {
            var random = new Random();
            int x = random.Next(Largeur);
            int y = random.Next(Hauteur);
            var cellule = GetCellule(x, y);
            cellule.HasPlayer = true;
            cellule.PersonnageImage = $"/images/{personnage.ToLower()}.png"; // Assurez-vous que les images sont nommées correctement
            return (x, y);
        }

        // Ajout de la méthode IsValidPosition
        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Largeur && y >= 0 && y < Hauteur;
        }

        // Ajout de la méthode GetCellule
        public Cellule GetCellule(int x, int y)
        {
            return Cellules.Find(c => c.X == x && c.Y == y);
        }
    }
}