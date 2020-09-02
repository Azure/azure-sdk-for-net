// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Avs;
using Microsoft.Azure.Management.Avs.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using ResourceGroup = Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup;

namespace Avs.Tests
{
    public class AvsTests : TestBase
    {
        [Fact]
        public void AvsCrud()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName("avs-sdk-test-rg");
            string cloudName = TestUtilities.GenerateName("avs-sdk-test-cloud");
            string clusterName = TestUtilities.GenerateName("avs-sdk-test-cluster");
            string location = "centralus";

            CreateResourceGroup(context, location, rgName);

            try
            {
                using var testBase = new AvsTestBase(context);
                var client = testBase.AvsClient;

                var clouds = client.PrivateClouds.List(rgName);
                Assert.True(clouds.Count() == 0);

                // create a private cloud
                client.PrivateClouds.CreateOrUpdate(rgName, cloudName, new PrivateCloud
                {
                    Location = location,
                    Sku = new Sku { Name = "av20" },
                    Properties = new PrivateCloudProperties
                    {
                        Cluster = new DefaultClusterProperties
                        {
                            ClusterSize = 4,
                        },
                        NetworkBlock = "192.168.48.0/22"
                    }
                });

                var clusters = client.Clusters.List(rgName, cloudName);
                Assert.True(clusters.Count() == 0);

                // create a cluster
                var cluster = client.Clusters.CreateOrUpdate(rgName, cloudName, clusterName, new Cluster
                {
                    Properties = new ClusterProperties
                    {
                        ClusterSize = 3,
                    }
                });

                clusters = client.Clusters.List(rgName, cloudName);
                Assert.True(clusters.Count() == 1);

                // delete a cluster
                client.Clusters.Delete(rgName, cloudName, clusterName);

                clusters = client.Clusters.List(rgName, cloudName);
                Assert.True(clusters.Count() == 0);

                clouds = client.PrivateClouds.List(rgName);
                Assert.True(clouds.Count() == 1);

                // delete a private cloud
                client.PrivateClouds.Delete(rgName, cloudName);

                clouds = client.PrivateClouds.List(rgName);
                Assert.True(clouds.Count() == 0);

            }
            finally
            {
                DeleteResourceGroup(context, rgName);
            }
        }

        private ResourceGroup CreateResourceGroup(MockContext context, string location, string rgName)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            return client.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = location
                });
        }

        private void DeleteResourceGroup(MockContext context, string rgName)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            client.ResourceGroups.Delete(rgName);
        }
    }
}