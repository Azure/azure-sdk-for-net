// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Stress;

public class ProcessorTest
{
    private readonly TestConfiguration _testConfiguration;
    private readonly string _jobIndex;
    private Metrics _metrics;

    private static Role[] _roles = {Role.BufferedPublisher, Role.BufferedPublisher};

    public ProcessorTest(TestConfiguration testConfiguration, Metrics metrics, string jobIndex = default)
    {
        _testConfiguration = testConfiguration;
        _jobIndex = jobIndex;
        _metrics = metrics;
        _metrics.Client.Context.GlobalProperties["TestRunID"] = $"net-burst-buff-{Guid.NewGuid().ToString()}";
    }

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

    public async Task RunRoleAsync(Role role, CancellationToken cancellationToken)
    {
        switch (role)
        {
            case Role.Publisher:
                var publisherConfiguration = new PublisherConfiguration();
                var publisher = new Publisher(publisherConfiguration, _testConfiguration, _metrics);
                await publisher.Start(cancellationToken).ConfigureAwait(false);
                break;

            case Role.BufferedPublisher:
                var buffpublisherConfiguration = new BufferedPublisherConfiguration();
                var buffpublisher = new BufferedPublisher(_testConfiguration, buffpublisherConfiguration, _metrics);
                await buffpublisher.Start(cancellationToken).ConfigureAwait(false);
                break;

            case Role.Processor:
                var partitionCount = await _testConfiguration.GetEventHubPartitionCount().ConfigureAwait(false);
                var processorConfiguration = new ProcessorConfiguration();
                var processor = new Processor(_testConfiguration, processorConfiguration, _metrics, partitionCount);
                await processor.Start(cancellationToken).ConfigureAwait(false);
                break;

            default:
                break;
        }
    }
}