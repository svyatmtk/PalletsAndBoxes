namespace PalettesAndBoxes
{
    public class Pallet : Item, IVolumeCalculatable
    {
        public List<Box> Boxes { get; set; }

        public Pallet(int id, double width, double height, double depth)
            : base(id, width, height, depth, 0) =>
            Boxes = new List<Box>();

        public void AddBox(Box box)
        {
            if (box.Width > Width || box.Depth > Depth)
            {
                Console.WriteLine($"Коробка {box.ID} превышает размер палетты {ID}");
                return;
            }
            Boxes.Add(box);
            CalculateWeight();
        }

        public DateTime CalculateExpiryDate()
        {
            if (Boxes.Count == 0)
                return DateTime.MinValue;

            return Boxes.Min(b => b.ExpiryDate);
        }

        public double CalculateWeight()
        {
            if (Boxes.Count == 0)
            {
                Weight = 30;
                return 30;
            }
            Weight = Boxes.Sum(b => b.Weight) + 30;
            return Weight;
        }

        public double CalculateVolume()
        {
            double boxVolume = Boxes.Sum(b => b.CalculateVolume());
            return boxVolume + Width * Height * Depth;
        }
    }
}