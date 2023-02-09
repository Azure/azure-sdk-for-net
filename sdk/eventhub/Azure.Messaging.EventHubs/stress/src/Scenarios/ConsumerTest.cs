// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections.Concurrent;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the Consumer test scenario.
/// <summary/>
///
public class ConsumerTest : TestScenario
{
    /// <summary> The name of this test.</summary>
    public override string Name { get; } = "ConsumerTest";

    /// <summary> The array of <see cref="Role"/>s needed to run this test scenario.</summary>
    public override Role[] Roles { get; } = {Role.PartitionPublisher, Role.Consumer};

    /// <summary>The ids of all of the partitions.</summary>
    private string[] _partitionIds;

    /// <summary>Holds the set of events that have been read by this instance. The key is the unique Id set by the producer.</summary>
    private ConcurrentDictionary<string, byte> _readEvents { get; } = new ConcurrentDictionary<string, byte>();

    /// <summary>Holds the last read sequence value for each partition this instance has read from so far.</summary>
    private ConcurrentDictionary<string, int> _lastReadPartitionSequence { get; } = new ConcurrentDictionary<string, int>();

    /// <summary>
    ///  Initializes a new <see cref="ConsumerTest"/> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters"/> to use to run this test scenario.</param>
    /// <param name="metrics">The <see cref="Metrics"/> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public ConsumerTest(TestParameters testParameters,
                        Metrics metrics) : base(testParameters, metrics, $"net-consumer-{Guid.NewGuid().ToString()}")
    {
    }

    /// <summary>
    ///   Runs all of the roles required for this instance of the Consumer test scenario.
    /// </summary>
    ///
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async override Task RunTestAsync(CancellationToken cancellationToken)
    {
        _partitionIds = await _testParameters.GetEventHubPartitionsAsync().ConfigureAwait(false);
        var partitionCount = _partitionIds.Length;

        var testRunTasks = new List<Task>();

        if (_testParameters.RunAllRoles)
        {
            foreach (Role role in Roles)
            {
                testRunTasks.Add(RunRoleAsync(role, cancellationToken));
            }
        }
        else
        {
            testRunTasks.Add(RunRoleAsync(Roles[_testParameters.JobIndex], cancellationToken));
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
    internal override Task RunRoleAsync(Role role,
                              CancellationToken cancellationToken)
    {
        switch (role)
        {
            case Role.Consumer:
                var consumerConfiguration = new ConsumerConfiguration();
                var consumer = new Consumer(_testParameters, consumerConfiguration, _metrics, _readEvents, _lastReadPartitionSequence);
                return Task.Run(() => consumer.RunAsync(cancellationToken));

            case Role.PartitionPublisher:
                var partitionPublisherConfiguration = new PartitionPublisherConfiguration();
                var partitionsCount = _partitionIds.Length;
                var partitions = EventTracking.GetAssignedPartitions(partitionsCount, _testParameters.JobIndex, _partitionIds, Roles);

                var partitionPublisher = new PartitionPublisher(partitionPublisherConfiguration, _testParameters, _metrics, partitions);
                return Task.Run(() => partitionPublisher.RunAsync(cancellationToken));

            default:
                throw new NotSupportedException($"Running role { role.ToString() } is not supported by this test scenario.");
        }
    }
}