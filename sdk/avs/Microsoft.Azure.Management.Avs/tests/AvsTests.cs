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
            string hcxEnterpriseSiteName = TestUtilities.GenerateName("avs-sdk-test-hcx-site");
            string authName = TestUtilities.GenerateName("avs-sdk-test-authorization");

            CreateResourceGroup(context, location, rgName);

            try
            {
                using var testBase = new AvsTestBase(context);
                var client = testBase.AvsClient;

                var quota = client.Locations.CheckQuotaAvailability(location);
                var trial = client.Locations.CheckTrialAvailability(location);

                var clouds = client.PrivateClouds.List(rgName);
                Assert.True(clouds.Count() == 0);

                // create a private cloud
                var privateCloud = client.PrivateClouds.CreateOrUpdate(rgName, cloudName, new PrivateCloud
                {
                    Location = location,
                    Sku = new Sku { Name = "av20" },
                    ManagementCluster = new ManagementCluster
                    {
                        ClusterSize = 4,
                    },
                    NetworkBlock = "192.168.48.0/22"
                });

                // HCX Enterprise Sites

                var hcxPage = client.HcxEnterpriseSites.List(rgName, privateCloud.Name);
                Assert.True(hcxPage.Count() == 0);

                var hcxSite = client.HcxEnterpriseSites.CreateOrUpdate(rgName, privateCloud.Name, hcxEnterpriseSiteName, new object());

                client.HcxEnterpriseSites.Get(rgName, privateCloud.Name, hcxSite.Name);

                hcxPage = client.HcxEnterpriseSites.List(rgName, privateCloud.Name);
                Assert.True(hcxPage.Count() == 1);

                client.HcxEnterpriseSites.Get(rgName, privateCloud.Name, hcxSite.Name);

                client.HcxEnterpriseSites.Delete(rgName, privateCloud.Name, hcxSite.Name);

                // ExpressRoute Authorizations

                var authPage = client.Authorizations.List(rgName, privateCloud.Name);
                Assert.True(authPage.Count() == 0);

                var auth = client.Authorizations.CreateOrUpdate(rgName, privateCloud.Name, authName, new object());

                client.Authorizations.Get(rgName, privateCloud.Name, auth.Name);

                authPage = client.Authorizations.List(rgName, privateCloud.Name);
                Assert.True(authPage.Count() == 1);

                client.Authorizations.Delete(rgName, privateCloud.Name, auth.Name);

                // Clusters

                var clusters = client.Clusters.List(rgName, cloudName);
                Assert.True(clusters.Count() == 0);

                // create a cluster
                var cluster = client.Clusters.CreateOrUpdate(rgName, cloudName, clusterName, new Cluster
                {
                    Sku = new Sku { Name = "av20" },
                    ClusterSize = 3,
                });

                client.Clusters.Get(rgName, cloudName, cluster.Name);

                clusters = client.Clusters.List(rgName, cloudName);
                Assert.True(clusters.Count() == 1);

                // delete a cluster
                client.Clusters.Delete(rgName, cloudName, cluster.Name);

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