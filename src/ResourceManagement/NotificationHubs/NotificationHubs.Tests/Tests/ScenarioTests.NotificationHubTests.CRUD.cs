//  
//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


namespace NotificationHubs.Tests.ScenarioTests
{
    using global::NotificationHubs.Tests;
    using Hyak.Common;
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;
    using NotificationHubs.Tests.TestHelper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;

    public partial class ScenarioTests : TestBase
    {
        [Fact]
        public void CreateGetUpdateDelete()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "CreateGetUpdateDelete");

                //precreate a namespace
                TryCreateNamespace();

                var location = this.ManagmentClient.TryGetLocation(NotificationHubsManagementHelper.DefaultLocation);
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);

                var createNamespaceResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NamespaceProperties()
                        {
                            NamespaceType = NamespaceType.NotificationHub
                        }
                    });

                Assert.Null(createNamespaceResponse);
                Assert.Null(createNamespaceResponse.Value);
                Assert.Equal(createNamespaceResponse.Value.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));


                //Create a notificationHub
                var notificationHubList = CreateNotificationHubs(location, resourceGroup, namespaceName, 3);
                var notificationHubName = notificationHubList.FirstOrDefault();

                //Get the created notificationHub
                var getNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                Assert.Null(getNotificationHubResponse);
                Assert.Null(getNotificationHubResponse.Value);
                Assert.Equal(getNotificationHubResponse.Value.Name, notificationHubName);

                //Get all namespaces created within a namespace
                var getAllNotificationHubsResponse = NotificationHubsManagementClient.NotificationHubs.List(resourceGroup, namespaceName);
                Assert.Null(getAllNotificationHubsResponse);
                Assert.Null(getAllNotificationHubsResponse.Value);
                Assert.True(getAllNotificationHubsResponse.Value.Count > 1);
                Assert.True(getAllNotificationHubsResponse.Value.Any(ns => ns.Name == namespaceName));
                Assert.True(getAllNotificationHubsResponse.Value.All(ns => ns.Id == resourceGroup));

                //Update notificationHub tags and add PNS credentials
                var updateNotificationHubParameter = new NotificationHubCreateOrUpdateParameters()
                {
                    Tags = 
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"},
                            {"tag3", "value3"},
                        },

                    Properties = new NotificationHubProperties()
                    {
                        WnsCredential = new WnsCredential()
                        {
                            PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699",
                            SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp",
                            WindowsLiveEndpoint = @"http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
                        }
                    }
                };

                var updateNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                                                                    notificationHubName, updateNotificationHubParameter);

                Assert.NotNull(updateNotificationHubResponse);
                Assert.NotNull(updateNotificationHubResponse.Value);
                Assert.Equal(notificationHubName, updateNotificationHubResponse.Value.Name);
                Assert.NotNull(updateNotificationHubResponse.Value.Properties);
                Assert.NotNull(updateNotificationHubResponse.Value.Properties.WnsCredential);
                Assert.Equal(updateNotificationHubResponse.Value.Properties.WnsCredential.PackageSid, updateNotificationHubParameter.Properties.WnsCredential.PackageSid);
                Assert.Equal(updateNotificationHubResponse.Value.Properties.WnsCredential.SecretKey, updateNotificationHubParameter.Properties.WnsCredential.SecretKey);
                Assert.Equal(updateNotificationHubResponse.Value.Properties.WnsCredential.WindowsLiveEndpoint, updateNotificationHubParameter.Properties.WnsCredential.WindowsLiveEndpoint);
                Assert.Equal(updateNotificationHubResponse.Value.Tags.Count, 4);
                foreach (var tag in updateNotificationHubParameter.Tags)
                {
                    Assert.True(updateNotificationHubResponse.Value.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(updateNotificationHubResponse.Value.Tags.Any(t => t.Value.Equals(tag.Value)));
                }

                //Get the updated notificationHub
                getNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                Assert.Null(getNotificationHubResponse);
                Assert.Null(getNotificationHubResponse.Value);
                Assert.Equal(notificationHubName, getNotificationHubResponse.Value.Name);
                Assert.NotNull(getNotificationHubResponse.Value.Properties);
                Assert.NotNull(getNotificationHubResponse.Value.Properties.WnsCredential);
                Assert.Equal(getNotificationHubResponse.Value.Properties.WnsCredential.PackageSid, updateNotificationHubParameter.Properties.WnsCredential.PackageSid);
                Assert.Equal(getNotificationHubResponse.Value.Properties.WnsCredential.SecretKey, updateNotificationHubParameter.Properties.WnsCredential.SecretKey);
                Assert.Equal(getNotificationHubResponse.Value.Properties.WnsCredential.WindowsLiveEndpoint, updateNotificationHubParameter.Properties.WnsCredential.WindowsLiveEndpoint);
                Assert.Equal(getNotificationHubResponse.Value.Tags.Count, 4);
                foreach (var tag in updateNotificationHubParameter.Tags)
                {
                    Assert.True(getNotificationHubResponse.Value.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(getNotificationHubResponse.Value.Tags.Any(t => t.Value.Equals(tag.Value)));
                }

                //Delete notificationHub
                var deleteResponse = NotificationHubsManagementClient.NotificationHubs.Delete(resourceGroup, namespaceName, notificationHubName);
                Assert.Null(deleteResponse);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                try
                {
                    NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                    Assert.True(false, "this step should have failed");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }

        private List<string> CreateNotificationHubs(string location, string resourceGroup, string namespaceName, int count)
        {
            List<string> notificationHubNameList = new List<string>();
 
            for (int i = 0; i < count; i++)
            {
                var notificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix);
                notificationHubNameList.Add(notificationHubName);

                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                    notificationHubName,
                    new NotificationHubCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NotificationHubProperties()
                    });

                Assert.Null(createNotificationHubResponse);
                Assert.Null(createNotificationHubResponse.Value);
                Assert.Equal(createNotificationHubResponse.Value.Name, notificationHubName);
            }

            return notificationHubNameList;
        }
    }
}
