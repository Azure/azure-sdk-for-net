// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Azure.Storage.Stress;

/// <summary>
///   The set of metrics and the <see cref="TelemetryClient" /> used to collect information
///   from test runs and send them to Application Insights.
/// </summary>
///
public class Metrics
{
    /// <summary>
    ///   The Client used to communicate with Application Insights.
    /// </summary>
    ///
    public TelemetryClient Client { get; }

    /// <summary>
    ///   This is the metric name used to collect metrics on generation zero
    ///   garbage collection.
    /// </summary>
    ///
    public const string GenerationZeroCollections = "GenerationZeroCollections";

    /// <summary>
    ///   This is the metric name used to collect metrics on generation one
    ///   garbage collection.
    /// </summary>
    ///
    public const string GenerationOneCollections = "GenerationOneCollections";

    /// <summary>
    ///   This is the metric name used to collect metrics on generation two
    ///   garbage collection.
    /// </summary>
    ///
    public const string GenerationTwoCollections = "GenerationTwoCollections";

    /// <summary>
    ///   This is the metric name used to collect how many objects (e.g. local file, blob, share file) were transferred.
    /// </summary>
    ///
    public const string ItemTransferCompleted = "ItemTransferCompleted";

    /// <summary>
    ///   This is the metric name used to collect each transfer status that occurred.
    /// </summary>
    public const string TransferStatusChanged = "TransferStatusChanged";

    /// <summary>
    ///   This is the metric name used to keep track of the failed transfer items.
    /// </summary>
    public const string TransferFailedItem = "TransferFailedItem";

    /// <summary>
    ///   This is the metric name used to keep track of the skipped transfer items
    /// </summary>
    public const string ItemTransferSkipped = "ItemTransferSkipped";

    /// <summary>
    ///   This is the metric name used to collect metrics on how many times
    ///   the individual transfer part was restarted or retried.
    /// </summary>
    ///
    public const string TransferRestarted = "TransferRestarted";

    /// <summary>
    ///   This is the metric name used to collect metrics on the total number of bytes that have been
    ///   Sent to the Storage Service over the course of the test run.
    /// </summary>
    ///
    public const string TotalSentSizeBytes = "TotalSentSizeBytes";

    /// <summary>
    ///   This is the dimension name used to hold which identifier is associated with a
    ///   given processor.
    /// </summary>
    ///
    public const string Identifier = "Identifier";

    /// <summary>
    ///   Initializes a new instance of the <see cref="Metrics" /> class.
    /// </summary>
    ///
    /// <param name="connectionString">The instrumentation key associated with the Application Insights resource.</param>
    ///
    public Metrics(string connectionString)
    {
        var configuration = TelemetryConfiguration.CreateDefault();
        configuration.ConnectionString = connectionString;

        Client = new TelemetryClient(configuration);
    }

    /// <summary>
    ///   Collects garbage collection environment metrics and sends them to Application Insights.
    /// </summary>
    ///
    public void UpdateEnvironmentStatistics()
    {
        Client.GetMetric(Metrics.GenerationZeroCollections).TrackValue(GC.CollectionCount(0));
        Client.GetMetric(Metrics.GenerationOneCollections).TrackValue(GC.CollectionCount(1));
        Client.GetMetric(Metrics.GenerationTwoCollections).TrackValue(GC.CollectionCount(2));
    }
}
