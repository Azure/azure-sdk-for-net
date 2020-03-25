// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;

    [Collection("OperationsScenarioTests")]
    public class OperationsScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void Operations_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                var operations = client.Operations.List();

                Assert.NotEmpty(operations);
            }

        }
    }
}
