using PalettesAndBoxes;

namespace BoxAndPalletsTest
{
    [TestFixture]
    public class BoxTests
    {
        [Test]
        public void CalculateVolume_Returns_CorrectVolume()
        {
            // Arrange
            var box = new Box(1, 10, 20, 30, 5, DateTime.Now);

            // Act
            var volume = box.CalculateVolume();

            // Assert
            Assert.AreEqual(6000, volume); // 10 * 20 * 30 = 6000
        }
    }

    [TestFixture]
    public class PalletTests
    {
        [Test]
        public void AddBox_Adds_Box_ToPallet()
        {
            // Arrange
            var pallet = new Pallet(1, 100, 100, 100);
            var box = new Box(1, 10, 20, 30, 5, DateTime.Now);

            // Act
            pallet.AddBox(box);

            // Assert
            Assert.AreEqual(1, pallet.Boxes.Count); // ќжидаем, что в списке коробок на паллете теперь одна коробка
        }

        [Test]
        public void CalculateExpiryDate_Returns_MinValue_ForEmptyBoxes()
        {
            // Arrange
            var pallet = new Pallet(1, 100, 100, 100);

            // Act
            var expiryDate = pallet.CalculateExpiryDate();

            // Assert
            Assert.AreEqual(DateTime.MinValue, expiryDate);
        }

        [Test]
        public void CalculateWeight_Returns_CorrectWeight_WithBoxes()
        {
            // Arrange
            var box1 = new Box(1, 10, 10, 10, 5, DateTime.Now);
            var box2 = new Box(2, 10, 10, 10, 5, DateTime.Now);
            var pallet = new Pallet(1, 100, 100, 100);
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Act
            var weight = pallet.CalculateWeight();

            // Assert
            Assert.AreEqual(40, weight); // 2 * 5 (вес каждой коробки) + 30 (вес паллеты)
        }

        [Test]
        public void CalculateVolume_Returns_CorrectVolume_WithBoxes()
        {
            // Arrange
            var box1 = new Box(1, 10, 20, 30, 5, DateTime.Now);
            var box2 = new Box(2, 20, 30, 40, 10, DateTime.Now);
            var pallet = new Pallet(1, 100, 100, 100);
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Act
            var volume = pallet.CalculateVolume();

            // Assert
            Assert.AreEqual(1030000, volume); // (10 * 20 * 30) + (20 * 30 * 40) + (100 * 100 * 100) = 6000 + 24000 + 1000000 = 1030000
        }
    }
}