// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using System;

    [Collection("OperationsScenarioTests")]
    public class OperationsScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;

        public OperationsScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);
        }

        public void Dispose()
        {
            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void Operations_List_OK()
        {
            var operations = this.client.Operations.List();

            Assert.NotEmpty(operations);
        }
    }
}