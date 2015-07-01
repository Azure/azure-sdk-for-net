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
using System.Net;
using Xunit;

namespace RemoteApp.Tests
{
    /// <summary>
    /// RemoteApp collection specific test cases
    /// </summary>
    public class CollectionTests : RemoteAppTestBase
    {
        /// <summary>
        /// Testing of querying a list of collections
        /// </summary>
        [Fact]
        public void CanGetRemoteAppServiceList()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                Assert.DoesNotThrow(() =>
                {
                    var serviceList = client.Collections.List();
                    Assert.Equal(serviceList.StatusCode, HttpStatusCode.OK);
                    Assert.NotEmpty(serviceList.Collections);
                });

            }
        }

        /// <summary>
        /// Testing of querying a collection by name
        /// </summary>
        [Fact]
        public void CanGetOneRemoteAppService()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = GetRemoteAppManagementClient();

                CollectionListResult collectionList = null;
                Assert.DoesNotThrow(() =>
                {
                    collectionList = client.Collections.List();
                });

                Assert.NotNull(collectionList);

                Assert.NotEmpty(collectionList.Collections);

                foreach (var collection in collectionList.Collections)
                {
                    var returnedService = client.Collections.Get(collection.Name);

                    Assert.NotNull(returnedService);
                    Assert.Equal(returnedService.Collection.TemplateImageName, collection.TemplateImageName);
                    Assert.Equal(returnedService.Collection.VNetName, collection.VNetName);
                }
            }
        }
 
        /// <summary>
        /// Testing of creating and deleting of a collection
        /// </summary>
        [Fact]
        public void CanCreateAndDeleteRemoteAppService()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = GetRemoteAppManagementClient();

                Collection collection = CreateNewServiceWithPopulateOnlyTrue(client);

                OperationResultWithTrackingId response = null;

                Assert.DoesNotThrow(() =>
                {
                    response = client.Collections.Delete(collection.Name);
                });

                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK);
            }
        }

        private Collection CreateNewServiceWithPopulateOnlyTrue(RemoteAppManagementClient client)
        {
            string name = "hsut2861";
            string activeDirectoryName = "ghutad";
            string billingPlanName = "Standard";
            string templateName = "bluerefresh.2014.08.21.vhd"; //GetReadyTemplateImageName(client);

            ActiveDirectoryConfig adDetails = new ActiveDirectoryConfig()
            {
                DomainName = activeDirectoryName,
                UserName = "Admin@service.com",
                Password = "secret"
            };

            CollectionCreationDetails collectionDetails = new CollectionCreationDetails()
            {
                Name = name,
                AdInfo = adDetails,
                PlanName = billingPlanName,
                TemplateImageName = templateName,
                Description = "OneSDK test created.",
                Mode = CollectionMode.Apps,
                ReadyForPublishing = true,
                VNetName = "SomeVnet"
            };

            OperationResultWithTrackingId result = null;

            Assert.DoesNotThrow(() =>
            {
                result = client.Collections.Create(true, collectionDetails);
            });

            Assert.NotNull(result);

            // if OK is returned then the tracking id is the name of the newly created collection
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.NotNull(result.TrackingId);

            // now check if the object is actually created at the backend
            CollectionResult queriedService = client.Collections.Get(collectionDetails.Name);

            Assert.Equal(HttpStatusCode.OK, queriedService.StatusCode);
            Assert.Equal(queriedService.Collection.Name, name);
            Assert.Equal(queriedService.Collection.PlanName, collectionDetails.PlanName);
            Assert.Equal(queriedService.Collection.TemplateImageName, collectionDetails.TemplateImageName);
            Assert.Equal(queriedService.Collection.Status, "Creating");

            return queriedService.Collection;
        }

        private string GetReadyTemplateImageName(RemoteAppManagementClient client)
        {
            string activeImageName = string.Empty;

            TemplateImageListResult allImageList = client.TemplateImages.List();

            Assert.NotNull(allImageList);
            Assert.Equal(HttpStatusCode.OK, allImageList.StatusCode);
            Assert.NotNull(allImageList.RemoteAppTemplateImageList);
            Assert.NotEmpty(allImageList.RemoteAppTemplateImageList);

            foreach (TemplateImage image in allImageList.RemoteAppTemplateImageList)
            {
                if (image.Status == TemplateImageStatus.Ready)
                {
                    activeImageName = image.Name;
                    break;
                }
            }

            Assert.False(string.IsNullOrEmpty(activeImageName), "Ready template image name is empty.");

            return activeImageName;
        }

        /// <summary>
        /// Testing of querying the list of sessions from a collection
        /// </summary>
        [Fact]
        public void CanGetSessionsList()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                CollectionSessionListResult sessionsResponse = client.Collections.ListSessions("testd112");
                RemoteAppSession session = null;

                Assert.NotNull(sessionsResponse);
                Assert.NotNull(sessionsResponse.Sessions);
                Assert.True(sessionsResponse.StatusCode == HttpStatusCode.OK);
                Assert.Empty(sessionsResponse.Sessions);

                // verify the serialization of the response with one item
                sessionsResponse = client.Collections.ListSessions("simple");
                Assert.NotNull(sessionsResponse);
                Assert.NotNull(sessionsResponse.Sessions);
                Assert.True(sessionsResponse.StatusCode == HttpStatusCode.OK);
                Assert.NotEmpty(sessionsResponse.Sessions);
                Assert.True(sessionsResponse.Sessions.Count == 1, "There must be only 1 session here.");

                session = sessionsResponse.Sessions[0];

                // these data are validated from the recorded json file
                Assert.NotNull(session);
                Assert.True(session.State == SessionState.Connected);
            }
        }

        /// <summary>
        /// Negative testing of session commands
        /// </summary>
        [Fact]
        public void CanNotSendCommandToASessionOnNonExistingCollection()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                SessionCommandParameter parameter = new SessionCommandParameter
                {
                    UserUpn = "some@test.com"
                };

                // testing the web fault
                OperationResultWithTrackingId response = null;

                Assert.Throws<CloudException>(() => response = client.Collections.LogoffSession("mycoll", parameter));

                Assert.Throws<CloudException>(() => response = client.Collections.DisconnectSession("mycoll", parameter));

                SessionSendMessageCommandParameter messageParameter = new SessionSendMessageCommandParameter()
                {
                    Message = "Hey there!",
                    UserUpn = "some1@test.com"
                };

                Assert.Throws<CloudException>(() => response = client.Collections.SendMessageToSession("mycoll", messageParameter));
            }
        }

        /// <summary>
        /// Testing of logging of a session from a collection
        /// </summary>
        [Fact]
        public void CanLogOffASessionFromACollection()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                SessionCommandParameter parameter = new SessionCommandParameter
                {
                    UserUpn = "yadavb@hotmail.com"
                };

                // testing the web fault
                OperationResultWithTrackingId response = null;

                response = client.Collections.LogoffSession("simple", parameter);

                Assert.NotNull(response);
                Assert.NotNull(response.TrackingId);
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

                AssertLongrunningOperation(client, RemoteAppOperationStatus.Success, response.TrackingId);

                TestUtilities.Wait(20000); //wait a little bit

                CollectionSessionListResult sessionList = client.Collections.ListSessions("simple");

                Assert.NotNull(sessionList);
                Assert.NotNull(sessionList.Sessions);
                Assert.True(sessionList.StatusCode == HttpStatusCode.OK);

                RemoteAppSession session = null;

                foreach (var s in sessionList.Sessions)
                {
                    if (s.UserUpn == parameter.UserUpn)
                    {
                        session = s;
                        break;
                    }
                }

                Assert.Null(session);
            }
        }

        private static void AssertLongrunningOperation(RemoteAppManagementClient client, RemoteAppOperationStatus status, String operationTrackingId)
        {
            int retries = 10;
            RemoteAppOperationStatusResult operationResult = null;

            //check for the operation status to success
            while (retries > 0)
            {
                operationResult = null;

                Assert.DoesNotThrow(() =>
                {
                    operationResult = client.OperationResults.Get(operationTrackingId);
                });

                Assert.Equal(operationResult.StatusCode, HttpStatusCode.OK);
                if (operationResult.RemoteAppOperationResult.Status == RemoteAppOperationStatus.Success ||
                    operationResult.RemoteAppOperationResult.Status == RemoteAppOperationStatus.Failed)
                {

                    break;
                }
                else
                {
                    TestUtilities.Wait(1000);
                    --retries;
                }
            }

            Assert.True(retries > 0, "Failed getting the operation status to success or fail after 10 retries.");
            Assert.NotNull(operationResult);
            Assert.Equal(status, operationResult.RemoteAppOperationResult.Status);
        }

        /// <summary>
        /// Testing of disconnecting a session in a collection
        /// </summary>
        [Fact]
        public void CanDisconnectASessionInACollection()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                SessionCommandParameter parameter = new SessionCommandParameter
                {
                    UserUpn = "yadavb@hotmail.com"
                };

                // testing the web fault
                OperationResultWithTrackingId response = null;

                response = client.Collections.DisconnectSession("simple", parameter);

                Assert.NotNull(response);
                Assert.NotNull(response.TrackingId);
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

                AssertLongrunningOperation(client, RemoteAppOperationStatus.Success, response.TrackingId);

                TestUtilities.Wait(20000);

                CollectionSessionListResult sessionList = client.Collections.ListSessions("simple");

                Assert.NotNull(sessionList);
                Assert.NotNull(sessionList.Sessions);
                Assert.True(sessionList.StatusCode == HttpStatusCode.OK);
                Assert.NotEmpty(sessionList.Sessions);

                RemoteAppSession session = null;

                foreach (var s in sessionList.Sessions)
                {
                    if (s.UserUpn == parameter.UserUpn)
                    {
                        session = s;
                        break;
                    }
                }

                Assert.NotNull(session);
                Assert.Equal(SessionState.Disconnected, session.State);
            }
        }

        /// <summary>
        /// Testing of sending message to a session in a collection 
        /// </summary>
        [Fact]
        public void CanSendMessageToASessionInACollection()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                SessionSendMessageCommandParameter parameter = new SessionSendMessageCommandParameter
                {
                    UserUpn = "yadavb@hotmail.com",
                    Message = "Hello there!"
                };

                // testing the web fault
                OperationResultWithTrackingId response = null;

                response = client.Collections.SendMessageToSession("simple", parameter);


                Assert.NotNull(response);
                Assert.NotNull(response.TrackingId);
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

                AssertLongrunningOperation(client, RemoteAppOperationStatus.Success, response.TrackingId);

                CollectionSessionListResult sessionList = client.Collections.ListSessions("simple");

                Assert.NotNull(sessionList);
                Assert.NotNull(sessionList.Sessions);
                Assert.True(sessionList.StatusCode == HttpStatusCode.OK);
                Assert.NotEmpty(sessionList.Sessions);

                RemoteAppSession session = null;

                foreach (var s in sessionList.Sessions)
                {
                    if (s.UserUpn == parameter.UserUpn)
                    {
                        session = s;
                        break;
                    }
                }

                Assert.NotNull(session);
                Assert.True(session.State == SessionState.Connected);
            }
        }

        /// <summary>
        /// Testing of querying of collection usage summary
        /// </summary>
        [Fact]
        public void CanGetCollectionUsageSummary()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = GetRemoteAppManagementClient();

                CollectionUsageSummaryListResult billingSummary = client.Collections.GetUsageSummary("simple", "2015", "2");

                Assert.NotNull(billingSummary);
                Assert.Equal(HttpStatusCode.OK, billingSummary.StatusCode);
                Assert.NotNull(billingSummary.UsageSummaryList);
                Assert.NotEmpty(billingSummary.UsageSummaryList);
                Assert.False(String.IsNullOrWhiteSpace(billingSummary.UsageSummaryList[0].UserName), "The user name must not be empty.");
            }
        }

        /// <summary>
        /// Testing of querying of collection usage details
        /// </summary>
        [Fact]
        public void CanGetCollectionUsageDetails()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = GetRemoteAppManagementClient();

                CollectionUsageDetailsResult usageDetails = client.Collections.GetUsageDetails("simple", "2015", "2", "en-us");

                Assert.NotNull(usageDetails);
                Assert.Equal(HttpStatusCode.OK, usageDetails.StatusCode);
                Assert.NotNull(usageDetails.UsageDetails.OperationTrackingId);
                Assert.NotNull(usageDetails.UsageDetails.SasUri);

                // ensure that the tracking id is valid one and can get the operation status
                AssertLongrunningOperation(client, RemoteAppOperationStatus.Success, usageDetails.UsageDetails.OperationTrackingId);

                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();

                if (mode == HttpRecorderMode.Record)
                {
                    // these tests only can be executed during the record mode as the URI is not valid without the proper creds

                    WebClient webClient = new WebClient();
                    byte[] detailUsage = webClient.DownloadData(new Uri(usageDetails.UsageDetails.SasUri));

                    Assert.NotNull(detailUsage);
                    Assert.NotEmpty(detailUsage);
                }
            }
        }

        /// <summary>
        /// Testing of querying of collection regions list
        /// </summary>
        [Fact]
        public void CanGetCollectionRegionList()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = GetRemoteAppManagementClient();

                RegionListResult result = client.Collections.RegionList();

                Assert.NotNull(result);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.NotEmpty(result.Regions);
            }
        }

        private void CanCreateNonPopulateOnlyAndDeleteRemoteAppService()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = GetRemoteAppManagementClient();

                string name = TestUtilities.GenerateName("ghut");
                string activeDirectoryName = TestUtilities.GenerateName("ghut");
                string billingPlanName = "Standard";
                string templateName = TestUtilities.GenerateName("ghut");    // BUGBUG this must be a real template
                HttpStatusCode[] statusSuccess = { HttpStatusCode.OK, HttpStatusCode.Accepted };

                ActiveDirectoryConfig adDetails = new ActiveDirectoryConfig()
                {
                    DomainName = activeDirectoryName,
                    UserName = "Admin",
                    Password = "secret"
                };

                CollectionCreationDetails collectionDetails = new CollectionCreationDetails()
                {
                    Name = name,
                    AdInfo = adDetails,
                    PlanName = billingPlanName,
                    TemplateImageName = templateName,
                    Description = "OneSDK test created.",
                    Mode = CollectionMode.Apps,
                    ReadyForPublishing = true,
                    VNetName = "SomeVnet"
                };

                CollectionResult queriedCollection = null;

                OperationResultWithTrackingId result = client.Collections.Create(false, collectionDetails);
                Assert.NotNull(result);
                Assert.Contains(result.StatusCode, statusSuccess);

                if (result.StatusCode == HttpStatusCode.Accepted)
                {
                    //                    RemoteAppManagementClient.WaitForLongRunningOperation(result.TrackingId, timeoutMs, client);
                    Assert.True(result.StatusCode == HttpStatusCode.OK, "Failed to create collection.");
                }

                queriedCollection = client.Collections.Get(collectionDetails.Name);
                Assert.Equal(queriedCollection.Collection.AdInfo.DomainName, collectionDetails.AdInfo.DomainName);
                Assert.Equal(queriedCollection.Collection.PlanName, collectionDetails.PlanName);
                Assert.Equal(queriedCollection.Collection.TemplateImageName, collectionDetails.TemplateImageName);
                Assert.Equal(queriedCollection.Collection.Mode, collectionDetails.Mode);
                Assert.Equal(queriedCollection.Collection.VNetName, collectionDetails.VNetName);
                Assert.Equal(queriedCollection.Collection.Description, collectionDetails.Description);
                Assert.Equal(queriedCollection.Collection.ReadyForPublishing, collectionDetails.ReadyForPublishing);

                OperationResultWithTrackingId response = client.Collections.Delete(queriedCollection.Collection.Name);
                Assert.True(result.StatusCode == HttpStatusCode.OK, "Delete collection did not return OK.");
            }
        }
    }
}
