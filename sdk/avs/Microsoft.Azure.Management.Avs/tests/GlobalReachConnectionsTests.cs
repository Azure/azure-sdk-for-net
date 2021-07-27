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
    public class GlobalReachConnectionsTests : TestBase
    {

        [Fact]
        public void GlobalReachConnectionsAll()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "js-dev-testing";
            string cloudName = "cloudLinker";

            using var avsClient = context.GetServiceClient<AvsClient>();
            

            var globalReachName = "myConn";
            var globalReachConn = avsClient.GlobalReachConnections.CreateOrUpdate(rgName, cloudName, globalReachName,
                new GlobalReachConnection
                {
                    PeerExpressRouteCircuit =
                        "/subscriptions/12341234-1234-1234-1234-123412341234/resourceGroups/mygroup/providers/Microsoft.Network/expressRouteCircuits/mypeer",
                    AuthorizationKey = "01010101-0101-0101-0101-010101010101"
                });

            avsClient.GlobalReachConnections.List(rgName, cloudName);
            avsClient.GlobalReachConnections.Get(rgName, cloudName, globalReachName);
            avsClient.GlobalReachConnections.Delete(rgName, cloudName, globalReachName);
        }
    }
}