// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Hyak.Common;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace RemoteApp.Tests
{
    /// <summary>
    /// RemoteApp collection active directory related test cases
    /// </summary>
    public class ActiveDirectoryTests : RemoteAppTestBase
    {

        private string GetCollectionName()
        {
            RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();
            CollectionListResult result = remoteAppManagementClient.Collections.List();

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            IList<Collection> colList = result.Collections;
            Random r = new Random(42);
            int index = r.Next(0, colList.Count - 1);
            return colList[index].Name;
        }

        private void AssertNotNullOrEmpty(string val)
        {
            Assert.NotNull(val);
            Assert.NotEmpty(val);
        }
        private void AssertNotNullOrEmpty(IList<string> val)
        {
            Assert.NotNull(val);
            Assert.NotEmpty(val);
        }

        private void ValidateAD(RemoteAppManagementClient client, ActiveDirectoryConfig adConfig)
        {
            AssertNotNullOrEmpty(adConfig.DomainName);
            AssertNotNullOrEmpty(adConfig.UserName);
        }

        /// <summary>
        /// Testing for querying a collection active directory configuration
        /// </summary>
        [Fact]
        public void CanGetAD()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                ActiveDirectoryConfigResult result = null;
                //CollectionListResult collectionList = remoteAppManagementClient.Collections.List();

                //Assert.NotNull(collectionList);
                //Assert.Equal(HttpStatusCode.OK, collectionList.StatusCode);
                //Assert.NotNull(collectionList.Collections);
                //Assert.NotEmpty(collectionList.Collections);

                result = remoteAppManagementClient.Collections.GetAd("testd112");

                Assert.NotNull(result);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                AssertNotNullOrEmpty(result.RequestId);
                Assert.NotNull(result.ActiveDirectoryConfig);
                AssertNotNullOrEmpty(result.ActiveDirectoryConfig.DomainName);
                AssertNotNullOrEmpty(result.ActiveDirectoryConfig.UserName);

                //verify that the simple or cloud only collection does not have an AD info and throws a WebFault
                Assert.Throws(typeof(CloudException), () =>
                    {
                        result = remoteAppManagementClient.Collections.GetAd("simple");
                    });
            }
        }

        /// <summary>
        /// Testing of creating an active directory configuration for a RemoteApp collection
        /// </summary>
        [Fact]
        public void CanCreateAD()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();
                HttpStatusCode[] statusSuccess = { HttpStatusCode.OK, HttpStatusCode.Accepted };

                    ActiveDirectoryConfigParameter payload = new ActiveDirectoryConfigParameter()
                    {
                        DomainName = "MyDomain",
                        UserName = "TestUser@service.com",
                        Password = "secret"
                    };

                    OperationResultWithTrackingId result = null;

                    Assert.DoesNotThrow(() =>
                    {
                        result = remoteAppManagementClient.Collections.SetAd("testd112", payload);
                    });

                    Assert.NotNull(result);
                    Assert.True(result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Accepted);

                    if (result.StatusCode == HttpStatusCode.Accepted)
                    {
                        Assert.NotNull(result.TrackingId);
                    }
            }
        }
    }
}
