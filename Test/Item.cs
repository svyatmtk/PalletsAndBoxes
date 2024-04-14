namespace PalettesAndBoxes
{
    public abstract class Item
    {
        public int ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public Item(int id, double width, double height, double depth, double weight)
        {
            ID = id;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
        }
    }
}