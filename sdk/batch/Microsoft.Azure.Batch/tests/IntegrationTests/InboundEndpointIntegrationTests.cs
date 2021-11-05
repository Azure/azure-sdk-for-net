// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;

    public class InboundEndpointIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public InboundEndpointIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void WhenPoolCreatedWithInboundEndpoints_EndpointsAreReturnedByPoolAndComputeNodes()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "InboundEndpoints-" + TestUtilities.GetMyName();

                try
                {
                    var pool = CreatePool(batchCli, poolId);
                    pool.NetworkConfiguration = GetNetworkConfiguration();
                    pool.Commit();

                    var actualPool = batchCli.PoolOperations.GetPool(poolId);

                    var expectedInboundNatPools = pool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.OrderBy(inp => inp.Name).ToList();
                    var actualInboundNatPools = actualPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.OrderBy(inp => inp.Name).ToList();

                    Assert.Equal(expectedInboundNatPools.Count, actualInboundNatPools.Count);

                    for (var i = 0; i < expectedInboundNatPools.Count; i++)
                    {
                        ValidateEquality(expectedInboundNatPools[i], actualInboundNatPools[i]);

                        ValidateNatPool(expectedInboundNatPools[i], actualInboundNatPools[i]);
                    }
                }
                finally
                {
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        private static void ValidateNatPool(InboundNatPool expectedNatPool, InboundNatPool actualNatPool)
        {
            if (expectedNatPool.NetworkSecurityGroupRules != null &&
                expectedNatPool.NetworkSecurityGroupRules.Count > 0)
            {
                var expectedNetworkSecurityGroups =
                    expectedNatPool.NetworkSecurityGroupRules.OrderBy(nsgr => nsgr.Priority).ToList();
                var actualNetworkSecurityGroups =
                    actualNatPool.NetworkSecurityGroupRules.OrderBy(nsgr => nsgr.Priority).ToList();

                Assert.Equal(expectedNetworkSecurityGroups.Count, actualNetworkSecurityGroups.Count);

                for (int j = 0; j < expectedNetworkSecurityGroups.Count; j++)
                {
                    ValidateEquality(expectedNetworkSecurityGroups[j], actualNetworkSecurityGroups[j]);
                }
            }
        }

        private static CloudPool CreatePool(BatchClient batchCli, string poolId)
        {
            var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

            VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                ubuntuImageDetails.ImageReference,
                nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

            return batchCli.PoolOperations.CreatePool(
                poolId: poolId,
                virtualMachineSize: PoolFixture.VMSize,
                virtualMachineConfiguration: virtualMachineConfiguration,
                targetDedicatedComputeNodes: 1);
        }

        private static NetworkConfiguration GetNetworkConfiguration()
        {
            var inboundNatPools = new List<InboundNatPool>
            {
                new InboundNatPool("endpoint1", InboundEndpointProtocol.Tcp, 1024, 20000, 20050),

                new InboundNatPool("endpoint2", InboundEndpointProtocol.Udp, 2048, 30000, 30050,
                    new List<NetworkSecurityGroupRule>
                    {
                        new NetworkSecurityGroupRule(200, NetworkSecurityGroupRuleAccess.Allow, "10.0.0.1"),
                        new NetworkSecurityGroupRule(250, NetworkSecurityGroupRuleAccess.Deny, "*"),
                    }),
            };

            return new NetworkConfiguration
            {
                EndpointConfiguration = new PoolEndpointConfiguration(inboundNatPools),
            };
        }

        private static void ValidateEquality(InboundNatPool expectedInboundNatPool, InboundNatPool actualInboundNatPool)
        {
            Assert.Equal(expectedInboundNatPool.Name, actualInboundNatPool.Name);
            Assert.Equal(expectedInboundNatPool.BackendPort, actualInboundNatPool.BackendPort);
            Assert.Equal(expectedInboundNatPool.FrontendPortRangeStart, actualInboundNatPool.FrontendPortRangeStart);
            Assert.Equal(expectedInboundNatPool.FrontendPortRangeEnd, actualInboundNatPool.FrontendPortRangeEnd);
            Assert.Equal(expectedInboundNatPool.Protocol, actualInboundNatPool.Protocol);
        }

        private static void ValidateEquality(NetworkSecurityGroupRule expectedNetworkSecurityGroupRule, NetworkSecurityGroupRule actualNetworkSecurityGroupRule)
        {
            Assert.Equal(expectedNetworkSecurityGroupRule.Priority, actualNetworkSecurityGroupRule.Priority);
            Assert.Equal(expectedNetworkSecurityGroupRule.Access, actualNetworkSecurityGroupRule.Access);
            Assert.Equal(expectedNetworkSecurityGroupRule.SourceAddressPrefix, actualNetworkSecurityGroupRule.SourceAddressPrefix);
            if(expectedNetworkSecurityGroupRule.SourcePortRanges == null)
            {
                // the default is "*"
                Assert.Equal(new List<string> { "*" }, actualNetworkSecurityGroupRule.SourcePortRanges);
            }
            else
            {
                Assert.Equal(expectedNetworkSecurityGroupRule.SourcePortRanges, actualNetworkSecurityGroupRule.SourcePortRanges);
            }
        }
    }
}
