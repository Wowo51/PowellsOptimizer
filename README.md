# Powell's Method Optimizer

A multivariate Powell's Method Optimizer. Multicore CPU. Pure C#, no binaries. No dependencies except for Microsoft's unit testing.

This code is free for non-commercial use. A commercial use license is $5 Canadian.</br>
Make a purchase [here.](https://TranscendAI.tech/paylanding.html)</br>

## What is Powell's Method?
Powell's Method is a derivative-free optimization algorithm that minimizes (or maximizes) a function by iteratively updating a set of search directions. Unlike gradient-based methods, Powell's Method does not require function derivatives, making it useful for optimizing non-smooth functions.

The method proceeds as follows:
1. A set of initial search directions is established (typically along coordinate axes).
2. Line minimization is performed along each direction to find an improved solution.
3. The directions are updated iteratively based on the previous step's progress.
4. The process repeats until convergence is achieved.

## How to Use This Library
This library provides a `PowellsMethodOptimizer` class that implements `IOptimizer` from the `OptimizerInterface` project. Here’s how to integrate it into your .NET 9.0 C# application (without dependencies or external binaries):

1. **Include the Projects**:  
   - `OptimizerInterface` (contains the `IOptimizer` interface, plus `OptimizationOptions` and `OptimizationResult` classes).  
   - `PowellsOptimization` (contains the Powell's Method implementation).

2. **Configure Your Objective Function**:  
   Prepare a function (or delegate) representing the problem you want to minimize.

3. **Set an Initial Guess**:  
   Provide a starting vector for the optimizer.

4. **Adjust Optimization Options** (optional):  
   Such as maximum iterations (`MaxIterations`), convergence tolerance (`Tolerance`), etc.

5. **Invoke Powell's Method**:  
   Create an instance of `PowellsMethodOptimizer` and call its `Optimize` method, passing in your objective function, initial guess, and any options.

6. **Retrieve Results**:  
   The method returns an `OptimizationResult` containing the best solution found, the best objective value, the number of iterations used, and any remarks.

## How It Works
1. **Initialization**: A set of search directions is initialized, typically using unit vectors along coordinate axes.
2. **Line Minimization**: The algorithm iteratively performs line minimization along each search direction.
3. **Direction Update**: Powell's Method replaces the least useful direction with the most successful step direction.
4. **Stopping Criteria**: The iteration loop ends if the maximum number of iterations is reached or the objective value is sufficiently stable (within `Tolerance`).

## Key Parameters
- **Number of Dimensions**: The optimizer operates on `n`-dimensional input vectors.
- **Convergence Tolerance (default = 1e-6)**: The algorithm terminates if the improvement in objective value is below this threshold.
- **MaxIterations (default = 1000)**: The algorithm stops if this number is reached.

## Parallelization
This library uses `Parallel.For` in the main loop, allowing multiple function evaluations to run concurrently for improved performance on multi-core CPUs.

## Customization
- Modify the initial directions in the source code of `PowellsMethodOptimizer`.
- Adjust parameters like `MaxIterations` and `Tolerance` to tune performance.
- Extend `OptimizationOptions` for features like custom seeds or logging.

## Testing
The **PowellsOptimizationTest** project provides MSTest-based unit tests verifying the optimizer on known test functions. You can run or modify these tests to validate changes or new use cases.

## Known Limitations
- Powell's Method does not guarantee a global optimum but often converges well in practice.
- Currently tailored for minimization. Invert the objective function (multiply by -1) to handle maximization problems.
- Performance may degrade for high-dimensional problems without additional enhancements.

![AI Image](aiimage.jpg)
</br>
Copyright [TranscendAI.tech](https://TranscendAI.tech) 2025.</br>
Authored by Warren Harding. AI assisted.</br>

