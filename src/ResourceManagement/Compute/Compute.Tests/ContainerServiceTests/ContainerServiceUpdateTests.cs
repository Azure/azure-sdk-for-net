//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                m_location = "australiasoutheast"; // TODO: For now, APIs nly work in this region under BU endpoint
                
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
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
                        out inputContainerService, cs =>
                        {
                            cs.AgentPoolProfiles[0].Count = 1;
                            cs.MasterProfile.Count = 1;
                        });

                    // Update Container Service with increased AgentPoolProfiles Count
                    inputContainerService.AgentPoolProfiles[0].Count = 2;
                    UpdateContainerService(rgName, csName, inputContainerService);

                    containerService = m_CrpClient.ContainerService.Get(rgName, containerService.Name);
                    ValidateContainerService(inputContainerService, containerService);

                    var listResult = m_CrpClient.ContainerService.List(rgName);
                    Assert.True(listResult.Any(a => a.Name == containerService.Name));
                    m_CrpClient.ContainerService.Delete(rgName, containerService.Name);
                    var listResultAfterDeletion = m_CrpClient.ContainerService.List(rgName);
                    Assert.True(!listResultAfterDeletion.Any());
                }
                finally
                {
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
