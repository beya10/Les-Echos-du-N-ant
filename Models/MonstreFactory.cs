using System;
using System.Collections.Generic;
using lesEchoDuNeant.Pages;

namespace lesEchoDuNeant.Models
{
    public static class MonstreFactory
    {
        public static Monstres CreerMonstreAleatoire()
        {
            string[] typeDeMonstre = {"Gobelin", "Troll"};
            var random = new Random();
            var chx = random.Next(typeDeMonstre.Length);

            return typeDeMonstre[chx] switch
            {
                "Gobelin" => new Gobelin(),
                "Troll" => new Troll(),
                _ => throw new Exception("Type de monstre inconnue")
            };
        }
    }
}