// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class ContainerServiceOperationalTests : ContainerServiceTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Container Service
        /// Get Container Service
        /// Delete Container Service
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestDCOSOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                m_location = "australiasoutheast"; // TODO: For now, APIs nly work in this region under BU endpoint

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var csName = TestUtilities.GenerateName(ContainerServiceNamePrefix);
                var masterDnsPrefixName = TestUtilities.GenerateName(MasterProfileDnsPrefix);
                var agentPoolDnsPrefixName = TestUtilities.GenerateName(AgentPoolProfileDnsPrefix);
                try
                {
                    ContainerService inputContainerService;
                    var containerService = CreateContainerService_NoAsyncTracking(
                        rgName,
                        csName,
                        masterDnsPrefixName,
                        agentPoolDnsPrefixName,
                        out inputContainerService,
                        cs => cs.OrchestratorProfile.OrchestratorType = ContainerServiceOchestratorTypes.DCOS);
                    m_CrpClient.ContainerServices.Delete(rgName, containerService.Name);
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Container Service
        /// Get Container Service
        /// Delete Container Service
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestSwarmOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                m_location = "australiasoutheast"; // TODO: For now, APIs nly work in this region under BU endpoint

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var csName = TestUtilities.GenerateName(ContainerServiceNamePrefix);
                var masterDnsPrefixName = TestUtilities.GenerateName(MasterProfileDnsPrefix);
                var agentPoolDnsPrefixName = TestUtilities.GenerateName(AgentPoolProfileDnsPrefix);
                try
                {
                    ContainerService inputContainerService;
                    var containerService = CreateContainerService_NoAsyncTracking(
                        rgName,
                        csName,
                        masterDnsPrefixName,
                        agentPoolDnsPrefixName,
                        out inputContainerService,
                        cs => cs.OrchestratorProfile.OrchestratorType = ContainerServiceOchestratorTypes.Swarm);
                    m_CrpClient.ContainerServices.Delete(rgName, containerService.Name);
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}