// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace InfrastructureInsights.Tests
{
    using Microsoft.AzureStack.Management.InfrastructureInsights.Admin;
    using Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models;
    using Xunit;

    public class SupportedOperationTests : InfrastructureInsightsTestBase
    {

        private void ValidateDisplay(Display display) {
            Assert.NotNull(display);

            Assert.NotNull(display.Description);
            Assert.NotNull(display.Operation);
            Assert.NotNull(display.Provider);
            Assert.NotNull(display.Resource);
        }

        private void ValidateOperation(Operation operation) {
            Assert.NotNull(operation);

            // Name
            Assert.NotNull(operation.Name);
            Assert.NotEqual("", operation.Name);

            // Display
            ValidateDisplay(operation.Display);
        }

        [Fact(Skip="Incorrect Manifest Permissions")]
        public void TestListSupportedOperations() {
            RunTest((client) => {
                var operations = client.Operations.List();
                Common.MapOverIPage(operations, client.Operations.ListNext, ValidateOperation);
            });
        }
    }
}
