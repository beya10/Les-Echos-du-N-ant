namespace lesEchoDuNeant.Models
{
    public class Troll : Monstres
    {
        public Troll(): base("Troll", 10, 2, 50)
        {

        }

        public string Ecraser()
        {
            return $"{Nom} écrase tout sur son passage";
        }
    }
}