using System.Linq;

namespace lesEchoDuNeant.Models
{
    public abstract class Personnages
    {
        // Propriétés
        public string Nom { get; set; }
        public int Force { get; set; }
        public int Agilite { get; set; }
        public int Intelligence { get; set; }
        public int PointsDeVie { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // Constructeur
        public Personnages(string nom, int force, int agilite, int intelligence, int pointsDeVie, int x, int y)
        {
            Nom = nom;
            Force = force;
            Agilite = agilite;
            Intelligence = intelligence;
            PointsDeVie = pointsDeVie;
            X = x;
            Y = y;
        }

        // Méthodes
        public virtual string AfficherStats()
        {
            return $"Nom: {Nom} \n" +
                   $"Force: {Force} \n" +
                   $"Agilité: {Agilite} \n" +
                   $"Intelligence: {Intelligence} \n" +
                   $"Points de Vie: {PointsDeVie} \n" +
                   $"X: {X} \n" +
                   $"Y: {Y}";
        }

        public virtual string Attaquer(Monstres cible)
        {
            cible.PointsDeVie -= Force;
            if (cible.PointsDeVie < 0)
            {
                cible.PointsDeVie = 0; // Limite les PDV
            }

            return $"{Nom} attaque {cible.Nom} et inflige {Force} de dégâts.";
        }

        public virtual string Defendre()
        {
            return $"{Nom} se met en position défensive.";
        }

        public virtual string Esquiver()
        {
            return $"{Nom} tente d'esquiver l'attaque."; // À mettre en point (pas une compétence mais une chance d'esquiver l'attaque)
        }

        public void Deplacer(int dx, int dy, Map.Map carte)
        {
            // Calcule les nouvelles coordonnées
            int nouvelleX = X + dx;
            int nouvelleY = Y + dy;

            // Vérifie si les nouvelles coordonnées sont dans les limites de la carte
            if (nouvelleX >= 0 && nouvelleX < carte.Largeur && nouvelleY >= 0 && nouvelleY < carte.Hauteur)
            {
                // Met à jour les coordonnées X et Y du personnage
                X = nouvelleX;
                Y = nouvelleY;
            }
        }

        public void Interagir(Map.Map carte)
        {
            // Vérifie s'il y a un piège à la position actuelle
            var piege = carte.Piege.FirstOrDefault(p => p.X == X && p.Y == Y);
            if (piege != null)
            {
                // Subit les dégâts du piège
                PointsDeVie -= piege.Degats;
                if (PointsDeVie < 0)
                {
                    PointsDeVie = 0;
                }
                carte.Piege.Remove(piege);
            }

            // Vérifie s'il y a un coffre à la position actuelle
            var coffre = carte.Coffres.FirstOrDefault(c => c.X == X && c.Y == Y);
            if (coffre != null)
            {
                // Récupère les bonus du coffre
                Force += coffre.BonusForce;
                PointsDeVie += coffre.BonusVie;
                carte.Coffres.Remove(coffre);
            }
        }
    }
}





// using System;
// using System.Linq;
// using System.Reflection.Metadata.Ecma335;
//
// namespace lesEchoDuNeant.Models
// {
//     // Classe abstraite représentant un personnage dans le jeu
//     public abstract class Personnages
//     {
//         // Propriétés
//         public string Nom { get; set; }
//         public int Force { get; set; }
//         public int Agilite { get; set; }
//         public int Intelligence { get; set; }
//         public int PointsDeVie { get; set; }
//         public int X { get; set; }
//         public int Y { get; set; }
//
//         // Constructeur
//         public Personnages(string nom, int force, int agilite, int intelligence, int pointsDeVie, int x, int y)
//         {
//             Nom = nom;
//             Force = force;
//             Agilite = agilite;
//             Intelligence = intelligence;
//             PointsDeVie = pointsDeVie;
//             X = x;
//             Y = y;
//         }
//
//         // Méthodes
//         public virtual string AfficherStats()
//         {
//             return $"Nom: {Nom} \n" +
//                    $"Force: {Force} \n" +
//                    $"Agilité: {Agilite} \n" +
//                    $"Intelligence: {Intelligence} \n" +
//                    $"Points de Vie: {PointsDeVie} \n" +
//                    $"X: {X} \n" +
//                    $"Y: {Y}";
//         }
//
//         public virtual string Attaquer(Monstres cible)
//         {
//             cible.PointsDeVie -= Force;
//             if (cible.PointsDeVie < 0)
//             {
//                 cible.PointsDeVie = 0; // Limite les PDV
//             }
//
//             return $"{Nom} attaque {cible.Nom} et inflige {Force} de dégâts.";
//         }
//
//         public virtual string Defendre()
//         {
//             return $"{Nom} se met en position défensive.";
//         }
//
//         public virtual string Esquiver()
//         {
//             return $"{Nom} tente d'esquiver l'attaque."; // À mettre en point (pas une compétence mais une chance d'esquiver l'attaque)
//         }
//
//         public void Deplacer(int dx, int dy, Map.Map carte)
//         {
//             // Calcule les nouvelles coordonnées
//             int nouvelleX = X + dx;
//             int nouvelleY = Y + dy;
//
//             // Vérifie si les nouvelles coordonnées sont dans les limites de la carte
//             if (nouvelleX >= 0 && nouvelleX < carte.Largeur && nouvelleY >= 0 && nouvelleY < carte.Hauteur)
//             {
//                 // Met à jour les coordonnées X et Y du personnage
//                 X = nouvelleX;
//                 Y = nouvelleY;
//             }
//         }
//
//         public void Interagir(Map.Map carte)
//         {
//             // Vérifie s'il y a un ennemi à la position actuelle
//             var ennemi = carte.Ennemis.FirstOrDefault(e => e.X == X && e.Y == Y);
//             if (ennemi != null)
//             {
//                 // Si oui, attaque l'ennemi
//                 Attaquer(ennemi);
//                 if(ennemi.PointsDeVie <= 0)
//                     carte.Ennemis.Remove(ennemi);
//             }
//         }
//         
//         // Vérifie s'il y a un piège à la position actuelle
//          var pieges = Map.Pieges.FirstOrderDefault(p.X == X && p.Y == Y);
//          if( piege != null)
//          {
//              // Subit les dégâts du piège
//              PointsDeVie -= pieges.Degats;
//              if (PointsDeVie < 0)
//              {
//                  PointsDeVie = 0;
//              }
//
//              Map.Pieges.Remove(pieges);
//          }
//          
//          // Vérifie s'il y a un coffre à la position actuelle
//          var coffre = carte.Coffres.FirstOrDefault(c => c.X == X && c.Y == Y);
//              if (coffre != null)
//          {
//              // Récupère les bonus du coffre
//              Force += coffre.BonusForce;
//              PointsDeVie += coffre.BonusVie;
//              carte.Coffres.Remove(coffre);
//          }
//     }
//}