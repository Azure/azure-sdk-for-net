// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   This is the base class to implement when adding a new test scenario to the stress test suite.
/// <summary/>
///
public abstract class TestScenario
{
    /// <summary>The <see cref="TestParameters"/> used to configure this test scenario.</summary>
    internal TestParameters TestScenarioParameters { get; }

    /// <summary> The <see cref="Metrics"/> instance used to send metrics to application insights.</summary>
    internal Metrics MetricsCollection { get; }

    /// <summary> The array of <see cref="Role"/>s needed to run this test scenario.</summary>
    public abstract Role[] Roles { get; }

    /// <summary> The name of this test.</summary>
    public abstract string Name { get; }

    /// <summary>
    ///  Initializes a new Test instance.
    /// </summary>
    ///
    /// <param name="testConfiguration">The <see cref="TestConfiguration" /> to use to configure this test run.</param>
    /// <param name="metrics">The <see cref="Metrics" /> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public TestScenario(TestParameters testParameters,
                                Metrics metrics,
                                string testRunId)
    {
        TestScenarioParameters = testParameters;
        MetricsCollection = metrics;
        MetricsCollection.Client.Context.GlobalProperties["TestRunID"] = testRunId;
    }

    /// <summary>
    ///   Runs all of the roles required for this instance of the send process test scenario.
    /// </summary>
    ///
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
    ///
    public async virtual Task RunTestAsync(CancellationToken cancellationToken)
    {
        var testRunTasks = new List<Task>();

        if (TestScenarioParameters.RunAllRoles)
        {
            foreach (Role role in Roles)
            {
                testRunTasks.Add(RunRoleAsync(role, cancellationToken));
            }
        }
        else
        {
            testRunTasks.Add(RunRoleAsync(Roles[TestScenarioParameters.JobIndex], cancellationToken));
        }

        await Task.WhenAll(testRunTasks).ConfigureAwait(false);
    }

    /// <summary>
    ///   Creates a role instance using all of the default configuration values and runs that role.
    /// </summary>
    ///
    /// <param name="role">The <see cref="Role"/> to run.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
    ///
    internal virtual Task RunRoleAsync(Role role, CancellationToken cancellationToken)
    {
       switch (role)
        {
            case Role.BufferedPublisher:
                var bufferedPublisherConfiguration = new BufferedPublisherConfiguration();
                var bufferedPublisher = new BufferedPublisher(TestScenarioParameters, bufferedPublisherConfiguration, MetricsCollection);
                return Task.Run(() => bufferedPublisher.RunAsync(cancellationToken));

            case Role.Publisher:
                var publisherConfiguration = new PublisherConfiguration();
                var publisher = new Publisher(publisherConfiguration, TestScenarioParameters, MetricsCollection);
                return Task.Run(() => publisher.RunAsync(cancellationToken));

            default:
                throw new NotSupportedException($"Running role { role.ToString() } is not supported by this test scenario.");
        }
    }
}