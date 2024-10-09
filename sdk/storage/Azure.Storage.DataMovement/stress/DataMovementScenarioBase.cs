// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the send receive test scenario.
/// </summary>
///
public abstract class DataMovementScenarioBase : TestScenarioBase
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

        // Add metric call backs when progress is made
        _dataTransferOptions.TransferStatusChanged += (sender, e) =>
        {
            _metrics.AddMetric(e);
        };
    }

    public Task DisposeAsync()
    {

    }
}
