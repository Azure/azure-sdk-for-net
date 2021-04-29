// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class StorageQueuesWebJobsBuilderExtensionsTests
    {
        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly_Singleton()
        {
            string path = "AzureWebJobs:Singleton";
            var values = new Dictionary<string, string>
            {
                { $"{path}:LockPeriod", "00:00:22" },
                { $"{path}:ListenerLockPeriod", "00:00:22" },
                { $"{path}:LockAcquisitionTimeout", "00:00:22" },
                { $"{path}:LockAcquisitionPollingInterval", "00:00:22" },
                { $"{path}:ListenerLockRecoveryPollingInterval", "00:00:22" }
            };

            SingletonOptions options = TestHelpers.GetConfiguredOptions<SingletonOptions>(b =>
            {
                b.AddAzureStorageQueues();
            }, values);

            Assert.AreEqual(TimeSpan.FromSeconds(22), options.LockPeriod);
            Assert.AreEqual(TimeSpan.FromSeconds(22), options.ListenerLockPeriod);
            Assert.AreEqual(TimeSpan.FromSeconds(22), options.LockAcquisitionTimeout);
            Assert.AreEqual(TimeSpan.FromSeconds(22), options.ListenerLockRecoveryPollingInterval);
            Assert.AreEqual(TimeSpan.FromSeconds(22), options.ListenerLockRecoveryPollingInterval);
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly_Queues()
        {
            string extensionPath = "AzureWebJobs:Extensions:Queues";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:BatchSize", "30" },
                { $"{extensionPath}:NewBatchThreshold", "123" },
                { $"{extensionPath}:MaxPollingInterval", "00:00:02" },
                { $"{extensionPath}:MaxDequeueCount", "10" },
                { $"{extensionPath}:VisibilityTimeout", "00:00:15" }
            };

            QueuesOptions options = TestHelpers.GetConfiguredOptions<QueuesOptions>(b =>
            {
                b.AddAzureStorageQueues();
            }, values);

            Assert.AreEqual(30, options.BatchSize);
            Assert.AreEqual(123, options.NewBatchThreshold);
            Assert.AreEqual(TimeSpan.FromSeconds(2), options.MaxPollingInterval);
            Assert.AreEqual(10, options.MaxDequeueCount);
            Assert.AreEqual(TimeSpan.FromSeconds(15), options.VisibilityTimeout);
        }
    }
}
