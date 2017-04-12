// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Dns : Samples.Tests.TestBase
    {
        public Dns(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Investigate -- may require us to own a domain: Record test with pre-configured DNS")]
        [Trait("Samples", "Dns")]
        public void ManageDnsTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageDns.Program.RunSample(rollUpClient);
            }
        }
    }
}
