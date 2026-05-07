// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-task-dependencies.md.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Compute.Batch;

namespace BatchDocSamples;

internal static class TaskDependenciesSamples
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;

    public static async Task EnableJobDependenciesAsync()
    {
        #region Snippet:task_deps_enable_job
        BatchJobCreateOptions unboundJob = new BatchJobCreateOptions("job001", new BatchPoolInfo() { PoolId = "pool001" })
        {
            // IMPORTANT: This is REQUIRED for using task dependencies.
            UsesTaskDependencies = true
        };
        await batchClient.CreateJobAsync(unboundJob);
        #endregion
    }

    public static BatchTaskCreateOptions FlowersTask()
    {
        #region Snippet:task_deps_flowers
        // Task 'Flowers' depends on completion of both 'Rain' and 'Sun'
        // before it is run.
        BatchTaskCreateOptions flowers = new BatchTaskCreateOptions("Flowers", "cmd.exe /c echo Flowers")
        {
            DependsOn = new BatchTaskDependencies()
            {
                TaskIds = { "Rain", "Sun" }
            }
        };
        #endregion
        return flowers;
    }

    public static IList<BatchTaskCreateOptions> OneToOne()
    {
        #region Snippet:task_deps_one_to_one
        IList<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>
        {
            // Task 'taskA' doesn't depend on any other tasks
            new BatchTaskCreateOptions("taskA", "cmd.exe /c echo taskA"),

            // Task 'taskB' depends on completion of task 'taskA'
            new BatchTaskCreateOptions("taskB", "cmd.exe /c echo taskB")
            {
                DependsOn = new BatchTaskDependencies() { TaskIds = { "taskA" } }
            },
        };
        #endregion
        return tasks;
    }

    public static IList<BatchTaskCreateOptions> OneToMany()
    {
        #region Snippet:task_deps_one_to_many
        IList<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>
        {
            // 'Rain' and 'Sun' don't depend on any other tasks
            new BatchTaskCreateOptions("Rain", "cmd.exe /c echo Rain"),
            new BatchTaskCreateOptions("Sun", "cmd.exe /c echo Sun"),

            // Task 'Flowers' depends on completion of both 'Rain' and 'Sun'
            // before it is run.
            new BatchTaskCreateOptions("Flowers", "cmd.exe /c echo Flowers")
            {
                DependsOn = new BatchTaskDependencies() { TaskIds = { "Rain", "Sun" } }
            },
        };
        #endregion
        return tasks;
    }

    public static IList<BatchTaskCreateOptions> RangeDependency()
    {
        #region Snippet:task_deps_range
        IList<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>
        {
            // Tasks 1, 2, and 3 don't depend on any other tasks. Because
            // we will be using them for a task range dependency, we must
            // specify string representations of integers as their ids.
            new BatchTaskCreateOptions("1", "cmd.exe /c echo 1"),
            new BatchTaskCreateOptions("2", "cmd.exe /c echo 2"),
            new BatchTaskCreateOptions("3", "cmd.exe /c echo 3"),

            // Task 4 depends on a range of tasks, 1 through 3
            new BatchTaskCreateOptions("4", "cmd.exe /c echo 4")
            {
                // To use a range of tasks, their ids must be integer values.
                // Note that we pass integers as parameters to BatchTaskIdRange,
                // but their ids (above) are string representations of the ids.
                DependsOn = new BatchTaskDependencies()
                {
                    TaskIdRanges = { new BatchTaskIdRange(1, 3) }
                }
            },
        };
        #endregion
        return tasks;
    }

    public static IList<BatchTaskCreateOptions> ExitCodeDependency()
    {
        #region Snippet:task_deps_exit_codes
        IList<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>
        {
            // Task A is the parent task.
            new BatchTaskCreateOptions("A", "cmd.exe /c echo A")
            {
                // Specify exit conditions for task A and their dependency actions.
                ExitConditions = new ExitConditions()
                {
                    // If task A exits with a pre-processing error, block any downstream tasks (in this example, task B).
                    PreProcessingError = new ExitOptions()
                    {
                        DependencyAction = DependencyAction.Block
                    },
                    // If task A exits with the specified error codes, block any downstream tasks (in this example, task B).
                    ExitCodes =
                    {
                        new ExitCodeMapping(10, new ExitOptions() { DependencyAction = DependencyAction.Block }),
                        new ExitCodeMapping(20, new ExitOptions() { DependencyAction = DependencyAction.Block })
                    },
                    // If task A succeeds or fails with any other error, any downstream tasks become eligible to run
                    // (in this example, task B).
                    DefaultExitOptions = new ExitOptions()
                    {
                        DependencyAction = DependencyAction.Satisfy
                    }
                }
            },
            // Task B depends on task A. Whether it becomes eligible to run depends on how task A exits.
            new BatchTaskCreateOptions("B", "cmd.exe /c echo B")
            {
                DependsOn = new BatchTaskDependencies() { TaskIds = { "A" } }
            },
        };
        #endregion
        return tasks;
    }
}
