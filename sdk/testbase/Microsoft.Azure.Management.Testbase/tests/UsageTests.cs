// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace TestBase.Tests
{
    public class UsageTests : TestbaseBase
    {
        string nextPageLink = null;

        [Fact]
        public void TestUsage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                try
                {
                    var response = t_TestBaseClient.Usage.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.Usage.ListNextWithHttpMessagesAsync(nextPageLink));
            }
        }
    }
}
