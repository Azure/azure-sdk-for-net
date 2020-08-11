// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabric.Tests.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.ServiceFabric;
    using System.Linq;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using System.IO;
    using Microsoft.Azure.Management.ServiceFabric.Models;

    public class TestGetClusterResource : ServiceFabricTestBase
    {
        [Fact]
        public void TestGet()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var resouceClient = GetResourceManagementClient(context);
                var resourceGroups = resouceClient.ResourceGroups.List();
                foreach (var rg in resourceGroups)
                {
                    var resources = GetAllServiceFabricClusterResources(context, rg);
                    if (resources.Any())
                    {
                        var res = resources.First();
                        var cluster = serviceFabricClient.Clusters.Get(rg.Name, res.Name);
                        Assert.NotNull(cluster);
                    }

                    var randomResName = "donotexisting";
                    if (resources.Where(r => r.Name == randomResName).Count() == 0)
                    {
                        try
                        {
                            serviceFabricClient.Clusters.Get(rg.Name, randomResName);
                        }
                        catch (ErrorModelException exception)
                        {
                            Assert.True(exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
                        }                        
                    }

                    break;
                }
            }
        }
    }
}

