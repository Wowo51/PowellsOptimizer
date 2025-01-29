//Copyright Warren Harding 2025.
using OptimizationInterface;
using PowellsOptimization;

namespace PowellsOptimizationTest
{
    [TestClass]
    public class PowellsMethodOptimizerTests
    {
        private readonly PowellsMethodOptimizer _optimizer = new();
        private readonly double[] _knownSolution = new double[]
        {
            1.0,
            2.0
        };
        private readonly double _knownBestObjectiveValue = 3.0;
        private readonly double _tolerance = 1e-4;
        private static double ObjectiveFunction(double[] x)
        {
            return Math.Pow(x[0] - 1, 2) + Math.Pow(x[1] - 2, 2) + 3;
        }

        [TestMethod]
        public void OptimizeFromOrigin()
        {
            double[] initialGuess = new double[]
            {
                0.0,
                0.0
            };
            OptimizationOptions options = new()
            {
                MaxIterations = 2000,
                Tolerance = 1e-4
            };
            OptimizationResult result = _optimizer.Optimize(ObjectiveFunction, initialGuess, options);
            Assert.IsTrue(result.Converged, "Optimization should converge");
            Assert.IsTrue(Math.Abs(result.BestObjectiveValue - _knownBestObjectiveValue) < _tolerance, "Objective value should match known best value");
            Assert.IsTrue(Math.Abs(result.BestSolution[0] - _knownSolution[0]) < _tolerance, "X coordinate should match known solution");
            Assert.IsTrue(Math.Abs(result.BestSolution[1] - _knownSolution[1]) < _tolerance, "Y coordinate should match known solution");
        }

        [TestMethod]
        public void OptimizeFromPositive()
        {
            double[] initialGuess = new double[]
            {
                5.0,
                5.0
            };
            OptimizationOptions options = new()
            {
                MaxIterations = 2000,
                Tolerance = 1e-4
            };
            OptimizationResult result = _optimizer.Optimize(ObjectiveFunction, initialGuess, options);
            Assert.IsTrue(result.Converged, "Optimization should converge");
            Assert.IsTrue(Math.Abs(result.BestObjectiveValue - _knownBestObjectiveValue) < _tolerance, "Objective value should match known best value");
            Assert.IsTrue(Math.Abs(result.BestSolution[0] - _knownSolution[0]) < _tolerance, "X coordinate should match known solution");
            Assert.IsTrue(Math.Abs(result.BestSolution[1] - _knownSolution[1]) < _tolerance, "Y coordinate should match known solution");
        }

        [TestMethod]
        public void OptimizeFromNegative()
        {
            double[] initialGuess = new double[]
            {
                -5.0,
                -5.0
            };
            OptimizationOptions options = new()
            {
                MaxIterations = 2000,
                Tolerance = 1e-4
            };
            OptimizationResult result = _optimizer.Optimize(ObjectiveFunction, initialGuess, options);
            Assert.IsTrue(result.Converged, "Optimization should converge");
            Assert.IsTrue(Math.Abs(result.BestObjectiveValue - _knownBestObjectiveValue) < _tolerance, "Objective value should match known best value");
            Assert.IsTrue(Math.Abs(result.BestSolution[0] - _knownSolution[0]) < _tolerance, "X coordinate should match known solution");
            Assert.IsTrue(Math.Abs(result.BestSolution[1] - _knownSolution[1]) < _tolerance, "Y coordinate should match known solution");
        }
    }
}