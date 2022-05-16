// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.TestBase.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestBase.Tests
{
    public class OSUpdatesTests : TestbaseBase
    {
        /*
         * 2021-6-11 Resolve the issue of reporting BadRequest exceptions, Because osUpdateResourceName is incorrect
         */

        string osUpdateResourceName = "TestResultOs-fd7a56e5-121e-3e31-8571-f856a02a74f2";
        List<string> lstNames = new List<string>();

        [Fact]
        public void TestOSUpdateOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                //Get OSUpdates List
                try
                {
                    var response = t_TestBaseClient.OSUpdates.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, t_PackageName, OsUpdateType.SecurityUpdate).GetAwaiter().GetResult();
                    Assert.NotNull(response);
                    Assert.NotNull(response.Body);

                    var arr = response.Body.GetEnumerator();
                    while (arr.MoveNext() && (arr.Current != null))
                    {
                        lstNames.Add(arr.Current.Name);//TestResultOs-fd7a56e5-121e-3e31-8571-f856a02a74f2
                    }
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }

                try
                {
                    var response = t_TestBaseClient.OSUpdates.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, t_PackageName, OsUpdateType.FeatureUpdate).GetAwaiter().GetResult();
                    Assert.NotNull(response);
                    Assert.NotNull(response.Body);

                    var arr = response.Body.GetEnumerator();
                    while (arr.MoveNext() && (arr.Current != null))
                    {
                        if (!lstNames.Contains(arr.Current.Name))
                            lstNames.Add(arr.Current.Name);//0 item
                    }
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }

                try
                {
                    if (lstNames.Count > 0)
                    {
                        osUpdateResourceName = lstNames[0];
                        var osUpdateResult = t_TestBaseClient.OSUpdates.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, t_PackageName, osUpdateResourceName).GetAwaiter().GetResult();
                        Assert.NotNull(osUpdateResult);
                        Assert.NotNull(osUpdateResult.Body);
                        Assert.Equal(osUpdateResourceName, osUpdateResult.Body.Name);
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
