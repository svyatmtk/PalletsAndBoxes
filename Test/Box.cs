namespace PalettesAndBoxes
{
    public class Box : Item, IVolumeCalculatable
    {

        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Box(int id, double width, double height, double depth, double weight, DateTime productionDate, DateTime? expiryDate = null)
            : base(id, width, height, depth, weight)
        {

            ProductionDate = productionDate;
            ExpiryDate = expiryDate ?? productionDate.AddDays(100);
        }
        public double CalculateVolume() => Width * Height * Depth;
    }
}