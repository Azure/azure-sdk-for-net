// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagedNetworkTests.cs" company="Microsoft">
//   
// </copyright>
// <summary>
//   Runs tests on Managed Network operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ManagedNetwork.Tests
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.ManagedNetwork;
    using Microsoft.Azure.Management.ManagedNetwork.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Newtonsoft.Json;
    using System.Diagnostics;

    public class Tests
    {
        public ManagedNetworkManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }

        [Fact]
        public void Mesh()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                #region Initialization
                this.client = context.GetServiceClient<ManagedNetworkManagementClient>();
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                string resourceGroupName = "MNC-Portal";
                string location = "Central US";

                ResourceGroup rsg;
                try
                {
                    rsg = this.resourcesClient.ResourceGroups.Get(resourceGroupName);
                }
                catch
                {
                    rsg = this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });
                }
                Assert.Equal(rsg.Name, resourceGroupName);
                #endregion

                #region Create managedNetwork
                string managedNetworkName = "SDK_ManagedNetwork_Mesh2";
                Scope mNScope = new Scope()
                {
                    VirtualNetworks = new List<ResourceId>()
                    {
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh1"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh2"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh3"
                            }
                    }
                };

                ManagedNetworkModel managedNetwork = new ManagedNetworkModel()
                {
                    Location = location,
                    Scope = mNScope
                };

                ManagedNetworkModel putManagedNetworkResponse = this.client.ManagedNetworks.CreateOrUpdate(managedNetwork, resourceGroupName, managedNetworkName);
                #endregion
                string managedNetworkGroupName = "SDK_MeshGroup";

                ManagedNetworkGroup managedNetworkGroup = new ManagedNetworkGroup()
                {
                    Location = location,
                    VirtualNetworks = new List<ResourceId>()
                    {
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh1"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh2"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh3"
                            }
                    }
                };


                // Put Connectivity Group
                ManagedNetworkGroup putManagedNetworkGroupResponse = this.client.ManagedNetworkGroups.CreateOrUpdate(managedNetworkGroup, resourceGroupName, managedNetworkName, managedNetworkGroupName);

                #region Create peeringPolicy
                string peeringPolicyName = "SDK_MeshPolicy";

                string managedNetworkPeeringPolicyType = "MeshTopology";
                var mesh = new List<ResourceId>
                           {
                                new ResourceId()
                                {
                                    Id = putManagedNetworkGroupResponse.Id
                                },
                            };

           
                ManagedNetworkPeeringPolicyProperties managedNetworkPeeringPolicyProperties = new ManagedNetworkPeeringPolicyProperties
                {
                    Type = managedNetworkPeeringPolicyType,
                    Mesh = mesh
                };

                ManagedNetworkPeeringPolicy peeringPolicy = new ManagedNetworkPeeringPolicy
                {
                    Location = location,
                    Properties = managedNetworkPeeringPolicyProperties
                };
                #endregion
                // Put PeeringPolicy
                ManagedNetworkPeeringPolicy putPeeringPolicyResult = this.client.ManagedNetworkPeeringPolicies.CreateOrUpdate(peeringPolicy, resourceGroupName, managedNetworkName, peeringPolicyName);   
            }

        }

        [Fact]
        public void HubSpoke()
        {
            var mode = System.Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            var connectionstring = System.Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                #region Initialization
                this.client = context.GetServiceClient<ManagedNetworkManagementClient>();
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                string resourceGroupName = "MNC-Portal";
                string location = "Central US";

                ResourceGroup rsg;
                try
                {
                    rsg = this.resourcesClient.ResourceGroups.Get(resourceGroupName);
                }
                catch
                {
                    rsg = this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });
                }
                Assert.Equal(rsg.Name, resourceGroupName);
                #endregion

                #region Create managedNetwork
                string managedNetworkName = "Portal_ManagedNetwork18";

                Scope scope = new Scope()
                {
                    VirtualNetworks = new List<ResourceId>()
                    {
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke11"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke12"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke13"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Hub"
                            }
                    }
                };

                IDictionary<string, string> tags = new Dictionary<string, string>();
                tags["SampleKey"] = "SampleValue";
                ManagedNetworkModel managedNetwork = new ManagedNetworkModel()
                {
                    Location = location,
                    Scope = scope,
                    Tags = tags
                };

                ManagedNetworkModel putManagedNetworkResponse = this.client.ManagedNetworks.CreateOrUpdate(managedNetwork, resourceGroupName, managedNetworkName);
                #endregion

                

                string managedNetworkGroupName = "Portal_SpokeGroup1";
                ManagedNetworkGroup managedNetworkGroup = new ManagedNetworkGroup()
                {
                    Location = location,
                    VirtualNetworks = new List<ResourceId>()
                    {
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke11"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke12"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke13"
                            }
                    }
                };
                // Put Connectivity Group
                ManagedNetworkGroup putManagedNetworkGroupResponse = this.client.ManagedNetworkGroups.CreateOrUpdate(managedNetworkGroup, resourceGroupName, managedNetworkName, managedNetworkGroupName);



                #region Create peeringPolicy
                string peeringPolicyName = "SDK_MeshPolicy3";
                ResourceId hub = new ResourceId()
                {
                    Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Hub"
                };

                var spokes = new List<ResourceId>
                {
                    new ResourceId()
                    {
                        Id = putManagedNetworkGroupResponse.Id
                    },
                };

                ManagedNetworkPeeringPolicyProperties managedNetworkPeeringPolicyProperties = new ManagedNetworkPeeringPolicyProperties
                {
                    Type = "HubAndSpokeTopology",
                    Hub = hub,
                    Spokes = spokes
                }; 

                ManagedNetworkPeeringPolicy peeringPolicy = new ManagedNetworkPeeringPolicy
                {
                    Location = location,
                    Properties = managedNetworkPeeringPolicyProperties
                };
                #endregion
                
                // Put PeeringPolicy
                ManagedNetworkPeeringPolicy putPeeringPolicyResult = this.client.ManagedNetworkPeeringPolicies.CreateOrUpdate(peeringPolicy, resourceGroupName, managedNetworkName, peeringPolicyName);

            }

        }

        [Fact]
        public void Clear()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                #region Initialization
                this.client = context.GetServiceClient<ManagedNetworkManagementClient>();
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                string resourceGroupName = "MNC-Portal";
                string location = "Central US";

                ResourceGroup rsg;
                try
                {
                    rsg = this.resourcesClient.ResourceGroups.Get(resourceGroupName);
                }
                catch
                {
                    rsg = this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    { 
                        Location = location
                    });
                }
                Assert.Equal(rsg.Name, resourceGroupName);
                #endregion
                #region Create managedNetwork
                string managedNetworkName = "myManagedNetwork";

                Scope scope = new Scope()
                {
                    VirtualNetworks = new List<ResourceId>()
                    {
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh1"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh2"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh3"
                            },
                         new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh4"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh5"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke1"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke2"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke3"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke4"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke5"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke6"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke7"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke8"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke9"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke10"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke11"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke12"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke13"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke14"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke15"
                            },
                        new ResourceId()
                            {
                                Id = "subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Hub"
                            },
                    }
                };

                ManagedNetworkModel managedNetwork = new ManagedNetworkModel()
                {
                    Location = location,
                    Scope = scope
                };

                ManagedNetworkModel putManagedNetworkResponse = this.client.ManagedNetworks.CreateOrUpdate(managedNetwork, resourceGroupName, managedNetworkName);
                #endregion

                this.client.ManagedNetworks.Delete(resourceGroupName, managedNetworkName);
            }

        }
    }
}