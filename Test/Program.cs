namespace PalettesAndBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = GenerateBoxes(50);
            List<Pallet> pallets = GeneratePallets(100, boxes);

            ShowInformationAboutBoxexAndPallets(boxes, pallets);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");

            SortAndGroupByExpDateAndWeight(pallets);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");

            Top3PalletsExpDateAndVolume(pallets);
        }
        private static void ShowInformationAboutBoxexAndPallets(List<Box> boxes, List<Pallet> pallets)
        {
            Console.WriteLine("Сгенерированные коробки:");
            foreach (var box in boxes)
            {
                Console.WriteLine($"Коробка ID: {box.ID}, " +
                    $"Размеры: {Math.Round(box.Width, 2)} x {Math.Round(box.Height, 2)} x {Math.Round(box.Depth, 2)}, " +
                    $"Вес: {Math.Round(box.Weight, 2)}, " +
                    $"Произведено: {box.ProductionDate.ToShortDateString()}, " +
                    $"Срок годности: {box.ExpiryDate.ToShortDateString()}");
            }

            Console.WriteLine("\nСгенерированные паллеты:");
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"Палетта ID: {pallet.ID}, " +
                    $"Размеры: {Math.Round(pallet.Width)} x {Math.Round(pallet.Height, 2)} x {Math.Round(pallet.Depth, 2)}, " +
                    $"Вес: {Math.Round(pallet.Weight, 2)}");

                Console.WriteLine("Содержимое:");
                foreach (var box in pallet.Boxes)
                {
                    Console.WriteLine($"- Коробка ID: {box.ID}, " +
                        $"Размеры: {Math.Round(box.Width, 2)} x{Math.Round(box.Height, 2)} x {Math.Round(box.Depth, 2)}, " +
                        $"Вес: {Math.Round(box.Weight, 2)}, " +
                        $"Произведено: {box.ProductionDate.ToShortDateString()}, " +
                        $"Срок годности: {box.ExpiryDate.ToShortDateString()}");
                }
            }
        }
        static List<Box> GenerateBoxes(int count)
        {
            Random random = new Random();
            List<Box> boxes = new List<Box>();

            for (int i = 1; i <= count; i++)
            {
                double width = random.NextDouble() * 10 + 1;
                double height = random.NextDouble() * 10 + 1;
                double depth = random.NextDouble() * 10 + 1;
                double weight = random.NextDouble() * 5 + 1;
                DateTime productionDate = DateTime.Now.AddDays(-random.Next(1, 100));

                Box box = new Box(i, width, height, depth, weight, productionDate);
                boxes.Add(box);
            }

            return boxes;
        }
        static List<Pallet> GeneratePallets(int count, List<Box> boxes)
        {
            Random random = new Random();
            List<Pallet> pallets = new List<Pallet>();

            for (int i = 1; i <= count; i++)
            {
                double width = random.NextDouble() * 50 + 50;
                double height = random.NextDouble() * 50 + 50;
                double depth = random.NextDouble() * 50 + 50;

                Pallet pallet = new Pallet(i, width, height, depth);

                int boxCount = random.Next(1, 6);
                for (int j = 0; j < boxCount; j++)
                {
                    Box randomBox = boxes[random.Next(boxes.Count)];
                    pallet.AddBox(randomBox);
                }

                pallets.Add(pallet);
            }

            return pallets;
        }
        private static void SortAndGroupByExpDateAndWeight(List<Pallet> pallets)
        {
            Console.WriteLine("Палетты, отсортированные по сроку годности и отсортированные по весу");

            var groupedPallets = pallets.
                OrderBy(pal => pal.CalculateExpiryDate()).
                GroupBy(pal => pal.CalculateExpiryDate()).
                SelectMany(g => g.OrderBy(pal => pal.CalculateWeight()));

            foreach (var pallet in groupedPallets)
            {
                Console.WriteLine($"Срок годности  - {pallet.CalculateExpiryDate()}, вес - {pallet.Weight}");

            }
        }
        private static void Top3PalletsExpDateAndVolume(List<Pallet> pallets)
        {
            Console.WriteLine("3 палетты с наибольшим сроком годности, отсортированные по объёму");
            var top3Pallets = pallets.
                OrderByDescending(pal => pal.CalculateExpiryDate()).
                Take(3).
                OrderBy(pal => pal.CalculateVolume());

            foreach (var pal in top3Pallets)
            {
                Console.WriteLine($"Cрок годности - {pal.CalculateExpiryDate()}, объём {pal.CalculateVolume()}");
            }
        }
    }
}