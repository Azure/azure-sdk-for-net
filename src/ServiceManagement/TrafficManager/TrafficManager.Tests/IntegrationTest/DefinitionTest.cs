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

using System.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.WindowsAzure.Management.TrafficManager.Testing
{
    public class DefinitionTest
    {
        private const string ExternalDomain = "www.office.com";

        [Fact]
        public void CreateDefinitionCloudService()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                System.Diagnostics.Trace.WriteLine("Cloud service test");

                //Arrange
                using (TrafficManagerTestBase _testFixture = new TrafficManagerTestBase())
                {
                    string serviceDomain = _testFixture.CreateTestCloudService();
                    LoadBalancingMethod testMethod = LoadBalancingMethod.Failover;
                    DefinitionEndpointCreateParameters endpointParam = new DefinitionEndpointCreateParameters();
                    endpointParam.DomainName = serviceDomain;
                    endpointParam.Status = EndpointStatus.Enabled;
                    endpointParam.Type = EndpointType.CloudService;
                    endpointParam.Weight = 2;

                    //Arrange + Act + Assert
                    testCreateDefinition(testMethod, endpointParam);
                }
            }
        }

        [Fact(Skip = "Test disabled due to an issue creating web sites. TODO: Fix the issue and enable the test.")]
        public void CreateDefinitionWebsite()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                //Arrange
                using (TrafficManagerTestBase _testFixture = new TrafficManagerTestBase())
                {
                    string websiteDomain = _testFixture.CreateTestWebsite();
                    LoadBalancingMethod testMethod = LoadBalancingMethod.Performance;
                    DefinitionEndpointCreateParameters endpointParam = new DefinitionEndpointCreateParameters();
                    endpointParam.DomainName = websiteDomain;
                    endpointParam.Status = EndpointStatus.Enabled;
                    endpointParam.Type = EndpointType.AzureWebsite;
                    endpointParam.Weight = 3;

                    //Arrange + Act + Assert
                    testCreateDefinition(testMethod, endpointParam);
                }
            }
        }

        [Fact]
        public void CreateDefinitionAny()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                //Arrange
                LoadBalancingMethod testMethod = LoadBalancingMethod.Failover;
                DefinitionEndpointCreateParameters endpointParam = new DefinitionEndpointCreateParameters();
                endpointParam.DomainName = ExternalDomain;
                endpointParam.Status = EndpointStatus.Enabled;
                endpointParam.Type = EndpointType.Any;
                endpointParam.Weight = 1;

                //Arrange + Act + Assert
                testCreateDefinition(testMethod, endpointParam);
            }
        }

        [Fact]
        public void CreateDefinitionAnyWithLocation()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                LoadBalancingMethod testMethod = LoadBalancingMethod.Performance;
                DefinitionEndpointCreateParameters endpointParam = new DefinitionEndpointCreateParameters();
                endpointParam.DomainName = ExternalDomain;
                endpointParam.Status = EndpointStatus.Enabled;
                endpointParam.Type = EndpointType.Any;
                endpointParam.Weight = 1;
                endpointParam.Location = "West US";

                testCreateDefinition(testMethod, endpointParam);
            }
        }

        [Fact]
        public void CreateDefinitionNoWeight()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                LoadBalancingMethod testMethod = LoadBalancingMethod.Failover;
                DefinitionEndpointCreateParameters endpointParam = new DefinitionEndpointCreateParameters();
                endpointParam.DomainName = ExternalDomain;
                endpointParam.Status = EndpointStatus.Enabled;
                endpointParam.Type = EndpointType.Any;

                testCreateDefinition(testMethod, endpointParam);
            }
        }

        [Fact]
        public void CreateDefinitionPerformanceAnyNoLocationFails()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                LoadBalancingMethod testMethod = LoadBalancingMethod.Performance;
                DefinitionEndpointCreateParameters endpointParam = new DefinitionEndpointCreateParameters();
                endpointParam.DomainName = ExternalDomain;
                endpointParam.Status = EndpointStatus.Enabled;
                endpointParam.Type = EndpointType.Any;
                endpointParam.Location = "West US";

                try
                {
                    testCreateDefinition(testMethod, endpointParam);
                }
                catch (CloudException ce)
                {
                    if (ce.Error.Message !=
                        "The location must be specified for endpoints of type 'Any' in a policy of type 'Performance'.")
                    {
                        throw;
                    }
                }
            }
        }

        [Fact(Skip = "TODO: Fix the test.")]
        public void CreateDefinitionWithTrafficManagerEndpoint()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                LoadBalancingMethod testMethod = LoadBalancingMethod.Failover;

                // Create the nested profile
                DefinitionEndpointCreateParameters nestedEndpointParam = new DefinitionEndpointCreateParameters();
                nestedEndpointParam.DomainName = ExternalDomain;
                nestedEndpointParam.Status = EndpointStatus.Enabled;
                nestedEndpointParam.Type = EndpointType.Any;
                nestedEndpointParam.Location = "West US";
                string nestedProfileDomainName = testCreateDefinition(testMethod, nestedEndpointParam);

                // Create the top level profile
                DefinitionEndpointCreateParameters topLevelEndpointParam = new DefinitionEndpointCreateParameters();
                topLevelEndpointParam.DomainName = nestedProfileDomainName;
                topLevelEndpointParam.Status = EndpointStatus.Enabled;
                topLevelEndpointParam.Type = EndpointType.TrafficManager;
                topLevelEndpointParam.MinChildEndpoints = 2;
                topLevelEndpointParam.Location = "West US";
                testCreateDefinition(testMethod, topLevelEndpointParam);
            }
        }

        private string testCreateDefinition(LoadBalancingMethod testMethod, DefinitionEndpointCreateParameters endpoint)
        {
            //Arrange
            using (TrafficManagerTestBase _testFixture = new TrafficManagerTestBase())
            {
                string profileName = _testFixture.CreateTestProfile();

                _testFixture.CreateADefinitionAndEnableTheProfile(
                    profileName,
                    testMethod,
                    endpoint);

                //Act, try 'List'
                DefinitionsListResponse listResponse = _testFixture.TrafficManagerClient.Definitions.List(profileName);

                //Assert
                Assert.Equal(1, listResponse.Count());
                Assert.Equal(testMethod, listResponse.First().Policy.LoadBalancingMethod);

                //Act, try 'Get'
                DefinitionGetResponse getResponse = _testFixture.TrafficManagerClient.Definitions.Get(profileName);

                //Assert
                Assert.Equal(testMethod, getResponse.Definition.Policy.LoadBalancingMethod);
                Assert.Equal(1, getResponse.Definition.Policy.Endpoints.Count);
                Assert.Equal(endpoint.Type, getResponse.Definition.Policy.Endpoints[0].Type);
                Assert.Equal(endpoint.Weight ?? 1, getResponse.Definition.Policy.Endpoints[0].Weight);
                Assert.Equal(endpoint.Location, getResponse.Definition.Policy.Endpoints[0].Location);
                Assert.Equal(endpoint.MinChildEndpoints, getResponse.Definition.Policy.Endpoints[0].MinChildEndpoints);

                //verify the profile itself has an associated definition enabled.
                //(due to the service limitation of one defintion per one profile, the enabled version is 1 always 
                ProfileGetResponse profileGetResponse = _testFixture.TrafficManagerClient.Profiles.Get(profileName);
                Assert.Equal(1, profileGetResponse.Profile.StatusDetails.EnabledDefinitionVersion);

                return profileGetResponse.Profile.DomainName;
            }
        }
    }
}
