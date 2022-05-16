// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.TestBase.Models;
using Xunit;

namespace TestBase.Tests
{
    public class SkusTests : TestbaseBase
    {
        [Fact]
        public void TestSKUs()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                AzureOperationResponse<IPage<TestBaseAccountSKU>> result = t_TestBaseClient.Skus.ListWithHttpMessagesAsync().GetAwaiter().GetResult();
                Assert.NotNull(result);
                Assert.NotNull(result.Body);// B0/testBaseAccounts/Basic , S0/testBaseAccounts/Standard

                var nextList=t_TestBaseClient.Skus.ListNextWithHttpMessagesAsync(null);

                Assert.True(nextList.Exception.InnerExceptions.Count == 1);
            }
        }

    }
}
