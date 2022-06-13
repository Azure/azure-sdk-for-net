// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Messaging.EventHubs.Stress;

public class BurstBufferedProducerTest
{
    private readonly TestConfiguration _testConfiguration;
    private readonly string _jobIndex;
    private Metrics _metrics;

    private static Role[] _roles = {Role.BufferedPublisher, Role.BufferedPublisher};

    public BurstBufferedProducerTest(TestConfiguration testConfiguration, Metrics metrics, string jobIndex = default)
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
            case Role.BufferedPublisher:
                var publisherConfiguration = new BufferedPublisherConfiguration();
                var publisher = new BufferedPublisher(_testConfiguration, publisherConfiguration, _metrics);
                await publisher.Start(cancellationToken).ConfigureAwait(false);
                break;

            default:
                break;
        }
    }
}