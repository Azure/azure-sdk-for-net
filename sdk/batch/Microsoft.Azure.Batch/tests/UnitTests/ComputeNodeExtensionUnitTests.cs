// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BatchTestCommon;

    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Protocol = Microsoft.Azure.Batch.Protocol;
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using System.Threading;

    public class ComputeNodeExtensionUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestComputeNodeExtensionListAll()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            List<BatchClientBehavior> behaviors = new List<BatchClientBehavior> { CreateListAllInterceptor() };

            NodeVMExtension extension = client.PoolOperations.ListComputeNodeExtensions("poolId", "nodeId", behaviors).FirstOrDefault();
            AssertExtension(extension);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestComputeNodeExtensionGet()
        {
            string name = "getTestExtension";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            List<BatchClientBehavior> behaviors = new List<BatchClientBehavior> { CreateGetInterceptor(name) };

            NodeVMExtension extension = client.PoolOperations.GetComputeNodeExtension("poolId", "nodeId", name, null, behaviors);
            AssertExtension(extension, name);
        }

        private Models.NodeVMExtension CreateExtension(string name = "batchNodeExtension")
        {
            return new Models.NodeVMExtension
            {
                VmExtension = new Models.VMExtension
                {
                    Name = name,
                    Publisher = "Microsoft.Azure.Extensions",
                    Type = "CustomScript",
                    TypeHandlerVersion = "2.0",
                    AutoUpgradeMinorVersion = true
                },
                InstanceView = new Models.VMExtensionInstanceView
                {
                    Name = name,
                    Statuses = new List<Models.InstanceViewStatus>
                    {
                        new Models.InstanceViewStatus(
                            "ProvisioningState/succeeded",
                            "Provisioning succeeded",
                            Models.StatusLevelTypes.Info,
                            "Enable succeeded: Enabling and starting agent and controller")
                    }
                }
            };
        }

        private Protocol.RequestInterceptor CreateListAllInterceptor()
        {
            return new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.ComputeNodeExtensionListOptions, AzureOperationResponse<IPage<Models.NodeVMExtension>, Models.ComputeNodeExtensionListHeaders>>)baseRequest;

                request.ServiceRequestFunc = async (CancellationToken token) =>
                {
                    var response = new AzureOperationResponse<IPage<Models.NodeVMExtension>, Models.ComputeNodeExtensionListHeaders>
                    {
                        Body = new FakePage<Models.NodeVMExtension>(new[] { CreateExtension() })
                    };

                    var task = Task.FromResult(response);
                    return await task;
                };
            });
        }

        private Protocol.RequestInterceptor CreateGetInterceptor(string name)
        {
            return new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.ComputeNodeExtensionGetOptions, AzureOperationResponse<Models.NodeVMExtension, Models.ComputeNodeExtensionGetHeaders>>)baseRequest;

                request.ServiceRequestFunc = async (CancellationToken token) =>
                {
                    var response = new AzureOperationResponse<Models.NodeVMExtension, Models.ComputeNodeExtensionGetHeaders>
                    {
                        Body = CreateExtension(name)
                    };

                    var task = Task.FromResult(response);
                    return await task;
                };
            });
        }

        private void AssertExtension(NodeVMExtension extension, string name = "batchNodeExtension")
        {
            Assert.NotNull(extension);

            Assert.NotNull(extension.VmExtension);
            Assert.Equal(name, extension.VmExtension.Name);
            Assert.Equal("Microsoft.Azure.Extensions", extension.VmExtension.Publisher);
            Assert.Equal("CustomScript", extension.VmExtension.Type);
            Assert.Equal("2.0", extension.VmExtension.TypeHandlerVersion);
            Assert.True(extension.VmExtension.AutoUpgradeMinorVersion);

            Assert.NotNull(extension.InstanceView);
            Assert.Equal(name, extension.InstanceView.Name);

            Assert.NotNull(extension.InstanceView.Statuses);
            Assert.Single(extension.InstanceView.Statuses);
            InstanceViewStatus status = extension.InstanceView.Statuses.First();
            Assert.Equal("ProvisioningState/succeeded", status.Code);
            Assert.Equal("Provisioning succeeded", status.DisplayStatus);
            Assert.True(status.Level.HasValue);
            Assert.Equal(Models.StatusLevelTypes.Info.ToString(), status.Level.Value.ToString());
            Assert.Equal("Enable succeeded: Enabling and starting agent and controller", status.Message);
        }
    }
}
