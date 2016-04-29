﻿//  
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
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using System.Net;

    public partial class ScenarioTests 
    {
        private ResourceManagementClient _resourceManagementClient;
        private NotificationHubsManagementClient _notificationHubsManagementClient;
        private RecordedDelegatingHandler handler = new RecordedDelegatingHandler();

        protected bool m_initialized = false;
        protected object m_lock = new object();
        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string NamespaceName { get; set; }
               

        protected void InitializeClients(MockContext context)
        {
            if (!m_initialized)
            {
                lock (m_lock)
                {
                    if (!m_initialized)
                    {
                        _resourceManagementClient = NotificationHubsManagementHelper.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        _notificationHubsManagementClient = NotificationHubsManagementHelper.GetNotificationHubsManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                    }
                }
            }
        }

        public ResourceManagementClient ResourceManagementClient
        {
            get
            {                
                return _resourceManagementClient;
            }
        }

        public NotificationHubsManagementClient NotificationHubsManagementClient
        {
            get
            {               
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
