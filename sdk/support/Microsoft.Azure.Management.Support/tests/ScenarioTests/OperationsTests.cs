using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Xunit;

namespace Microsoft.Azure.Management.Support.Tests.ScenarioTests
{
    public class OperationsTests
    {
        [Fact]
        public void OperationListTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var operations = client.Operations.List();
                    Assert.True(operations.Count() > 0);
                }
            }
        }
    }
}
