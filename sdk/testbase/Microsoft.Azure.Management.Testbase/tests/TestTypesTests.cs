// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace TestBase.Tests
{
    public class TestTypesTests : TestbaseBase
    {
        //testTypeResourceName obtained through the ListWithHttpMessagesAsync method
        //Out-of-Box-Test , Functional-Test
        string testTypeName = "Out-of-Box-Test";
        string nextPageLink = null;

        [Fact]
        public void TestTestType()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                try
                {
                    var result = t_TestBaseClient.TestTypes.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                    Assert.NotNull(result.Body);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.TestTypes.ListNextWithHttpMessagesAsync(nextPageLink));

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.TestTypes.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, ErrorValue));

                try
                {
                    var testType = t_TestBaseClient.TestTypes.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, testTypeName).GetAwaiter().GetResult();
                    Assert.NotNull(testType);
                    Assert.NotNull(testType.Body);
                    Assert.Equal(testTypeName, testType.Body.Name);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
            }
        }
    }
}
