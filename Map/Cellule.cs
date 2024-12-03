namespace lesEchoDuNeant.Map
{
    public class Cellule
    {
        public int X{ get; set; }
        public int Y{ get; set; }
        public string TypeTerrain{ get; set; }
        public string Image{get; set; }

        public Cellule(int x, int y, string typeTerrain,string image)
        {
            X = x;
            Y = y;
            TypeTerrain = typeTerrain;
            Image = image;
        }   
    }
}