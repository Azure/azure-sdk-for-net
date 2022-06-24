// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the Event Producer test scenario.
/// <summary/>
///
public class EventProducerTest
{
    /// <summary>The <see cref="TestConfiguration"/> used to configure this test scenario.</summary>
    private readonly TestConfiguration _testConfiguration;

    /// <summary>The index used to determine which role should be run if this is a distributed test run.</summary>
    private readonly string _jobIndex;

    /// <summary> The <see cref="Metrics"/> instance used to send metrics to application insights.</summary>
    private Metrics _metrics;

    /// <summary> The array of <see cref="Role"/>s needed to run this test scenario.</summary>
    private static Role[] _roles = {Role.Publisher, Role.Publisher};

    /// <summary>
    ///  Initializes a new <see cref="EventProducerTest"/> instance.
    /// </summary>
    ///
    /// <param name="testConfiguration">The <see cref="TestConfiguration"/> to use to configure this test run.</param>
    /// <param name="metrics">The <see cref="Metrics"/> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public EventProducerTest(TestConfiguration testConfiguration,
                             Metrics metrics,
                             string jobIndex = default)
    {
        _testConfiguration = testConfiguration;
        _jobIndex = jobIndex;
        _metrics = metrics;
        _metrics.Client.Context.GlobalProperties["TestRunID"] = $"net-prod-{Guid.NewGuid().ToString()}";
    }

    /// <summary>
    ///   Runs all of the roles required for this instance of the Event Producer test scenario.
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
    private async Task RunRoleAsync(Role role,
                                   CancellationToken cancellationToken)
    {
        switch (role)
        {
            case Role.Publisher:
                var publisherConfiguration = new PublisherConfiguration();
                var publisher = new Publisher(publisherConfiguration, _testConfiguration, _metrics);
                await publisher.RunAsync(cancellationToken).ConfigureAwait(false);
                break;

            case Role.BufferedPublisher:
                var buffpublisherConfiguration = new BufferedPublisherConfiguration();
                var buffpublisher = new BufferedPublisher(_testConfiguration, buffpublisherConfiguration, _metrics);
                await buffpublisher.RunAsync(cancellationToken).ConfigureAwait(false);
                break;

            default:
                throw new NotSupportedException($"Running role { role.ToString() } is not supported by this test scenario.");
        }
    }
}