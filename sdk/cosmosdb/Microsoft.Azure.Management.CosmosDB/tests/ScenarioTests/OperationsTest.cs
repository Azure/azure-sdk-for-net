// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.CosmosDB;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace CosmosDB.Tests.ScenarioTests
{
    [Collection("TestCollection")]
    public class OperationsTests
    {
        public readonly TestFixture fixture;

        public OperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
            fixture.Init(MockContext.Start(this.GetType()));
        }
    
        [Fact]
        public void ListOperationsTest()
        {
            var operations = this.fixture.CosmosDBManagementClient.Operations.List();
            Assert.NotNull(operations);
            Assert.NotEmpty(operations);
        }
    }
}
