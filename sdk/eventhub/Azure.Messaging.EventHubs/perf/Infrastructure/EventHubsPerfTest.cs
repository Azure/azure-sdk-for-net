// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Messaging.EventHubs.Tests;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Perf
{
    /// <summary>
    ///   A base class for Event Hubs performance test scenarios, facilitating.
    /// </summary>
    ///
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeCountOptions}" />
    ///
    public abstract class EventHubsPerfTest : PerfTest<SizeCountOptions>
    {
        /// <summary>
        ///   The active <see cref="EventHubsTestEnvironment" /> instance for the
        ///   performance test scenarios.
        /// </summary>
        ///
        protected EventHubsTestEnvironment TestEnvironment => EventHubsTestEnvironment.Instance;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsPerfTest"/> class.
        /// </summary>
        ///
        /// /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        protected EventHubsPerfTest(SizeCountOptions options) : base(options)
        {
        }

        /// <summary>
        ///   Executes the performance test scenario synchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public override void Run(CancellationToken cancellationToken) => throw new InvalidOperationException("Only asynchronous execution is supported.");
    }
}
