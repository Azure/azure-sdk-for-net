// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Test.Azure.Management.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using System;

    /// <summary>
    /// Scenario tests for the provider operations.
    /// </summary>
    [Collection("ProviderOperationsTests")]
    public class ProviderOperationsTests : BaseScenarioTests
    {
        /// <summary>
        /// Name of the test class.
        /// </summary>
        private const string TestClass = "Test.Azure.Management.Logic.ProviderOperationsTests";

        /// <summary>
        /// Tests the get operation of provider.
        /// </summary>
        [Fact]
        public void GetProviderOperations()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                var client = context.GetServiceClient<LogicManagementClient>();
                var operationList = client.ListOperations();
                Assert.True(operationList.Count() > 0);
            }
        }
    }
}