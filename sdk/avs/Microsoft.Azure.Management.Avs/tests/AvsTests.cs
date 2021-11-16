// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Avs;
using Microsoft.Azure.Management.Avs.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Avs.Tests
{
    public class AvsTests : TestBase
    {
        [Fact]
        public void AvsCrud()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName("rg");
            string cloudName = TestUtilities.GenerateName("cloud");
            string clusterName = TestUtilities.GenerateName("cluster");
            string location = "centralus";
            string hcxEnterpriseSiteName = TestUtilities.GenerateName("site");
            string authName = TestUtilities.GenerateName("authorization");

            using var avsClient = context.GetServiceClient<AvsClient>();

            var clouds = avsClient.PrivateClouds.List(rgName);
            Assert.Single(clouds);

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
            Assert.Single(hcxPage);

            var hcxSite = avsClient.HcxEnterpriseSites.CreateOrUpdate(rgName, privateCloud.Name, hcxEnterpriseSiteName);

            avsClient.HcxEnterpriseSites.Get(rgName, privateCloud.Name, hcxSite.Name);

            hcxPage = avsClient.HcxEnterpriseSites.List(rgName, privateCloud.Name);
            Assert.Single(hcxPage);

            avsClient.HcxEnterpriseSites.Get(rgName, privateCloud.Name, hcxSite.Name);

            avsClient.HcxEnterpriseSites.Delete(rgName, privateCloud.Name, hcxSite.Name);

            // ExpressRoute Authorizations

            var authPage = avsClient.Authorizations.List(rgName, privateCloud.Name);
            Assert.Single(authPage);

            var auth = avsClient.Authorizations.CreateOrUpdate(rgName, privateCloud.Name, authName);

            avsClient.Authorizations.Get(rgName, privateCloud.Name, auth.Name);

            avsClient.Authorizations.Delete(rgName, privateCloud.Name, auth.Name);

            // Clusters

            var clusters = avsClient.Clusters.List(rgName, cloudName);
            Assert.Single(clusters);

            // create a cluster
            var cluster = avsClient.Clusters.CreateOrUpdate(rgName, cloudName, clusterName, new Cluster
            {
                Sku = new Sku { Name = "av20" },
                ClusterSize = 3,
            });

            avsClient.Clusters.Get(rgName, cloudName, cluster.Name);

            clusters = avsClient.Clusters.List(rgName, cloudName);
            Assert.Single(clusters);

            // delete a cluster
            avsClient.Clusters.Delete(rgName, cloudName, cluster.Name);
            // Update a cluster
            avsClient.Clusters.Update(rgName, cloudName, cluster.Name,new ClusterUpdate());

            //delete a private cloud
            avsClient.PrivateClouds.Delete(rgName, cloudName);

            //Update a private cloud
            avsClient.PrivateClouds.Update(rgName, cloudName,new PrivateCloudUpdate());
        }

        [Fact]
        public void PasswordResets()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "aumarcel-eastus2-rg";
            string cloudName = "aumarcel-2021-05-06-hcx";

            using var avsClient = context.GetServiceClient<AvsClient>();

            avsClient.PrivateClouds.ListAdminCredentials(rgName, cloudName);
         
            avsClient.PrivateClouds.RotateNsxtPassword(rgName, cloudName);
            avsClient.PrivateClouds.RotateVcenterPassword(rgName, cloudName);

        }

        [Fact]
        public void PlacementPolicy()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName("rg");
            string cloudName = TestUtilities.GenerateName("cloud");
            string clusterName = TestUtilities.GenerateName("cluster");
            string placemenPolicyName = "placementpolicy-pc";
            //creating avsclient object
            using var avsClient = context.GetServiceClient<AvsClient>();


            avsClient.PlacementPolicies.CreateOrUpdate(rgName, cloudName, clusterName, placemenPolicyName, new PlacementPolicy());

           
            // Get placement policies
            avsClient.PlacementPolicies.Get(rgName, cloudName, clusterName, placemenPolicyName);
            // list placement policies 
            avsClient.PlacementPolicies.List(rgName, cloudName, clusterName);
            // update placement policies
            avsClient.PlacementPolicies.Update(rgName, cloudName, clusterName, placemenPolicyName,new PlacementPolicyUpdate());
            // Delete placement policices
            avsClient.PlacementPolicies.Delete(rgName, cloudName, clusterName, placemenPolicyName);


        }

        [Fact]
        public void VirtualMachine()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName("rg");
            string cloudName = TestUtilities.GenerateName("cloud");
            string clusterName = TestUtilities.GenerateName("cluster");
            string virtualId = "Vr-Id";

            using var avsClient = context.GetServiceClient<AvsClient>();
            // get virtual machine 
            avsClient.VirtualMachines.Get(rgName,cloudName,clusterName, virtualId);
            // list virtual machine
            avsClient.VirtualMachines.List(rgName, cloudName, clusterName);

           // avsClient.VirtualMachines.RestrictMovement(rgName, cloudName, clusterName, virtualId, new VirtualMachineRestrictMovement(VirtualMachineRestrictMovementState.Enabled));


        }
    }
}