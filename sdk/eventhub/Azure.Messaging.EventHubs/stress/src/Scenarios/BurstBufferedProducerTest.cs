// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the burst Buffered Producer test scenario.
/// <summary/>
///
public class BurstBufferedProducerTest
{
    /// <summary>The <see cref="TestParameters"/> used to configure this test scenario.</summary>
    private readonly TestParameters _testParameters;

    /// <summary>The index used to determine which role should be run if this is a distributed test run.</summary>
    private readonly string _jobIndex;

    /// <summary> The <see cref="Metrics"/> instance used to send metrics to application insights.</summary>
    private Metrics _metrics;

    /// <summary> The set of <see cref="Role"/>s needed to run this test scenario.</summary>

    private static Role[] _roles = {Role.BufferedPublisher};

    /// <summary>
    ///  Initializes a new <see cref="BurstBufferedProducerTest"/> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters"/> to use to run this test.</param>
    /// <param name="metrics">The <see cref="Metrics"/> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public BurstBufferedProducerTest(TestParameters testParameters,
                                     Metrics metrics,
                                     string jobIndex = default)
    {
        _testParameters = testParameters;
        _jobIndex = jobIndex;
        _metrics = metrics;
        _metrics.Client.Context.GlobalProperties["TestRunID"] = $"net-burst-buff-{Guid.NewGuid().ToString()}";
    }

    /// <summary>
    ///   Runs all of the roles required for this instance of the burst Buffered Producer test scenario.
    /// </summary>
    ///
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunTestAsync(CancellationToken cancellationToken)
    {
        var runAllRoles = !int.TryParse(_jobIndex, out var roleIndex);
        var testRunTasks = new List<Task>();

        if (runAllRoles)
        {
            foreach (Role role in _roles)
            {
                testRunTasks.Add(RunRoleAsync(role, cancellationToken));
            }
        }
        else
        {
            testRunTasks.Add(RunRoleAsync(_roles[roleIndex], cancellationToken));
        }

        await Task.WhenAll(testRunTasks).ConfigureAwait(false);
    }

    /// <summary>
    ///   Creates a role instance and runs that role.
    /// </summary>
    ///
    /// <param name="role">The <see cref="Role"/> to run.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    private Task RunRoleAsync(Role role,
                              CancellationToken cancellationToken)
    {
        switch (role)
        {
            case Role.BufferedPublisher:
                var publisherConfiguration = new BufferedPublisherConfiguration();
                var publisher = new BufferedPublisher(_testParameters, publisherConfiguration, _metrics);
                return Task.Run(() => publisher.RunAsync(cancellationToken));

            default:
                throw new NotSupportedException($"Running role { role.ToString() } is not supported by this test scenario.");
        }
    }
}