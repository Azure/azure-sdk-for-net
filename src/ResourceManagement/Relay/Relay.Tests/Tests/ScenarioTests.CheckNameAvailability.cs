//  
//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Relay.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Relay;
    using Microsoft.Azure.Management.Relay.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Relay.Tests.TestHelper;
    using Xunit;
    public partial class ScenarioTests 
    {
        [Fact]
        public void CheckNameAvailability()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);
                var location = this.ResourceManagementClient.GetLocationFromProvider();
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(RelayManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create Namespace
                var namespaceName = TestUtilities.GenerateName(RelayManagementHelper.NamespacePrefix);

                // CheckNameAvailability 
                var checkNameAvailabilityResponse = this.RelayManagementClient.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability { Name = namespaceName });

                Assert.True(checkNameAvailabilityResponse.NameAvailable);

                var createNamespaceResponse = this.RelayManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new RelayNamespace()
                    {
                        Location = location,
                        //Sku = new Sku
                        //{
                        //    Name = "Standard"
                        //},

                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }

                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);
                Assert.Equal(createNamespaceResponse.Tags.Count, 2);
                Assert.Equal(createNamespaceResponse.Type, "Microsoft.Relay/namespaces");
                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                
                // CheckNameAvailability 
                var checkNameAvailabilityResponse1 = this.RelayManagementClient.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability { Name = namespaceName });
                Assert.False(checkNameAvailabilityResponse1.NameAvailable);
                Assert.True(checkNameAvailabilityResponse1.Reason == UnavailableReason.NameInUse);

                checkNameAvailabilityResponse1 = this.RelayManagementClient.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability { Name = "12@" });
                Assert.False(checkNameAvailabilityResponse1.NameAvailable);
                Assert.True(checkNameAvailabilityResponse1.Reason == UnavailableReason.InvalidName);                                

                try
                {
                    // Delete namespace
                    RelayManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
            }
        }
    }
}
