// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Stress;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Stress.Core
{
    public abstract class ServiceBusTest<TOptions, TMetrics> : StressTest<TOptions, TMetrics> where TOptions: StressOptions where TMetrics : StressMetrics
    {
        protected string ServiceBusConnectionString { get; private set; }
        protected string QueueName { get; private set; }

        protected ServiceBusClient ServiceBusClient { get; private set; }

        protected ServiceBusTest(TOptions options, TMetrics metrics) : base(options, metrics)
        {
            ServiceBusConnectionString = GetEnvironmentVariable("SERVICE_BUS_CONNECTION_STRING");
            QueueName = GetEnvironmentVariable("QUEUE_NAME");

            ServiceBusClient = new ServiceBusClient(ServiceBusConnectionString);
        }

        public override async ValueTask DisposeAsyncCore()
        {
            await ServiceBusClient.DisposeAsync();
            await base.DisposeAsyncCore();
        }

    }
}
