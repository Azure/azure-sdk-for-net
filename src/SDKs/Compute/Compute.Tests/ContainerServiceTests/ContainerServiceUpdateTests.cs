// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class ContainerServiceUpdateTests : ContainerServiceTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Container Service
        /// Get Container Service
        /// Update Container Service
        /// Get Container Service 
        /// Delete Container Service
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestContainerServiceUpdateOperations()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var csName = TestUtilities.GenerateName(ContainerServiceNamePrefix);
                var masterDnsPrefixName = TestUtilities.GenerateName(MasterProfileDnsPrefix);
                var agentPoolDnsPrefixName = TestUtilities.GenerateName(AgentPoolProfileDnsPrefix);
                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "australiasoutheast");
                    EnsureClientsInitialized(context);

                    ContainerService inputContainerService;
                    var containerService = CreateContainerService_NoAsyncTracking(
                        rgName,
                        csName,
                        masterDnsPrefixName,
                        agentPoolDnsPrefixName,
                        out inputContainerService, cs =>
                        {
                            cs.AgentPoolProfiles[0].Count = 1;
                            cs.MasterProfile.Count = 1;
                        });

                    // Update Container Service with increased AgentPoolProfiles Count
                    inputContainerService.AgentPoolProfiles[0].Count = 2;
                    UpdateContainerService(rgName, csName, inputContainerService);

                    containerService = m_CrpClient.ContainerServices.Get(rgName, containerService.Name);
                    ValidateContainerService(inputContainerService, containerService);

                    var listResult = m_CrpClient.ContainerServices.ListByResourceGroup(rgName);
#if NET46
                    Assert.True(listResult.Any(a => a.Name == containerService.Name));
#else
                    Assert.Contains(listResult, a => a.Name == containerService.Name);
#endif
                    m_CrpClient.ContainerServices.Delete(rgName, containerService.Name);
                    var listResultAfterDeletion = m_CrpClient.ContainerServices.ListByResourceGroup(rgName);
                    Assert.True(!listResultAfterDeletion.Any());
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
