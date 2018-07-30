// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class OperationsTests : MediaScenarioTestBase
    {
        [Fact]
        public void OperationListTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                // Do a basic verification that the operations are returned
                var operations = MediaClient.Operations.List();
                Assert.NotEmpty(operations);
            }
        }
    }
}
