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
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;
    using NotificationHubs.Tests.TestHelper;
    using System;
    using System.Net;
    using Xunit;

    public partial class ScenarioTests : TestBase
    {
        [Fact]
        public void CheckNamespaceNameAvailabilityTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "CheckNamespaceNameAvailability");

                var validNamespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);
                var response = NotificationHubsManagementClient.Namespaces.CheckAvailability(new CheckAvailabilityParameters(validNamespaceName));
                Assert.NotNull(response);
                Assert.True(response.Value.IsAvailable);

                const string invalidNamespaceName = "hydraNhNamespace-invalid@!!#%$#";
                response = NotificationHubsManagementClient.Namespaces.CheckAvailability(new CheckAvailabilityParameters(invalidNamespaceName));
                Assert.NotNull(response);
                Assert.False(response.Value.IsAvailable);

                // create NH Namespace  
                var location = NotificationHubsManagementHelper.DefaultLocation;
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var createResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, validNamespaceName,  
                    new NamespaceCreateOrUpdateParameters(
                    location,
                    new NamespaceProperties
                    {
                        NamespaceType = NamespaceType.NotificationHub,
                    }));

                Assert.NotNull(createResponse);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));
                response = NotificationHubsManagementClient.Namespaces.CheckAvailability( new CheckAvailabilityParameters(validNamespaceName));
                Assert.NotNull(response);
                Assert.False(response.Value.IsAvailable);

                //Delete namespace
                var deleteNSResponse = NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, validNamespaceName);
                Assert.NotNull(deleteNSResponse);
                Assert.True(HttpStatusCode.NotFound == deleteNSResponse.StatusCode || HttpStatusCode.OK == deleteNSResponse.StatusCode);
            }
        }
    }
}
