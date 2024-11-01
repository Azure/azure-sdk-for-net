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
    protected internal readonly DataTransferOptions _dataTransferOptions;

    public DataMovementScenarioBase(
        TransferManagerOptions transferManagerOptions,
        DataTransferOptions dataTransferOptions,
        Metrics metrics,
        string testRunId)
        : base(metrics, testRunId)
    {
        _transferManagerOptions = transferManagerOptions;
        _dataTransferOptions = dataTransferOptions;

        // Add metric call backs when transfer has updated
        _dataTransferOptions.TransferStatusChanged += AddStatusMetricArg;
        _dataTransferOptions.ItemTransferFailed += AddFailedMetricArg;
        _dataTransferOptions.ItemTransferCompleted += AddCompletedItemMetricArg;
        _dataTransferOptions.ItemTransferSkipped += AddSkippedItemMetricArg;
    }

    public void Dispose()
    {
        _dataTransferOptions.TransferStatusChanged -= AddStatusMetricArg;
        _dataTransferOptions.ItemTransferFailed -= AddFailedMetricArg;
        _dataTransferOptions.ItemTransferCompleted -= AddCompletedItemMetricArg;
        _dataTransferOptions.ItemTransferSkipped -= AddSkippedItemMetricArg;
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
