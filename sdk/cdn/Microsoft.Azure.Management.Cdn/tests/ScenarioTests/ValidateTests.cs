// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Cdn.Tests.ScenarioTests
{
    public class ValidateTests
    {
        [Fact]
        public void ValidateProbePathTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);

                //1. Validate probe with invalid URL should fail.
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.ValidateProbe("www.withoutHttp.com");
                });

                //2. Validate probe with valid but non-existing URL should return false.
                var output = cdnMgmtClient.ValidateProbe("https://www.notexist.com/notexist/notexist.txt");
                Assert.NotNull(output.IsValid);
                Assert.False(output.IsValid);

                //3. Validate probe with a valid and existing URL should return true.
                output = cdnMgmtClient.ValidateProbe("https://azurecdn-files.azureedge.net/dsa-test/probe-v.txt");
                Assert.NotNull(output.IsValid);
                Assert.True(output.IsValid);

                //4. Validate probe with invalid ip address as host should fail.
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.ValidateProbe("http://999.999.999.999/nonexist.txt");
                });

                //5. Validate probe with valid but non-exist url, when host is an ip address, should return false.
                output = cdnMgmtClient.ValidateProbe("http://192.168.1.1/nonexist.aspx");
                Assert.NotNull(output.IsValid);
                Assert.False(output.IsValid);

                //6. Validate probe with valid and exist url, when host is an ip address, should return true.
                //TODO: The IP address is from a client. Replace it with a valid IP that we own.
                output = cdnMgmtClient.ValidateProbe("http://137.117.34.31/contact/contact.aspx");
                Assert.NotNull(output.IsValid);
                Assert.True(output.IsValid);


            }
        }
    }
}
