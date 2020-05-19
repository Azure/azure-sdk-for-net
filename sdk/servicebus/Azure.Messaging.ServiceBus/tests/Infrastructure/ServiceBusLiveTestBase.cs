﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// <summary>
        /// Add a static TestEventListener which will redirect SDK logging
        /// to Console.Out for easy debugging.
        /// </summary>
        private static TestLogger Logger { get; set; }

        /// <summary>
        /// Start logging events to the console if debugging or in Live mode.
        /// This will run once before any tests.
        /// </summary>
        [OneTimeSetUp]
        public virtual void StartLoggingEvents()
        {
            Logger = new TestLogger();
            TestContext.Out.WriteLine($"new test logger for {TestContext.CurrentContext.Test}, {GetHashCode()}" );
        }

        /// <summary>
        /// Stop logging events and do necessary cleanup.
        /// This will run once after all tests have finished.
        /// </summary>
        [OneTimeTearDown]
        public void StopLoggingEvents()
        {
            Logger?.Dispose();
            Logger = null;
        }

        public ServiceBusTestEnvironment TestEnvironment { get; } = ServiceBusTestEnvironment.Instance;

        protected ServiceBusClient GetNoRetryClient()
        {
            var options =
                new ServiceBusClientOptions
                {
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(5),
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
