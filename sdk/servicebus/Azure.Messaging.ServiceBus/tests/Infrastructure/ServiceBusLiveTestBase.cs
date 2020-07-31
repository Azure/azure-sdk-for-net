// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public abstract class ServiceBusLiveTestBase : ServiceBusTestBase
    {
        public ServiceBusTestEnvironment TestEnvironment { get; } = ServiceBusTestEnvironment.Instance;

        protected ServiceBusClient GetNoRetryClient()
        {
            var options =
                new ServiceBusClientOptions
                {
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(10),
                        MaxRetries = 0
                    }
                };
            return new ServiceBusClient(
                TestEnvironment.ServiceBusConnectionString,
                options);
        }

        protected ServiceBusClient GetClient(int tryTimeout = 10)
        {
            var retryOptions = new ServiceBusRetryOptions();
            if (tryTimeout != default)
            {
                retryOptions.TryTimeout = TimeSpan.FromSeconds(tryTimeout);
            }
            return new ServiceBusClient(
                TestEnvironment.ServiceBusConnectionString,
                new ServiceBusClientOptions
                {
                    RetryOptions = retryOptions
                });
        }
    }
}
