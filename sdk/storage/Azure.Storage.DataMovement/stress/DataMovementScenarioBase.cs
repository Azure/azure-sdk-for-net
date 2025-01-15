// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the send receive test scenario.
/// </summary>
///
public abstract class DataMovementScenarioBase : TestScenarioBase, IDisposable
{
    protected internal readonly TransferManagerOptions _transferManagerOptions;
    protected internal readonly TransferOptions _transferOptions;

    public DataMovementScenarioBase(
        TransferManagerOptions transferManagerOptions,
        TransferOptions transferOptions,
        Metrics metrics,
        string testRunId)
        : base(metrics, testRunId)
    {
        _transferManagerOptions = transferManagerOptions;
        _transferOptions = transferOptions;

        // Add metric call backs when transfer has updated
        _transferOptions.TransferStatusChanged += AddStatusMetricArg;
        _transferOptions.ItemTransferFailed += AddFailedMetricArg;
        _transferOptions.ItemTransferCompleted += AddCompletedItemMetricArg;
        _transferOptions.ItemTransferSkipped += AddSkippedItemMetricArg;
    }

    public void Dispose()
    {
        _transferOptions.TransferStatusChanged -= AddStatusMetricArg;
        _transferOptions.ItemTransferFailed -= AddFailedMetricArg;
        _transferOptions.ItemTransferCompleted -= AddCompletedItemMetricArg;
        _transferOptions.ItemTransferSkipped -= AddSkippedItemMetricArg;
    }

    private Task AddFailedMetricArg(TransferItemFailedEventArgs args)
    {
        _metrics.Client.GetMetric(Metrics.TransferFailedItem).TrackValue(1);
        return Task.CompletedTask;
    }

    private Task AddStatusMetricArg(TransferStatusEventArgs args)
    {
        _metrics.Client.GetMetric(Metrics.TransferStatusChanged).TrackValue(args.TransferStatus);
        return Task.CompletedTask;
    }

    private Task AddCompletedItemMetricArg(TransferItemCompletedEventArgs args)
    {
        _metrics.Client.GetMetric(Metrics.ItemTransferCompleted).TrackValue(1);
        return Task.CompletedTask;
    }

    private Task AddSkippedItemMetricArg(TransferItemSkippedEventArgs args)
    {
        _metrics.Client.GetMetric(Metrics.ItemTransferSkipped).TrackValue(1);
        return Task.CompletedTask;
    }
}
