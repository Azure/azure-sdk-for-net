// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the send receive test scenario.
/// </summary>
///
public abstract class TestScenarioBase
{
    /// <summary> The <see cref="Metrics"/> instance used to send metrics to application insights.</summary>
    internal Metrics _metrics;

    /// <summary> The name of this test.</summary>
    public abstract string Name { get; }

    /// <summary>
    ///  Initializes a new Test instance.
    /// </summary>
    ///
    /// <param name="metrics">The <see cref="Metrics" /> to use to send metrics to Application Insights.</param>
    /// <param name="testRunId">Test Run Id to differ between test runs.</param>
    ///
    public TestScenarioBase(Metrics metrics,
                            string testRunId)
    {
        _metrics = metrics;
        _metrics.Client.Context.GlobalProperties["TestRunID"] = testRunId;
    }

    /// <summary>
    ///   Runs all of the roles required for this instance of the send process test scenario.
    /// </summary>
    ///
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
    ///
    public abstract Task RunTestAsync(CancellationToken cancellationToken);
}
