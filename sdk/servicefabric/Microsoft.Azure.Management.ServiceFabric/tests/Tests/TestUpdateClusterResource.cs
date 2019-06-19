// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabric.Tests.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.ServiceFabric;
    using System.Linq;
    using Microsoft.Azure.Management.Resources;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ServiceFabric.Models;
    using System;

    public class TestUpdateClusterResource : ServiceFabricTestBase
    {
        [Fact]
        public void TestUpdate()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                        if (!cluster.ClusterState.Equals("ready", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        serviceFabricClient.Clusters.Update(rg.Name, res.Name,
                            new ClusterUpdateParameters()
                            {
                                FabricSettings = new List<SettingsSectionDescription>()
                                {
                                    new SettingsSectionDescription()
                                    {
                                        Name = "NamingService",
                                        Parameters = new List<SettingsParameterDescription>()
                                        {
                                            new SettingsParameterDescription()
                                            {
                                                Name = "MaxOperationTimeout",
                                                Value = "1000"
                                            }
                                        }
                                    }
                                }
                            });

                        cluster = serviceFabricClient.Clusters.Get(rg.Name, res.Name);
                        while (string.Compare(cluster.ClusterState, "ready",true) != 0)
                        {
                            cluster = serviceFabricClient.Clusters.Get(rg.Name, res.Name);
                            TestUtilities.Wait(TimeSpan.FromMinutes(1));
                        }

                        var ns = cluster.FabricSettings.Where(s => s.Name == "NamingService").First();
                        var p = ns.Parameters.Where(
                            parameter =>
                            parameter.Name == "MaxOperationTimeout").First();

                        Assert.True(p.Value == "1000");

                        break;
                    }
                }
            }
        }
    }
}
