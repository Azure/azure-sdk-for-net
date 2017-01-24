// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Batch
    {
        public Batch(ITestOutputHelper output)
        {
            Microsoft.Azure.Management.Samples.Common.Utilities.LoggerMethod = output.WriteLine;
        }

        [Fact(Skip = "TODO: Assets location needs to be properly set")]
        [Trait("Samples", "Batch")]
        public void ManageBatchAccountTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageBatchAccount.Program.RunSample(rollUpClient);
            }
        }
    }
}
