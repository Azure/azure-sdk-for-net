// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestBase.Tests
{
    public class TestSummariesTests : TestbaseBase
    {
        string testSummaryName = "TestSummary-fd550cae-fe50-3cd9-bf95-4e51be898883";
        string nextPageLink = null;

        [Fact]
        public void TestTestSummary()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                try
                {
                    var result = t_TestBaseClient.TestSummaries.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                    Assert.NotNull(result.Body);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.TestSummaries.ListNextWithHttpMessagesAsync(nextPageLink));

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.TestSummaries.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, ErrorValue));

                try
                {
                    var testSummary = t_TestBaseClient.TestSummaries.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, testSummaryName).GetAwaiter().GetResult();
                    Assert.Equal(testSummaryName, testSummary.Body.Name);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
            }
        }
    }
}
