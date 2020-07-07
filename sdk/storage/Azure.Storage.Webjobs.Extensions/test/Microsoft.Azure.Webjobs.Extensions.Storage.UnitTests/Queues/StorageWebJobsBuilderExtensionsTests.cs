// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.UnitTests.Queues
{
    public class StorageWebJobsBuilderExtensionsTests
    {
        [Fact]
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
                b.AddAzureStorage();
            }, values);

            Assert.Equal(TimeSpan.FromSeconds(22), options.LockPeriod);
            Assert.Equal(TimeSpan.FromSeconds(22), options.ListenerLockPeriod);
            Assert.Equal(TimeSpan.FromSeconds(22), options.LockAcquisitionTimeout);
            Assert.Equal(TimeSpan.FromSeconds(22), options.ListenerLockRecoveryPollingInterval);
            Assert.Equal(TimeSpan.FromSeconds(22), options.ListenerLockRecoveryPollingInterval);
        }

        [Fact]
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
                b.AddAzureStorage();
            }, values);

            Assert.Equal(30, options.BatchSize);
            Assert.Equal(123, options.NewBatchThreshold);
            Assert.Equal(TimeSpan.FromSeconds(2), options.MaxPollingInterval);
            Assert.Equal(10, options.MaxDequeueCount);
            Assert.Equal(TimeSpan.FromSeconds(15), options.VisibilityTimeout);
        }

        [Fact]
        public void ConfigureOptions_AppliesValuesCorrectly_Blobs()
        {
            string extensionPath = "AzureWebJobs:Extensions:Blobs";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:CentralizedPoisonQueue", "true" },
            };

            BlobsOptions options = TestHelpers.GetConfiguredOptions<BlobsOptions>(b =>
            {
                b.AddAzureStorage();
            }, values);

            Assert.Equal(true, options.CentralizedPoisonQueue);
        }
    }
}
