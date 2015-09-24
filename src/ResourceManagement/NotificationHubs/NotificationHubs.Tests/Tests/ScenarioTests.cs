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
    using Xunit;

    public partial class ScenarioTests : TestBase
    {
        private ManagementClient _managmentClient;
        private ResourceManagementClient _resourceManagementClient;
        private NotificationHubsManagementClient _notificationHubsManagementClient;
        private RecordedDelegatingHandler handler = new RecordedDelegatingHandler();

        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string NamespaceName { get; set; }

        public ManagementClient ManagmentClient
        {
            get
            {
                if (_managmentClient == null)
                {
                    _managmentClient = NotificationHubsManagementHelper.GetManagementClient(handler);
                }
                return _managmentClient;
            }
        }

        public ResourceManagementClient ResourceManagementClient
        {
            get
            {
                if (_resourceManagementClient == null)
                {
                    _resourceManagementClient = NotificationHubsManagementHelper.GetResourceManagementClient(handler);
                }
                return _resourceManagementClient;
            }
        }

        public NotificationHubsManagementClient NotificationHubsManagementClient
        {
            get
            {
                if (_notificationHubsManagementClient == null)
                {
                    _notificationHubsManagementClient = NotificationHubsManagementHelper.GetNotificationHubsManagementClient(handler);
                }
                return _notificationHubsManagementClient;
            }
        }

        protected void TryCreateNamespace()
        {
            this.ResourceGroupName = this.ResourceManagementClient.TryGetResourceGroup(Location);
            this.Location = NotificationHubsManagementHelper.DefaultLocation;

            if (string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                ResourceGroupName = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                this.ResourceManagementClient.TryRegisterResourceGroup(Location, ResourceGroupName);
            }

            NamespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);
            this.NotificationHubsManagementClient.TryCreateNamespace(ResourceGroupName, NamespaceName, Location);
        }        
    }
}
