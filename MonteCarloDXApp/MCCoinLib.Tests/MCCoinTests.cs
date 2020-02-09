using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCoinLib.RandomEngines;
using NUnit.Framework;

namespace MCCoinLib.Tests
{
    [TestFixture]
    public class MCCoinTests
    {
        [Test]
        public void MCCoinSettings_Creation_Test()
        {
            MCCoinSettings settings = MCCoinSettings.Create(numberTrials: 1000);
            Assert.AreEqual(1000, settings.NumberTrials);
        }

        [Test]
        public void Coin_Creation_With_Negative_Diameter_Exception_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { Coin.CreateWithDiameter(-5); });
        }

        [Test]
        public void SquareTile_Creation_With_Negative_SquareLength_Exception_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { SquareTile.Create(-8); });
        }

        [Test]
        public void MCCoinSettings_Creation_With_Negative_Trials_Exception_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { MCCoinSettings.Create(0); });
        }

        [Test]
        public void MCCoinSimulation_Halton_Run_Test()
        {
            MCCoinSettings settings = MCCoinSettings.Create(
                numberTrials: 1000);
            var coin = Coin.CreateWithDiameter(1.0);
            var squareTile = SquareTile.Create(2.0);

            MCCoinSimulation simulation = new MCCoinSimulation(settings);
            simulation.ResultsUpdated += results => { };
            //simulation.ResultsUpdated += (res) => { Console.WriteLine("New results..."); };

            var probability = simulation.Run(coin:  coin, squareTile: squareTile);

            Assert.AreEqual(0.75, Math.Round(probability,2));
        }

        [Test]
        public void MCCoinSimulation_UniformRandom_Run_Test()
        {
            MCCoinSettings settings = MCCoinSettings.Create(
                numberTrials: 100000);
            var coin = Coin.CreateWithDiameter(1.0);
            var squareTile = SquareTile.Create(2.0);

            var simulation = new MCCoinSimulation(settings, new RandomSequence2DEngine(100,1023));
            var probability = simulation.Run(coin:  coin, squareTile: squareTile);

            Assert.AreEqual(0.75, Math.Round(probability,2));
        }
    }
}