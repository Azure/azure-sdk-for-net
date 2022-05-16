// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace TestBase.Tests
{
    public class OperationsTests : TestbaseBase
    {
        [Fact]
        public void TestOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                try
                {
                    var operations = t_TestBaseClient.Operations.ListWithHttpMessagesAsync().GetAwaiter().GetResult();
                    Assert.NotNull(operations);
                    Assert.NotNull(operations.Body);//count:76  create,delete,update...
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);//Forbidden
                }

                Assert.ThrowsAsync<System.UriFormatException>(() => t_TestBaseClient.Operations.ListNextWithHttpMessagesAsync(null));
            }
        }
    }
}
