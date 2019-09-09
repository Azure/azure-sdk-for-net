// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace NotificationHubs.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using System;
    using Xunit;
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.Rest.Azure;
    using System.Linq;

    public partial class ScenarioTests 
    {
        [Fact]
        public void NotificationHubCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = NotificationHubsManagementHelper.DefaultLocation;
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
                        Location = location
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                ActivateNamespace(resourceGroup, namespaceName);

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);

                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Status, StringComparer.CurrentCultureIgnoreCase);

                var createParameter = new NotificationHubCreateOrUpdateParameters()
                {
                    Location = location,
                    WnsCredential = new WnsCredential()
                    {
                        PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699",
                        SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp",
                        WindowsLiveEndpoint = @"http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
                    },
                    ApnsCredential = new ApnsCredential()
                    {
                        KeyId = "TXRXD9P6K7",
                        AppId = "EF9WEB9D5K",
                        AppName = "Sample",
                        Token = "MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgpVB15km4qskA5Ra5XvdtOwWPvaXIhVVQZdonzINh+hGgCgYIKoZIzj0DAQehRANCAASS3ek04J20BqA6WWDlD6+xd3dJEifhW87wI0nnkfUB8LDb424TiWlzGIgnxV79hb3QHCAUNsPdBfLLF+Od8yqL",
                        Endpoint = "https://api.push.apple.com:443/3/device"
                    }
                };


                //Create a notificationHub
                var notificationHubList = CreateNotificationHubs(location, resourceGroup, namespaceName, 1, createParameter);
                var notificationHubName = notificationHubList.FirstOrDefault();

                //Get the created notificationHub
                var getNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                Assert.NotNull(getNotificationHubResponse);
                Assert.Equal(getNotificationHubResponse.Name, notificationHubName);

                //Get all namespaces created within a namespace
                var getAllNotificationHubsResponse = NotificationHubsManagementClient.NotificationHubs.List(resourceGroup, namespaceName);
                Assert.NotNull(getAllNotificationHubsResponse);
                Assert.True(getAllNotificationHubsResponse.Count() >= 1);
                Assert.Contains(getAllNotificationHubsResponse, nh => string.Compare(nh.Name, notificationHubName, true) == 0);
                Assert.True(getAllNotificationHubsResponse.All(nh => nh.Id.Contains(resourceGroup)));

                var getNotificationHubPnsCredentialsResponse = NotificationHubsManagementClient.NotificationHubs.GetPnsCredentials(resourceGroup, namespaceName, notificationHubName);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse);
                Assert.Equal(notificationHubName, getNotificationHubPnsCredentialsResponse.Name);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse.WnsCredential);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.PackageSid, createParameter.WnsCredential.PackageSid);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.SecretKey, createParameter.WnsCredential.SecretKey);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.WindowsLiveEndpoint, createParameter.WnsCredential.WindowsLiveEndpoint);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.KeyId, createParameter.ApnsCredential.KeyId);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.Token, createParameter.ApnsCredential.Token);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.AppId, createParameter.ApnsCredential.AppId);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.AppName, createParameter.ApnsCredential.AppName);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.Endpoint, createParameter.ApnsCredential.Endpoint);

                //Update notificationHub tags and add PNS credentials
                var updateNotificationHubParameter = new NotificationHubCreateOrUpdateParameters()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"},
                            {"tag3", "value3"},
                        },

                    WnsCredential = new WnsCredential()
                    {
                        PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699",
                        SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp",
                        WindowsLiveEndpoint = @"http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
                    },
                    ApnsCredential = new ApnsCredential()
                    {
                        KeyId = "TXRXD9P6K7",
                        AppId = "EF9WEB9D5K",
                        AppName = "Sample2",
                        Token = "MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgpVB15km4qskA5Ra5XvdtOwWPvaXIhVVQZdonzINh+hGgCgYIKoZIzj0DAQehRANCAASS3ek04J20BqA6WWDlD6+xd3dJEifhW87wI0nnkfUB8LDb424TiWlzGIgnxV79hb3QHCAUNsPdBfLLF+Od8yqL",
                        Endpoint = "https://api.push.apple.com:443/3/device"
                    }
                };

                var jsonStr = NotificationHubsManagementHelper.ConvertObjectToJSon(updateNotificationHubParameter);

                var updateNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                                                                    notificationHubName, updateNotificationHubParameter);

                Assert.NotNull(updateNotificationHubResponse);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                //Get the updated notificationHub
                getNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                Assert.NotNull(getNotificationHubResponse);
                Assert.Equal(3, getNotificationHubResponse.Tags.Count);
                foreach (var tag in updateNotificationHubParameter.Tags)
                {
                    Assert.Contains(getNotificationHubResponse.Tags, t => t.Key.Equals(tag.Key));
                    Assert.Contains(getNotificationHubResponse.Tags, t => t.Value.Equals(tag.Value));
                }

                //Get the updated notificationHub PNSCredentials
                getNotificationHubPnsCredentialsResponse = NotificationHubsManagementClient.NotificationHubs.GetPnsCredentials(resourceGroup, namespaceName, notificationHubName);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse);
                Assert.Equal(notificationHubName, getNotificationHubPnsCredentialsResponse.Name);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse.WnsCredential);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.PackageSid, updateNotificationHubParameter.WnsCredential.PackageSid);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.SecretKey, updateNotificationHubParameter.WnsCredential.SecretKey);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.WindowsLiveEndpoint, updateNotificationHubParameter.WnsCredential.WindowsLiveEndpoint);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.KeyId, updateNotificationHubParameter.ApnsCredential.KeyId);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.Token, updateNotificationHubParameter.ApnsCredential.Token);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.AppId, updateNotificationHubParameter.ApnsCredential.AppId);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.AppName, updateNotificationHubParameter.ApnsCredential.AppName);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.ApnsCredential.Endpoint, updateNotificationHubParameter.ApnsCredential.Endpoint);

                //Delete notificationHub
                NotificationHubsManagementClient.NotificationHubs.Delete(resourceGroup, namespaceName, notificationHubName);
                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                try
                {
                    NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                    Assert.True(false, "this step should have failed");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                try
                {
                    //Delete namespace
                    NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
            }
        }

        private List<string> CreateNotificationHubs(string location, string resourceGroup, string namespaceName, int count, NotificationHubCreateOrUpdateParameters parameter)
        {
            List<string> notificationHubNameList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var notificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix) + TestUtilities.GenerateName();
                notificationHubNameList.Add(notificationHubName);
                Console.WriteLine(notificationHubName);
               
                var jsonStr = NotificationHubsManagementHelper.ConvertObjectToJSon(parameter);

                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                    notificationHubName, parameter);
                Assert.NotNull(createNotificationHubResponse);
            }

            return notificationHubNameList;
        }
    }
}

