//Copyright Warren Harding 2025.
using System;

namespace OptimizationInterface
{
    /// <summary>
    /// Represents a generic interface for derivative-free optimizers.
    /// </summary>
    public interface IOptimizer
    {
        /// <summary>
        /// Optimizes the given objective function starting from an initial guess.
        /// </summary>
        /// <param name="objectiveFunction">
        /// A delegate representing the objective function to minimize. 
        /// It accepts an array of double values as input and returns a double (the function value).
        /// </param>
        /// <param name="initialGuess">
        /// An array of double values representing the starting point for the optimization.
        /// </param>
        /// <param name="options">
        /// Additional options that may be required for the optimizer (e.g., tolerance, maximum iterations).
        /// This parameter is optional and can be customized.
        /// </param>
        /// <returns>
        /// An instance of <see cref="OptimizationResult"/> containing the result of the optimization.
        /// </returns>
        OptimizationResult Optimize(Func<double[], double> objectiveFunction, double[] initialGuess, OptimizationOptions options);
    }

    /// <summary>
    /// Represents the result of an optimization run.
    /// </summary>
    public class OptimizationResult
    {
        /// <summary>
        /// Gets or sets the best solution found by the optimizer.
        /// </summary>
        public double[] BestSolution { get; set; } = new double[0];

        /// <summary>
        /// Gets or sets the objective value of the best solution.
        /// </summary>
        public double BestObjectiveValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the optimizer converged.
        /// </summary>
        public bool Converged { get; set; }

        /// <summary>
        /// Gets or sets additional information such as the number of iterations.
        /// </summary>
        public int Iterations { get; set; }

        /// <summary>
        /// Gets or sets any additional remarks or diagnostic information.
        /// </summary>
        public string Remarks { get; set; } = "";
    }

    /// <summary>
    /// Represents additional options that can be supplied to an optimizer.
    /// </summary>
    public class OptimizationOptions
    {
        /// <summary>
        /// Gets or sets the maximum number of iterations to perform.
        /// </summary>
        public int MaxIterations { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the convergence tolerance.
        /// </summary>
        public double Tolerance { get; set; } = 1e-6;

        // Add additional properties as needed (e.g., for logging, random seed, etc.)
    }
}
