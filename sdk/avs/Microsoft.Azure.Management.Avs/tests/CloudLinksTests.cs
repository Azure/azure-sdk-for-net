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
    public class CloudLinksTests : TestBase
    {

        [Fact]
        public void CloudLinksAll()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "js-dev-testing";
            string cloudName = "cloudLinker";

            using var avsClient = context.GetServiceClient<AvsClient>();
            

            var globalReachName = "myLink";
            var globalReachConn = avsClient.CloudLinks.CreateOrUpdate(rgName, cloudName, globalReachName,
                new CloudLink()
                {
                    LinkedCloud = 
                        "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/mock-avs-fct-dogfood-conveyor-centralus/providers/Microsoft.AVS/privateClouds/fct-mock-centralus-45",
                });

            avsClient.CloudLinks.List(rgName, cloudName);
            avsClient.CloudLinks.Get(rgName, cloudName, globalReachName);
            avsClient.CloudLinks.Delete(rgName, cloudName, globalReachName);
        }
    }
}