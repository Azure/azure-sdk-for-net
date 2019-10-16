// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.LabServices;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace LabServices.Tests
{
    public class LabTests : LabServicesTestBase
    {
        [Fact]
        public void ListLabsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ManagedLabsClient client = GetManagedLabsClient(context);

                var labs = client.LabAccounts.ListBySubscription().ToList();
                Assert.NotEmpty(labs);
            }
        }
    }
}

