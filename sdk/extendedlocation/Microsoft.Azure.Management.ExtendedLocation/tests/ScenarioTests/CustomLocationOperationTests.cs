// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ExtendedLocation.Tests.ScenarioTests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Management.ExtendedLocation.Models;
    
    public class CustomLocationOperationTests
    {
        [Fact]
        public void TestOperationsCustomLocation()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var customLocationTestBase = new CustomLocationsOperationsTestBase(context))
                {
                    // CREATE CL
                    Microsoft.Azure.Management.ExtendedLocation.Models.CustomLocation customLocation = customLocationTestBase.CreateCustomLocations();
                    Assert.True(customLocation.DisplayName == CustomLocationTestData.ResourceName);
                    Assert.True(customLocation.ProvisioningState == "Succeeded");

                    // GET ON CREATED CL
                    Console.WriteLine("\n");
                    customLocation = customLocationTestBase.GetCustomLocation();
                    Assert.True(customLocation.DisplayName == CustomLocationTestData.ResourceName);

                    // PATCH CL
                    Console.WriteLine("\n");
                    customLocation = customLocationTestBase.PatchCustomLocation();
                    Assert.True(customLocation.ProvisioningState == "Patching");

                    // GET ON UPDATED CL
                    Console.WriteLine("\n");
                    customLocation = customLocationTestBase.GetCustomLocation();
                    List<string> clusterextids = new List<string>(new string[] { CustomLocationTestData.CassandraTest , CustomLocationTestData.AnsibleTest });
                    Assert.True(customLocation.DisplayName == CustomLocationTestData.ResourceName);
                    if (customLocation.ClusterExtensionIds[0] == CustomLocationTestData.CassandraTest)
                    {
                        Assert.True(customLocation.ClusterExtensionIds[1] == CustomLocationTestData.AnsibleTest);
                    }
                    else
                    {
                        Assert.True(customLocation.ClusterExtensionIds[0] == CustomLocationTestData.AnsibleTest);
                    }

                    // LIST BY SUBSCRIPTION
                    Console.WriteLine("\n");
                    Microsoft.Azure.Management.ExtendedLocation.Models.Page<CustomLocation> page = (Microsoft.Azure.Management.ExtendedLocation.Models.Page<CustomLocation>)customLocationTestBase.ListCustomLocationsBySubscription();
                    bool foundCL;
                    foundCL = Paging.PageListResult(page, customLocationTestBase.ListCustomLocationsBySubscriptionNext);
                    Assert.True(foundCL);

                    // LIST BY RESOURCE GROUP
                    Console.WriteLine("\n");
                    page = (Microsoft.Azure.Management.ExtendedLocation.Models.Page<CustomLocation>)customLocationTestBase.ListCustomLocationsByResourceGroup();
                    foundCL = Paging.PageListResult(page, customLocationTestBase.ListCustomLocationsByResourceGroupNext);
                    Assert.True(foundCL);

                    // DELETE CREATED CL
                    Console.WriteLine("\n");
                    customLocationTestBase.DeleteCustomLocation();
                    Console.WriteLine("\n");

                    // LIST OPERATION SHOULD NOT FIND CL
                    page = (Microsoft.Azure.Management.ExtendedLocation.Models.Page<CustomLocation>)customLocationTestBase.ListCustomLocationsByResourceGroup();
                    foundCL = Paging.PageListResult(page, customLocationTestBase.ListCustomLocationsByResourceGroupNext);
                    Assert.False(foundCL);
                }
            }
        }
    }
}


