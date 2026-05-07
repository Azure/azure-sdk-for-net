// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-automatic-scaling.md.
// Pool create with autoscale uses Azure.ResourceManager.Batch (ARM).
// Enable / Evaluate AutoScale operations live on Azure.Compute.Batch.BatchClient.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class AutomaticScaling
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;

    public static async Task CreateAutoScalePoolAsync()
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:autoscale_pool_create
        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "standard_d1_v2",
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(
                    imageReference: new BatchImageReference()
                    {
                        Publisher = "MicrosoftWindowsServer",
                        Offer = "WindowsServer",
                        Sku = "2019-datacenter-core",
                        Version = "latest"
                    },
                    nodeAgentSkuId: "batch.node.windows amd64")
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                AutoScale = new BatchAccountAutoScaleSettings(
                    formula: "$TargetDedicatedNodes = (time().weekday == 1 ? 5:1);")
                {
                    EvaluationInterval = TimeSpan.FromMinutes(30)
                }
            }
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, "mypool", poolData);
        #endregion
    }

    public static async Task EnableAutoScaleAsync()
    {
        #region Snippet:autoscale_enable
        // Define the autoscaling formula. This formula sets the target number of nodes
        // to 5 on Mondays, and 1 on every other day of the week
        string myAutoScaleFormula = "$TargetDedicatedNodes = (time().weekday == 1 ? 5:1);";

        // Set the autoscale formula on the existing pool
        await batchClient.EnablePoolAutoScaleAsync(
            "myexistingpool",
            new BatchPoolEnableAutoScaleOptions() { AutoScaleFormula = myAutoScaleFormula });
        #endregion
    }

    public static async Task ChangeAutoScaleFormulaAsync(string myNewFormula)
    {
        #region Snippet:autoscale_change_formula
        await batchClient.EnablePoolAutoScaleAsync(
            "myexistingpool",
            new BatchPoolEnableAutoScaleOptions() { AutoScaleFormula = myNewFormula });
        #endregion
    }

    public static async Task ChangeEvaluationIntervalAsync()
    {
        #region Snippet:autoscale_change_interval
        await batchClient.EnablePoolAutoScaleAsync(
            "myexistingpool",
            new BatchPoolEnableAutoScaleOptions()
            {
                AutoScaleEvaluationInterval = TimeSpan.FromMinutes(60)
            });
        #endregion
    }

    public static async Task EvaluateAutoScaleAsync()
    {
        #region Snippet:autoscale_evaluate
        // First obtain a reference to an existing pool
        BatchPool pool = await batchClient.GetPoolAsync("myExistingPool");

        // If autoscaling isn't already enabled on the pool, enable it.
        // You can't evaluate an autoscale formula on a non-autoscale-enabled pool.
        if (pool.EnableAutoScale != true)
        {
            // You need a valid autoscale formula to enable autoscaling on the
            // pool. This formula is valid, but won't resize the pool:
            await batchClient.EnablePoolAutoScaleAsync(
                pool.Id,
                new BatchPoolEnableAutoScaleOptions()
                {
                    AutoScaleFormula = "$TargetDedicatedNodes = $CurrentDedicatedNodes;",
                    AutoScaleEvaluationInterval = TimeSpan.FromMinutes(5)
                });

            // Batch limits EnablePoolAutoScale calls to once every 30 seconds.
            await Task.Delay(TimeSpan.FromSeconds(31));

            // Refresh the properties of the pool so that we've got the
            // latest value for EnableAutoScale.
            pool = await batchClient.GetPoolAsync(pool.Id);
        }

        // You must ensure that autoscaling is enabled on the pool prior to
        // evaluating a formula
        if (pool.EnableAutoScale == true)
        {
            // The formula to evaluate - adjusts target number of nodes based on
            // day of week and time of day
            string myFormula = @"
                $curTime = time();
                $workHours = $curTime.hour >= 8 && $curTime.hour < 18;
                $isWeekday = $curTime.weekday >= 1 && $curTime.weekday <= 5;
                $isWorkingWeekdayHour = $workHours && $isWeekday;
                $TargetDedicatedNodes = $isWorkingWeekdayHour ? 20:10;
            ";

            // Perform the autoscale formula evaluation. Note that this code does not
            // actually apply the formula to the pool.
            AutoScaleRun eval = await batchClient.EvaluatePoolAutoScaleAsync(
                pool.Id,
                new BatchPoolEvaluateAutoScaleOptions(myFormula));

            if (eval.Error == null)
            {
                Console.WriteLine("AutoScaleRun.Results: " +
                    eval.Results.Replace("$", "\n    $"));

                // Apply the formula to the pool since it evaluated successfully
                await batchClient.EnablePoolAutoScaleAsync(
                    pool.Id,
                    new BatchPoolEnableAutoScaleOptions() { AutoScaleFormula = myFormula });
            }
            else
            {
                Console.WriteLine("AutoScaleRun.Error.Message: " + eval.Error.Message);
            }
        }
        #endregion
    }

    public static async Task ReadAutoScaleRunAsync()
    {
        #region Snippet:autoscale_read_run
        BatchPool pool = await batchClient.GetPoolAsync("myPool");
        Console.WriteLine("Last execution: " + pool.AutoScaleRun.Timestamp);
        Console.WriteLine("Result:" + pool.AutoScaleRun.Results.Replace("$", "\n  $"));
        Console.WriteLine("Error: " + pool.AutoScaleRun.Error);
        #endregion
    }
}
