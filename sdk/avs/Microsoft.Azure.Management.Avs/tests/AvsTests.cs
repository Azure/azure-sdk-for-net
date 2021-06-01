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
        const string PREFIX = "avs-sdk-test-";

        [Fact]
        public void AvsCrud()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName(PREFIX + "rg");
            string cloudName = TestUtilities.GenerateName(PREFIX + "cloud");
            string clusterName = TestUtilities.GenerateName(PREFIX + "cluster");
            string location = "centralus";
            string hcxEnterpriseSiteName = TestUtilities.GenerateName(PREFIX + "site");
            string authName = TestUtilities.GenerateName(PREFIX + "authorization");

            using var rmClient = context.GetServiceClient<ResourceManagementClient>();
            rmClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });

            try
            {
                using var avsClient = context.GetServiceClient<AvsClient>();
                var quota = avsClient.Locations.CheckQuotaAvailability(location);
                var trial = avsClient.Locations.CheckTrialAvailability(location);

                var clouds = avsClient.PrivateClouds.List(rgName);
                Assert.True(clouds.Count() == 0);

                // create a private cloud
                var privateCloud = avsClient.PrivateClouds.CreateOrUpdate(rgName, cloudName, new PrivateCloud
                {
                    Location = location,
                    Sku = new Sku { Name = "av20" },
                    ManagementCluster = new ManagementCluster
                    {
                        ClusterSize = 3,
                    },
                    NetworkBlock = "192.168.48.0/22"
                });

                // HCX Enterprise Sites

                var hcxPage = avsClient.HcxEnterpriseSites.List(rgName, privateCloud.Name);
                Assert.True(hcxPage.Count() == 0);

                var hcxSite = avsClient.HcxEnterpriseSites.CreateOrUpdate(rgName, privateCloud.Name, hcxEnterpriseSiteName);

                avsClient.HcxEnterpriseSites.Get(rgName, privateCloud.Name, hcxSite.Name);

                hcxPage = avsClient.HcxEnterpriseSites.List(rgName, privateCloud.Name);
                Assert.True(hcxPage.Count() == 1);

                avsClient.HcxEnterpriseSites.Get(rgName, privateCloud.Name, hcxSite.Name);

                avsClient.HcxEnterpriseSites.Delete(rgName, privateCloud.Name, hcxSite.Name);

                // ExpressRoute Authorizations

                var authPage = avsClient.Authorizations.List(rgName, privateCloud.Name);
                Assert.True(authPage.Count() == 0);

                var auth = avsClient.Authorizations.CreateOrUpdate(rgName, privateCloud.Name, authName);

                avsClient.Authorizations.Get(rgName, privateCloud.Name, auth.Name);

                authPage = avsClient.Authorizations.List(rgName, privateCloud.Name);
                Assert.True(authPage.Count() == 1);

                avsClient.Authorizations.Delete(rgName, privateCloud.Name, auth.Name);

                // Clusters

                var clusters = avsClient.Clusters.List(rgName, cloudName);
                Assert.True(clusters.Count() == 0);

                // create a cluster
                var cluster = avsClient.Clusters.CreateOrUpdate(rgName, cloudName, clusterName, new Cluster
                {
                    Sku = new Sku { Name = "av20" },
                    ClusterSize = 3,
                });

                avsClient.Clusters.Get(rgName, cloudName, cluster.Name);

                clusters = avsClient.Clusters.List(rgName, cloudName);
                Assert.True(clusters.Count() == 1);

                // delete a cluster
                avsClient.Clusters.Delete(rgName, cloudName, cluster.Name);

                clusters = avsClient.Clusters.List(rgName, cloudName);
                Assert.True(clusters.Count() == 0);

                clouds = avsClient.PrivateClouds.List(rgName);
                Assert.True(clouds.Count() == 1);

                // disabled in test environment because of bug 9868299
                // delete a private cloud
                // avsClient.PrivateClouds.Delete(rgName, cloudName);

                // clouds = avsClient.PrivateClouds.List(rgName);
                // Assert.True(clouds.Count() == 0);

            }
            finally
            {
                rmClient.ResourceGroups.Delete(rgName);
            }
        }

        [Fact]
        public void PasswordResets()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "aumarcel-eastus2-rg";
            string cloudName = "aumarcel-2021-05-06-hcx";
            
            using var avsClient = context.GetServiceClient<AvsClient>();
            avsClient.HttpClient.Timeout = System.Threading.Timeout.InfiniteTimeSpan;

            var credsA = avsClient.PrivateClouds.ListAdminCredentials(rgName, cloudName);

            var credsB = avsClient.PrivateClouds.ListAdminCredentials(rgName, cloudName);
            Assert.Equal(credsA.NsxtPassword, credsB.NsxtPassword);
            Assert.Equal(credsA.VcenterPassword, credsB.VcenterPassword);

            avsClient.PrivateClouds.RotateNsxtPassword(rgName, cloudName);
            avsClient.PrivateClouds.RotateVcenterPassword(rgName, cloudName);

            var credsC = avsClient.PrivateClouds.ListAdminCredentials(rgName, cloudName);
            Assert.NotEqual(credsA.NsxtPassword, credsC.NsxtPassword);
            Assert.NotEqual(credsA.VcenterPassword, credsC.VcenterPassword);
        }
    }
}