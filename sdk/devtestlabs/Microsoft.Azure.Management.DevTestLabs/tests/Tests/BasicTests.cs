// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.DevTestLabs;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace DevTestLabs.Tests
{
    public class LabTests : DevTestLabsTestBase
    {
        // Indicates items number to create for paginated test cases
        private const int PaginatedItemsCount = 110;

        [Fact]
        public void ListLabsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetDevTestLabsClient(context);

                var labs = client.Labs.ListBySubscription().ToList();
                Assert.NotEmpty(labs);
            }
        }
    }
}

