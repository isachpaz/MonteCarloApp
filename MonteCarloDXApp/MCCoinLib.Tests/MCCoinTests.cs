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
            MCSimulationSettings settings = MCSimulationSettings.Create(numberTrials: 1000);
            Assert.AreEqual(1000, settings.NumberTrials);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2.34)]
        [TestCase(-200.999999)]
        [TestCase(-10)]
        public void Coin_Creation_With_Negative_Diameter_Exception_Test(double diam)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { Coin.CreateWithDiameter(diam); });
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2.34)]
        [TestCase(-200.999999)]
        [TestCase(-10)]
        public void SquareTile_Creation_With_Negative_SquareLength_Exception_Test(double len)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { SquareTile.Create(len); });
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-10000)]
        public void MCCoinSettings_Creation_With_Negative_Trials_Exception_Test(int nTrials)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { MCSimulationSettings.Create(nTrials); });
        }

        [Test]
        public void MCCoinSimulation_Halton_Run_Test()
        {
            var settings = MCSimulationSettings.Create(numberTrials: 1000);
            var randomEngineService = new Random2DEngineService();

            var coin = Coin.CreateWithDiameter(1.0);
            var squareTile = SquareTile.Create(2.0);

            MCCoinSimulation simulation = new MCCoinSimulation(settings, randomEngineService);
            simulation.Finished += results =>
            {
                Assert.AreEqual(0.75, Math.Round(results.Probability, 2));
            };

            simulation.Run(coin:  coin, squareTile: squareTile, method: SamplingMethod.Halton);
        }

        [Test]
        public void MCCoinSimulation_UniformRandom_Run_Test()
        {
            var settings = MCSimulationSettings.Create(numberTrials: 100000);
            var randomEngineService = new Random2DEngineService();
            var coin = Coin.CreateWithDiameter(1.0);
            var squareTile = SquareTile.Create(2.0);

            var simulation = new MCCoinSimulation(settings, randomEngineService);
            simulation.Finished += results => { Assert.AreEqual(0.75, Math.Round(results.Probability, 2)); };
            simulation.Run(coin:  coin, squareTile: squareTile, method: SamplingMethod.RandomUniform);
        }
    }
}