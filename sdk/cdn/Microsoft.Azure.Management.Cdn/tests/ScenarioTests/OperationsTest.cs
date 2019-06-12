// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Cdn.Tests.ScenarioTests
{
    public class OperationsTests
    {
        [Fact]
        public void ListOperationsTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create client
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);

                // Get operations
                var operations = cdnMgmtClient.Operations.List();

                // Verify operations are returned
                Assert.NotNull(operations);
                Assert.NotEmpty(operations);
            }
        }
    }
}
