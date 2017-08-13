// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Search : Samples.Tests.TestBase
    {
        public Search(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "Search")]
        public void ManageSearchTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSearch.Program.RunSample(rollUpClient);
            }
        }
    }
}
