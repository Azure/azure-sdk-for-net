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
    public class AddonsTests : TestBase
    {
        const string PREFIX = "avs-sdk-addons-";

        [Fact]
        public void HcxAll()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName(PREFIX + "rg");
            string cloudName = TestUtilities.GenerateName(PREFIX + "cloud");
            string location = "westcentralus";
            string addonName = "hcx";

            using var rmClient = context.GetServiceClient<ResourceManagementClient>();
            rmClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });

            try
            {
                using var avsClient = context.GetServiceClient<AvsClient>();

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

                var hcxPage = avsClient.Addons.List(rgName, cloudName);
                Assert.True(hcxPage.Count() == 0);

                avsClient.Addons.CreateOrUpdate(rgName, cloudName, addonName, new Addon
                {
                    Properties = new AddonHcxProperties
                    {
                        Offer = "VMware MaaS Cloud Provider (Enterprise)"
                    }
                });

                hcxPage = avsClient.Addons.List(rgName, cloudName);
                Assert.True(hcxPage.Count() == 1);

                avsClient.Addons.Get(rgName, cloudName, addonName);

                avsClient.Addons.Delete(rgName, cloudName, addonName);
            }
            finally
            {
                rmClient.ResourceGroups.Delete(rgName);
            }

        }
    }
}