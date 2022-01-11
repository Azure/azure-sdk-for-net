// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.CosmosDB;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace CosmosDB.Tests.ScenarioTests
{
    public class OperationsTests : IClassFixture<TestFixture>
    {
        private readonly TestFixture fixture;

        public OperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }
    
        [Fact]
        public void ListOperationsTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.fixture.Init(MockContext.Start(this.GetType()));
                var operations = this.fixture.CosmosDBManagementClient.Operations.List();
                Assert.NotNull(operations);
                Assert.NotEmpty(operations);
            }
        }
    }
}
