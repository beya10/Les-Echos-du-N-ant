using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualBasic;

namespace lesEchoDuNeant.Map
{
    //Structure globale de la carte qui contient toute les cellules dans une liste
    public class Map
    {
        public int Hauteur{ get;}
        public int Largeur{get;}
        public List<Cellule> Cellules{ get;}
        public Map(int hauteur, int largeur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            Cellules = new List<Cellule>();

            // Génération aléatoire
            var typesTerrain = new[]
            {
                new {Type = "Herbe", Image = "/images/herbe.webp"},
                new {Type = "Eau", Image = "/images/eau.webp"},
                new {Type = "Montagne", Image = "/images/montagne.webp"}
            };

            var random = new Random();
            for (int y = 0; y < Hauteur; y++)
            {
                for (int x = 0;x < Largeur; x++)
                {
                    var terrain = typesTerrain[random.Next(typesTerrain.Length)];
                    Cellules.Add(new Cellule(x, y, terrain.Type, terrain.Image));
                }
            }
        }
    }
}