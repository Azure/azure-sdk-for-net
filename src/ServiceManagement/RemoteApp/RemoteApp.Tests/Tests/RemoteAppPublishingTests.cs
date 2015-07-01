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

using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace RemoteApp.Tests
{
    /// <summary>
    /// RemoteApp collection program publishing test cases
    /// </summary>
    public class PublishingTests : RemoteAppTestBase
    {
        private const int AppPublihingStatusCheckIntervalSeconds = 10;
        private const int AppPublihingStatusCheckMaxRetries = 12;

        /// <summary>
        /// Testing of publishing/modification/unpublishing of programs in a collection
        /// </summary>
        [Fact]
        public void CanPublishModifyUnpublishApps()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                CollectionListResult serviceList = null;
                Assert.DoesNotThrow(() =>
                {
                    serviceList = client.Collections.List();
                });

                Assert.NotNull(serviceList);
                Assert.NotEmpty(serviceList.Collections);

                Collection activeCollection = null;
                ApplicationDetailsListParameter appDetailsList = new ApplicationDetailsListParameter();
                PublishedApplicationDetails publishApp = new PublishedApplicationDetails();
                string publishingAppName = TestUtilities.GenerateName("TestApp");
                string publishingAppAlias = null;
                GetPublishedApplicationResult publishedAppResult = null;

                // Find collection in "Active" state so that publishing operations can be performed
                foreach (Collection ser in serviceList.Collections)
                {
                    if (ser.Status == "Active")
                    {
                        activeCollection = ser;
                        break;
                    }
                }

                Assert.NotNull(activeCollection);

                // Publish an App
                {
                    appDetailsList.DetailsList = new List<PublishedApplicationDetails>();
                    publishApp.AvailableToUsers = true;
                    publishApp.Name = publishingAppName;
                    publishApp.VirtualPath = "%systemroot%\\system32\\notepad.exe";
                    publishApp.IconPngUris = new IconPngUrisType();     // backend throws exception if this is null

                    appDetailsList.DetailsList.Add(publishApp);

                    PublishApplicationsResult publishResult = client.Publishing.PublishApplications(activeCollection.Name, appDetailsList);

                    // Verify for publish operation
                    Assert.NotNull(publishResult);
                    Assert.NotEmpty(publishResult.ResultList);
                    foreach (PublishingOperationResult oneResult in publishResult.ResultList)
                    {
                        Assert.True(oneResult.Success);
                        publishingAppAlias = oneResult.ApplicationAlias;
                        break;
                    }
                }

                // Wait for app status to change to Published
                publishedAppResult = WaitForAppStatus(client, activeCollection.Name, publishingAppAlias, AppPublishingStatus.Published);

                // Modify Published application
                {
                    PublishedApplicationDetails newAppDetails = publishedAppResult.Result;
                    ApplicationDetailsParameter newAppDetailsParam = new ApplicationDetailsParameter();

                    newAppDetails.Name = TestUtilities.GenerateName("ModTestApp");
                    newAppDetailsParam.Details = newAppDetails;

                    ModifyApplicationResult modifiedAppResult = client.Publishing.ModifyApplication(activeCollection.Name, publishingAppAlias, newAppDetailsParam);

                    // Verify Modify app result
                    Assert.NotNull(modifiedAppResult);
                    Assert.NotNull(modifiedAppResult.Result);
                    Assert.True(modifiedAppResult.StatusCode == HttpStatusCode.OK);
                }

                // Wait for app status to change to Published
                publishedAppResult = WaitForAppStatus(client, activeCollection.Name, publishingAppAlias, AppPublishingStatus.Published);

                // Unpublish the application
                {
                    UnpublishApplicationsResult unpublishAppResult = client.Publishing.Unpublish(activeCollection.Name, new AliasesListParameter { AliasesList = { publishingAppAlias } });

                    // Verify unpublish app result
                    Assert.NotNull(unpublishAppResult);
                    Assert.NotEmpty(unpublishAppResult.ResultList);
                    foreach (PublishingOperationResult oneResult in unpublishAppResult.ResultList)
                    {
                        Assert.True(oneResult.Success);
                    }
                }
            }
        }

        private GetPublishedApplicationResult WaitForAppStatus(RemoteAppManagementClient client, string collectionId, string appAlias, AppPublishingStatus status)
        {
            // Wait for application status to change to "Published"
            GetPublishedApplicationResult publishedAppResult = null;
            int retryCount = 0;

            do
            {
                // Need not wait in Mock environment
                if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                {
                    TestUtilities.Wait(AppPublihingStatusCheckIntervalSeconds * 1000);
                }

                publishedAppResult = client.Publishing.Get(collectionId, appAlias);
                Assert.NotNull(publishedAppResult);
                Assert.NotNull(publishedAppResult.Result);
                Assert.True(publishedAppResult.StatusCode == HttpStatusCode.OK);
                retryCount++;
            } while (retryCount < AppPublihingStatusCheckMaxRetries &&
                     publishedAppResult.Result.Status != status);

            Assert.True(retryCount < AppPublihingStatusCheckMaxRetries);

            return publishedAppResult;
        }

        /// <summary>
        /// Testing of querying of start menu applications from a collection
        /// </summary>
        [Fact]
        public void CanGetStartMenuApplicationList()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                CollectionListResult serviceList = null;
                Assert.DoesNotThrow(() =>
                {
                    serviceList = client.Collections.List();
                });

                Assert.NotNull(serviceList);

                Assert.NotEmpty(serviceList.Collections);

                foreach (Collection collection in serviceList.Collections)
                {
                    if (collection.Status != "Active")
                    {
                        continue;
                    }

                    GetStartMenuApplicationListResult appListResult = client.Publishing.StartMenuApplicationList(collection.Name);

                    Assert.NotNull(appListResult);
                    Assert.NotEmpty(appListResult.ResultList);
                    Assert.True(appListResult.StatusCode == HttpStatusCode.OK);

                    return;
                }

                Assert.False(true);
            }
        }

        /// <summary>
        /// Testing of querying of a single start menu application from a collection
        /// </summary>
        [Fact]
        public void CanGetStartMenuApplication()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                CollectionListResult serviceList = null;
                Assert.DoesNotThrow(() =>
                {
                    serviceList = client.Collections.List();
                });

                Assert.NotNull(serviceList);

                Assert.NotEmpty(serviceList.Collections);

                foreach (Collection collection in serviceList.Collections)
                {
                    GetStartMenuApplicationListResult appListResult = client.Publishing.StartMenuApplicationList(collection.Name);

                    foreach (StartMenuApplication startMenuApp in appListResult.ResultList)
                    {
                        GetStartMenuApplicationResult appResult = client.Publishing.StartMenuApplication(collection.Name, startMenuApp.StartMenuAppId);

                        Assert.NotNull(appResult);
                        Assert.NotNull(appResult.Result);
                        Assert.True(appResult.StatusCode == HttpStatusCode.OK);

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Testing of unpublishing of all the programs from a collection
        /// </summary>
        [Fact]
        public void CanUnpublishAllApps()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();
                Collection activeCollection = null;

                CollectionListResult serviceList = null;
                Assert.DoesNotThrow(() =>
                {
                    serviceList = client.Collections.List();
                });

                Assert.NotNull(serviceList);
                Assert.NotEmpty(serviceList.Collections);

                foreach (Collection collection in serviceList.Collections)
                {
                    // Find the collection in Active state so that Publish/UnPublish operations can be performed
                    if (collection.Status == "Active")
                    {
                        activeCollection = collection;
                        continue;
                    }
                }

                Assert.NotNull(activeCollection);

                // Save the apps list
                GetPublishedApplicationListResult appsListResult = client.Publishing.List(activeCollection.Name);

                Assert.NotNull(appsListResult);
                Assert.True(appsListResult.StatusCode == HttpStatusCode.OK);

                // Unpublish all apps
                UnpublishApplicationsResult unpublishResult = client.Publishing.UnpublishAll(activeCollection.Name);

                Assert.NotNull(unpublishResult);

                // Wait for all apps to be unpublished
                {
                    GetPublishedApplicationListResult newAppsListResult = null;
                    int retryCount = 0;

                    do
                    {
                        // Need not wait in Mock environment
                        if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                        {
                            TestUtilities.Wait(AppPublihingStatusCheckIntervalSeconds * 1000);
                        }

                        newAppsListResult = client.Publishing.List(activeCollection.Name);
                        Assert.NotNull(newAppsListResult);
                        Assert.NotNull(newAppsListResult.ResultList);
                        Assert.True(newAppsListResult.StatusCode == HttpStatusCode.OK);
                        retryCount++;
                    } while (retryCount < AppPublihingStatusCheckMaxRetries &&
                                newAppsListResult.ResultList.Count != 0);

                    Assert.True(retryCount < AppPublihingStatusCheckMaxRetries);
                }

                // Re-Publish the original application list
                PublishApplicationsResult publishResult = client.Publishing.PublishApplications(
                                                                activeCollection.Name,
                                                                new ApplicationDetailsListParameter { DetailsList = appsListResult.ResultList });

                Assert.NotNull(publishResult);
                Assert.NotNull(publishResult.ResultList);
                Assert.True(publishResult.StatusCode == HttpStatusCode.OK);
            }
        }
    }
}
