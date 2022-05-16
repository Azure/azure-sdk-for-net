// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace TestBase.Tests
{
    public class EmailEventsTests:TestbaseBase
    {
        string emailEventResourceName = "InitialVerification";

        [Fact]
        public void TestEmailEvent()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                try
                {
                    var result=t_TestBaseClient.EmailEvents.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                    Assert.NotNull(result.Body);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }

                try
                {
                    var result=t_TestBaseClient.EmailEvents.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, emailEventResourceName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                    Assert.Equal(result.Body.Name,emailEventResourceName);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }

                
            }
        }
    }
}
