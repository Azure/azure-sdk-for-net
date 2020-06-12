// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Avs;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
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
            string rgName = TestUtilities.GenerateName("avs-sdk-test-rg");
            string cloudName = TestUtilities.GenerateName("appplatform-sdk-test-cloud");
            string location = "centralus";

            CreateResourceGroup(context, location, rgName);
            using var testBase = new AvsTestBase(context);
            var client = testBase.AvsClient;
            var clouds = client.PrivateClouds.List(rgName);
            Assert.True(clouds.Count() == 0);
        }

        private ResourceGroup CreateResourceGroup(MockContext context, string location, string rgName)
        {
            ResourceManagementClient client = context.GetServiceClient<ResourceManagementClient>();
            return client.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = location
                });
        }
    }
}