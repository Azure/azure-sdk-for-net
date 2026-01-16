// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    public class BatchNodeIntegrationTests : BatchLiveTestBase
    {
        /// <summary>BatchNodeIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchNodeIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchNodeIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchNodeIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListBatchNode()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "ListBatchNode", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(2);

                int count = 0;
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    count++;
                }

                // verify we found at least one poolnode
                Assert.That(count, Is.EqualTo(2));
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task BatchNodeUser()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "BatchNodeUser", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;
            var userName = "User1";
            var userPassWord = "Password1";
            var updatedPassWord = "Password2";

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                string batchNodeID = "";
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    batchNodeID = item.Id;
                }
                Assert.That(batchNodeID, Is.Not.Empty);

                // create new user
                BatchNodeUserCreateOptions user = new BatchNodeUserCreateOptions(userName)
                {
                    Password = userPassWord
                };
                Response response = await client.CreateNodeUserAsync(poolID, batchNodeID, user);
                Assert.That(response.IsError, Is.False);

                // update users password
                BatchNodeUserUpdateOptions content = new BatchNodeUserUpdateOptions()
                {
                    Password = updatedPassWord
                };
                response = await client.ReplaceNodeUserAsync(poolID, batchNodeID, userName, content);
                Assert.That(response.IsError, Is.False);

                // delete uswer
                response = await client.DeleteNodeUserAsync(poolID, batchNodeID, userName);
                Assert.That(response.IsError, Is.False);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task RebootBatchNode()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "RebootBatchNode", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                string batchNodeID = "";
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    batchNodeID = item.Id;
                }
                Assert.That(batchNodeID, Is.Not.Empty);

                // reboot node
                RebootNodeOperation rebootNodeOperation = await client.RebootNodeAsync(poolID, batchNodeID);

                BatchNode node = await rebootNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.That(rebootNodeOperation.HasCompleted, Is.True);
                Assert.That(rebootNodeOperation.HasValue, Is.True);
                Assert.That(rebootNodeOperation.GetRawResponse().IsError, Is.False);
                await iaasWindowsPoolFixture.WaitForPoolAllocation(client, poolID);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task ReImageBatchNode()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "ReImageBatchNode", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                string batchNodeID = "";
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    batchNodeID = item.Id;
                }
                Assert.That(batchNodeID, Is.Not.Empty);

                // reboot node
                ReimageNodeOperation reImageNodeOperation = await client.ReimageNodeAsync(poolID, batchNodeID);

                BatchNode node = await reImageNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);

                Assert.That(reImageNodeOperation.GetRawResponse().IsError, Is.False);
                Assert.That(reImageNodeOperation.HasCompleted, Is.True);
                Assert.That(reImageNodeOperation.HasValue, Is.True);
                await iaasWindowsPoolFixture.WaitForPoolAllocation(client, poolID);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task DeallocateandStartBatchNode()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "DeallocateandStartBatchNode", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                string batchNodeID = "";
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    batchNodeID = item.Id;
                }
                Assert.That(batchNodeID, Is.Not.Empty);

                // Deallocate node
                DeallocateNodeOperation deallocateNodeOperation = await client.DeallocateNodeAsync(poolID, batchNodeID);
                await deallocateNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.That(deallocateNodeOperation.HasCompleted, Is.True);
                Assert.That(deallocateNodeOperation.HasValue, Is.True);
                Assert.That(deallocateNodeOperation.GetRawResponse().IsError, Is.False);
                Assert.That(deallocateNodeOperation.Value.State, Is.EqualTo(BatchNodeState.Deallocated));

                // start node
                StartNodeOperation startNodeOperation = await client.StartNodeAsync(poolID, batchNodeID);
                await startNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.That(startNodeOperation.HasCompleted, Is.True);
                Assert.That(startNodeOperation.HasValue, Is.True);
                Assert.That(startNodeOperation.GetRawResponse().IsError, Is.False);
                Assert.That(startNodeOperation.Value.State, Is.Not.EqualTo(BatchNodeState.Starting));
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        public async Task BatchNodeExtension()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "BatchNodeExtension", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPoolCreateOptions batchPoolCreateOptions = iaasWindowsPoolFixture.CreatePoolOptions(1);
                VMExtension vMExtension = new VMExtension("CustomExtension", "Microsoft.Azure.Geneva", "GenevaMonitoring")
                {
                    TypeHandlerVersion = "2.16",
                    AutoUpgradeMinorVersion = true,
                    EnableAutomaticUpgrade = true,
                    ProtectedSettings = {},
                    Settings = {},
                };
                batchPoolCreateOptions.VirtualMachineConfiguration.Extensions.Add(vMExtension);
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);

                BatchPool pool = await iaasWindowsPoolFixture.WaitForPoolAllocation(client, poolID);

                string batchNodeID = "";
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    batchNodeID = item.Id;
                }
                Assert.That(batchNodeID, Is.Not.Empty);

                BatchNodeVMExtension batchNodeVMExtension1 = await client.GetNodeExtensionAsync(poolID, batchNodeID, "CustomExtension");

                // reboot node
                await foreach (BatchNodeVMExtension item in client.GetNodeExtensionsAsync(poolID, batchNodeID))
                {
                    Assert.That(item, Is.Not.Null);
                    Assert.That(item.VmExtension.Name, Is.Not.Empty);

                    BatchNodeVMExtension batchNodeVMExtension = await client.GetNodeExtensionAsync(poolID, batchNodeID, item.VmExtension.Name);
                    Assert.That(batchNodeVMExtension, Is.Not.Null);
                }
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task GetRemoteLoginSettings()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "GetRemoteLoginSettings", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                BatchPoolCreateOptions batchPoolCreateOptions = iaasWindowsPoolFixture.CreatePoolOptions(1);
                batchPoolCreateOptions.UserAccounts.Add(new UserAccount("testuser", "Password1!"));

                BatchPoolEndpointConfiguration batchPoolEndpointConfiguration = new BatchPoolEndpointConfiguration(new List<BatchInboundNatPool>());
                batchPoolEndpointConfiguration.InboundNatPools.Add(new BatchInboundNatPool("ruleName", InboundEndpointProtocol.Tcp, 3389, 15000, 15100));

                batchPoolCreateOptions.NetworkConfiguration = new NetworkConfiguration()
                {
                    EndpointConfiguration  = batchPoolEndpointConfiguration,
                    PublicIpAddressConfiguration = new BatchPublicIpAddressConfiguration
                    {
                        IpFamilies = { IPFamily.IPv4, IPFamily.IPv6 },
                    }
                };

                // create a pool to verify we have something to query for
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                BatchPool pool = await iaasWindowsPoolFixture.WaitForPoolAllocation(client, poolID);

                string batchNodeID = "";
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    batchNodeID = item.Id;
                }
                Assert.That(batchNodeID, Is.Not.Empty);

                BatchNodeRemoteLoginSettings batchNodeRemoteLoginSettings = await client.GetNodeRemoteLoginSettingsAsync(poolID, batchNodeID);
                Assert.That(batchNodeRemoteLoginSettings, Is.Not.Null);
                Assert.That(batchNodeRemoteLoginSettings.RemoteLoginIpAddress, Is.Not.Null);
                Assert.That(batchNodeRemoteLoginSettings.Ipv6RemoteLoginPort, Is.Not.Null);
                Assert.That(batchNodeRemoteLoginSettings.Ipv6RemoteLoginIpAddress, Is.Not.Null);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task Scheduling()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "Scheduling", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                string batchNodeID = "";
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    batchNodeID = item.Id;
                }
                Assert.That(batchNodeID, Is.Not.Empty);
                BatchNodeDisableSchedulingOptions batchNodeDisableSchedulingContent = new BatchNodeDisableSchedulingOptions()
                {
                    NodeDisableSchedulingOption = BatchNodeDisableSchedulingOption.Terminate,
                };
                Response response = await client.DisableNodeSchedulingAsync(poolID, batchNodeID, batchNodeDisableSchedulingContent);
                Assert.That(response.Status, Is.EqualTo(200));

                response = await client.EnableNodeSchedulingAsync(poolID, batchNodeID);
                Assert.That(response.Status, Is.EqualTo(200));

                UploadBatchServiceLogsOptions uploadBatchServiceLogsContent = new UploadBatchServiceLogsOptions(new Uri("http://contoso.com"), DateTimeOffset.Parse("2026-05-01T00:00:00.0000000Z"));

                UploadBatchServiceLogsResult uploadBatchServiceLogsResult =  await client.UploadNodeLogsAsync(poolID, batchNodeID, uploadBatchServiceLogsContent);
                Assert.That(uploadBatchServiceLogsResult, Is.Not.Null);
                Assert.That(uploadBatchServiceLogsResult.VirtualDirectoryName, Is.Not.Empty);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
