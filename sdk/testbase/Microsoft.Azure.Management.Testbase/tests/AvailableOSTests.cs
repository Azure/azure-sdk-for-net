// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestBase.Tests
{
    public class AvailableOSTests : TestbaseBase
    {
        /*
         * 2021-6-11 Resolved the issue of reporting an Internal Server Error
         */

        string availableOSResourceName = "Windows-10-21H1-FeatureUpdate";
        string nextPageLink = null;
        List<string> lstNames = new List<string>();

        [Fact]
        public void TestAvailableOS()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                try
                {
                    var result = t_TestBaseClient.AvailableOS.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, OsUpdateType.SecurityUpdate).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                    Assert.NotNull(result.Body);

                    var arr = result.Body.GetEnumerator();
                    while (arr.MoveNext() && (arr.Current != null))
                    {
                        lstNames.Add(arr.Current.Name);//Windows-10-21H1-FeatureUpdate
                    }
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }

                try
                {
                    var result = t_TestBaseClient.AvailableOS.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, OsUpdateType.FeatureUpdate).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                    Assert.NotNull(result.Body);

                    var arr = result.Body.GetEnumerator();
                    while (arr.MoveNext() && (arr.Current != null))
                    {
                        if (!lstNames.Contains(arr.Current.Name))
                            lstNames.Add(arr.Current.Name);//Windows-10-21H1-FeatureUpdate
                    }
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.AvailableOS.ListNextWithHttpMessagesAsync(nextPageLink));

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.AvailableOS.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, ErrorValue));

                try
                {
                    if (lstNames.Count > 0)
                    {
                        availableOSResourceName = lstNames[0];
                        var availableOS = t_TestBaseClient.AvailableOS.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, availableOSResourceName).GetAwaiter().GetResult();
                        Assert.NotNull(availableOS);
                        Assert.NotNull(availableOS.Body);
                        Assert.Equal(availableOSResourceName, availableOS.Body.Name);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }
            }
        }
    }
}
