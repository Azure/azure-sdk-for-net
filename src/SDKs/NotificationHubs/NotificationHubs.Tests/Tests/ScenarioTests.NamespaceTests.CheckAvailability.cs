// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


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
        public void CheckNamespaceNameAvailabilityTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var validNamespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);
                //var validNamespaceName = "amol-" + Guid.NewGuid().ToString();
                var response = NotificationHubsManagementClient.Namespaces.CheckAvailability(new CheckAvailabilityParameters(validNamespaceName, NotificationHubsManagementHelper.DefaultLocation));
                Assert.NotNull(response);
                Assert.True(response.IsAvailiable);

                const string invalidNamespaceName = "hydraNhNamespace-invalid@!!#%$#";
                response = NotificationHubsManagementClient.Namespaces.CheckAvailability(new CheckAvailabilityParameters(invalidNamespaceName,NotificationHubsManagementHelper.DefaultLocation));
                Assert.NotNull(response);
                Assert.False(response.IsAvailiable);

                // create NH Namespace  
                var location = NotificationHubsManagementHelper.DefaultLocation;
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var createResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup,
                    validNamespaceName,
                    new NamespaceCreateOrUpdateParameters {Location = location});

                Assert.NotNull(createResponse);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));
                response = NotificationHubsManagementClient.Namespaces.CheckAvailability(new CheckAvailabilityParameters(validNamespaceName, NotificationHubsManagementHelper.DefaultLocation));
                Assert.NotNull(response);
                Assert.False(response.IsAvailiable);
                               
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
