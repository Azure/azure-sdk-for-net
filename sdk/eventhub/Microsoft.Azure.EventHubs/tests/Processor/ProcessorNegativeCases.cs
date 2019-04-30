// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Processor
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Processor;
    using Xunit;

    public class NegativeCases : ProcessorTestBase
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task HostReregisterShouldFail()
        {
            var eventProcessorHost = new EventProcessorHost(
                string.Empty,
                PartitionReceiver.DefaultConsumerGroupName,
                TestUtility.EventHubsConnectionString,
                TestUtility.StorageConnectionString,
                this.LeaseContainerName);

            try
            {
                // Calling register for the first time should succeed.
                TestUtility.Log("Registering EventProcessorHost for the first time.");
                await eventProcessorHost.RegisterEventProcessorAsync<TestEventProcessor>();

                await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                {
                    TestUtility.Log("Registering EventProcessorHost for the second time which should fail.");
                    await eventProcessorHost.RegisterEventProcessorAsync<TestEventProcessor>();
                });
            }
            finally
            {
                await eventProcessorHost.UnregisterEventProcessorAsync();
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task NonexsistentEntity()
        {
            // Rebuild connection string with a nonexistent entity.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            csb.EntityPath = Guid.NewGuid().ToString();

            var eventProcessorHost = new EventProcessorHost(
                string.Empty,
                PartitionReceiver.DefaultConsumerGroupName,
                csb.ToString(),
                TestUtility.StorageConnectionString,
                this.LeaseContainerName);

            TestUtility.Log("Calling RegisterEventProcessorAsync for a nonexistent entity.");
            var ex = await Assert.ThrowsAsync<EventProcessorConfigurationException>(async () =>
            {
                await eventProcessorHost.RegisterEventProcessorAsync<TestEventProcessor>();
            });

            Assert.NotNull(ex.InnerException);
            Assert.IsType<MessagingEntityNotFoundException>(ex.InnerException);
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public void InvalidPartitionManagerOptions()
        {
            var pmo = new PartitionManagerOptions()
            {
                LeaseDuration = TimeSpan.FromSeconds(30),
                RenewInterval = TimeSpan.FromSeconds(20)
            };

            Assert.Throws<ArgumentException>(() =>
            {
                TestUtility.Log("Setting lease duration smaller than the renew interval should fail.");
                pmo.LeaseDuration = TimeSpan.FromSeconds(15);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                TestUtility.Log("Setting renew interval greater than the lease duration should fail.");
                pmo.RenewInterval = TimeSpan.FromSeconds(45);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                TestUtility.Log("Setting lease duration outside of allowed range should fail.");
                pmo.LeaseDuration = TimeSpan.FromSeconds(65);
            });
        }
    }
}
