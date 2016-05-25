﻿//  
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
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Net;
    using TestHelper;
    using Xunit;

    public partial class ScenarioTests 
    {
        [Fact]
        public void CheckNotificationHubNameAvailability()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var validNamespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);
                var responseNS = NotificationHubsManagementClient.Namespaces.CheckAvailability(new CheckAvailabilityParameters(validNamespaceName));
                Assert.NotNull(responseNS);
                Assert.True(responseNS.IsAvailiable);                

                // create NH Namespace  
                var location = NotificationHubsManagementHelper.DefaultLocation;
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var createNSResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, validNamespaceName,
                    new NamespaceCreateOrUpdateParameters(
                    location,
                    new NamespaceProperties
                    {
                        NamespaceType = NamespaceType.NotificationHub,
                    }));

                Assert.NotNull(createNSResponse);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                var validNotificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix) + "-valid" + TestUtilities.GenerateName();
                var responseNH = NotificationHubsManagementClient.NotificationHubs.CheckAvailability(resourceGroup, validNamespaceName, 
                    new CheckAvailabilityParameters(validNotificationHubName));
                Assert.NotNull(responseNH);
                Assert.True(responseNH.IsAvailiable);

                // create Notificationhub  
                var createNHResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, validNamespaceName, 
                    validNotificationHubName,
                    new NotificationHubCreateOrUpdateParameters(
                    location, new NotificationHubProperties()));

                Assert.NotNull(createNHResponse);

                responseNH = NotificationHubsManagementClient.NotificationHubs.CheckAvailability(resourceGroup, validNamespaceName, 
                    new CheckAvailabilityParameters(validNotificationHubName));
                Assert.NotNull(responseNH);
                Assert.False(responseNH.IsAvailiable);

                try
                {
                    //Delete namespace
                    NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, validNamespaceName);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
            }
        }
    }
}
