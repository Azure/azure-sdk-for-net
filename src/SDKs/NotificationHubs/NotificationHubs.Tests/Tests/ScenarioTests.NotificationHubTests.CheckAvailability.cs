﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace NotificationHubs.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
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
                var responseNS = NotificationHubsManagementClient.Namespaces.CheckAvailability(new CheckAvailabilityParameters(validNamespaceName, NotificationHubsManagementHelper.DefaultLocation));
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
                    new NamespaceCreateOrUpdateParameters { Location = location });

                Assert.NotNull(createNSResponse);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                var validNotificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix) + "-valid" + TestUtilities.GenerateName();
                var responseNH = NotificationHubsManagementClient.NotificationHubs.CheckNotificationHubAvailability(resourceGroup, validNamespaceName, 
                    new CheckAvailabilityParameters(validNotificationHubName, NotificationHubsManagementHelper.DefaultLocation));
                Assert.NotNull(responseNH);
                Assert.True(responseNH.IsAvailiable);

                // create Notificationhub  
                var createNHResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, validNamespaceName, 
                    validNotificationHubName,
                    new NotificationHubCreateOrUpdateParameters {Location = location});

                Assert.NotNull(createNHResponse);

                responseNH = NotificationHubsManagementClient.NotificationHubs.CheckNotificationHubAvailability(resourceGroup, validNamespaceName, 
                    new CheckAvailabilityParameters(validNotificationHubName, NotificationHubsManagementHelper.DefaultLocation));
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
