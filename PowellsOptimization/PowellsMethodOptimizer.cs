//Copyright Warren Harding 2025.
using OptimizationInterface;

namespace PowellsOptimization
{
    public class PowellsMethodOptimizer : IOptimizer
    {
        public OptimizationResult Optimize(Func<double[], double> objectiveFunction, double[] initialGuess, OptimizationOptions options)
        {
            int n = initialGuess.Length;
            double[][] directions = CreateInitialDirections(n);
            double[] currentPoint = (double[])initialGuess.Clone();
            double currentValue = objectiveFunction(currentPoint);
            int iterations = 0;
            double convergenceThreshold = options.Tolerance;
            while (iterations++ < options.MaxIterations)
            {
                double[] p0 = (double[])currentPoint.Clone();
                double[] p1 = (double[])currentPoint.Clone();
                int bestIndex = 0;
                double bestDelta = 0.0;
                for (int i = 0; i < n; i++)
                {
                    double valueBeforeMove = objectiveFunction(p1);
                    (p1, double newValue) = LineMinimization(objectiveFunction, p1, directions[i], valueBeforeMove);
                    double delta = Math.Abs(valueBeforeMove - newValue);
                    if (delta > bestDelta)
                    {
                        bestDelta = delta;
                        bestIndex = i;
                    }
                }

                double[] extrapolated = new double[n];
                for (int i = 0; i < n; i++)
                {
                    extrapolated[i] = 2.0 * p1[i] - p0[i];
                }

                double extrapolatedValue = objectiveFunction(extrapolated);
                double previousValue = objectiveFunction(p0);
                double currentBestValue = objectiveFunction(p1);
                if (extrapolatedValue < currentBestValue)
                {
                    double[] newDirection = new double[n];
                    double improvement = previousValue - extrapolatedValue;
                    if (2.0 * (previousValue - 2.0 * currentBestValue + extrapolatedValue) * Math.Pow(previousValue - currentBestValue - improvement, 2) < improvement * Math.Pow(previousValue - currentBestValue, 2))
                    {
                        for (int i = 0; i < n; i++)
                        {
                            newDirection[i] = p1[i] - p0[i];
                        }

                        directions[bestIndex] = newDirection;
                        currentPoint = extrapolated;
                        currentValue = extrapolatedValue;
                    }
                }
                else
                {
                    currentPoint = p1;
                    currentValue = currentBestValue;
                }

                if (bestDelta < convergenceThreshold)
                {
                    return new OptimizationResult
                    {
                        BestSolution = currentPoint,
                        BestObjectiveValue = currentValue,
                        Converged = true,
                        Iterations = iterations,
                        Remarks = "Optimization converged successfully"
                    };
                }
            }

            return new OptimizationResult
            {
                BestSolution = currentPoint,
                BestObjectiveValue = currentValue,
                Converged = false,
                Iterations = iterations,
                Remarks = "Maximum iterations reached"
            };
        }

        private double[][] CreateInitialDirections(int n)
        {
            double[][] directions = new double[n][];
            for (int i = 0; i < n; i++)
            {
                directions[i] = new double[n];
                directions[i][i] = 1.0;
            }

            return directions;
        }

        private (double[] point, double value) LineMinimization(Func<double[], double> objectiveFunction, double[] startPoint, double[] direction, double startValue)
        {
            const double alpha = 1e-4;
            const double rho = 2.0;
            double step = 1.0;
            int maxSteps = 20;
            double[] tempPoint = new double[startPoint.Length];
            double bestValue = startValue;
            double[] bestPoint = (double[])startPoint.Clone();
            for (int i = 0; i < maxSteps; i++)
            {
                for (int j = 0; j < startPoint.Length; j++)
                {
                    tempPoint[j] = startPoint[j] + step * direction[j];
                }

                double currentValue = objectiveFunction(tempPoint);
                if (currentValue < bestValue)
                {
                    bestValue = currentValue;
                    Array.Copy(tempPoint, bestPoint, tempPoint.Length);
                    step *= rho;
                }
                else
                {
                    step *= -0.5;
                }

                if (Math.Abs(step) < alpha)
                {
                    break;
                }
            }

            return (bestPoint, bestValue);
        }
    }
}