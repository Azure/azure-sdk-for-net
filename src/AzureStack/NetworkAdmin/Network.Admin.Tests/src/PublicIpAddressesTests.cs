// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Network.Admin;
using Microsoft.AzureStack.Management.Network.Admin.Models;
using Xunit;

namespace Network.Tests
{
    public class PublicIPAddressesTests : NetworkTestBase
    {

        [Fact]
        public void TestGetAllPublicIpAddresses()
        {
            RunTest((client) =>
            {
                var addresses = client.PublicIPAddresses.List();

                // This test should be using the SessionRecord which has an existing PublicIPAddress created
                if (addresses != null)
                {
                    addresses.ForEach((address) =>
                    {
                        NetworkCommon.ValidateBaseResources(address);

                        NetworkCommon.ValidateBaseResourceTenant(address);

                        Assert.NotNull(address.IpAddress);
                        Assert.NotNull(address.IpPool);
                    });
                }
            });
        }
        [Fact]
        public void TestGetAllPublicIpAddressesOData()
        {
            RunTest((client) =>
            {
                Microsoft.Rest.Azure.OData.ODataQuery<PublicIpAddress> odataQuery = new Microsoft.Rest.Azure.OData.ODataQuery<PublicIpAddress>();
                odataQuery.Top = 10;

                var addresses = client.PublicIPAddresses.List(odataQuery);

                // This test should be using the SessionRecord which has an existing PublicIPAddress created
                if (addresses != null)
                {
                    addresses.ForEach((address) =>
                    {
                        NetworkCommon.ValidateBaseResources(address);

                        NetworkCommon.ValidateBaseResourceTenant(address);

                        Assert.NotNull(address.IpAddress);
                        Assert.NotNull(address.IpPool);
                    });
                }
            });
        }
    }
}
