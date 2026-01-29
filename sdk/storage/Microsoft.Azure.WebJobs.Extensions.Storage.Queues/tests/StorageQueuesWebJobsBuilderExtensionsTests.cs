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

            Assert.That(options.LockPeriod, Is.EqualTo(TimeSpan.FromSeconds(22)));
            Assert.That(options.ListenerLockPeriod, Is.EqualTo(TimeSpan.FromSeconds(22)));
            Assert.That(options.LockAcquisitionTimeout, Is.EqualTo(TimeSpan.FromSeconds(22)));
            Assert.That(options.ListenerLockRecoveryPollingInterval, Is.EqualTo(TimeSpan.FromSeconds(22)));
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

            Assert.That(options.BatchSize, Is.EqualTo(30));
            Assert.That(options.NewBatchThreshold, Is.EqualTo(123));
            Assert.That(options.MaxPollingInterval, Is.EqualTo(TimeSpan.FromSeconds(2)));
            Assert.That(options.MaxDequeueCount, Is.EqualTo(10));
            Assert.That(options.VisibilityTimeout, Is.EqualTo(TimeSpan.FromSeconds(15)));
        }

        [Test]
        public void ConfigureOptions_SetsPollingIntervalToTwoSecondsInDevelopment()
        {
            var values = new Dictionary<string, string>
            {
            };

            QueuesOptions options = TestHelpers.GetConfiguredOptions<QueuesOptions>(b =>
            {
                b.AddAzureStorageQueues();
            }, values, env: "Development");

            Assert.That(options.MaxPollingInterval, Is.EqualTo(TimeSpan.FromSeconds(2)));
        }

        [Test]
        public void ConfigureOptions_HonorsExplicitlySetPollingIntervalInDevelopment()
        {
            string extensionPath = "AzureWebJobs:Extensions:Queues";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:MaxPollingInterval", "00:00:42" },
            };

            QueuesOptions options = TestHelpers.GetConfiguredOptions<QueuesOptions>(b =>
            {
                b.AddAzureStorageQueues();
            }, values, env: "Development");

            Assert.That(options.MaxPollingInterval, Is.EqualTo(TimeSpan.FromSeconds(42)));
        }
    }
}
