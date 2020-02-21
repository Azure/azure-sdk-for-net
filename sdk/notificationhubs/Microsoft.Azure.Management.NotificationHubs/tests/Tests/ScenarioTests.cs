// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace NotificationHubs.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using System.Net;
    using System;

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

        public bool ActivateNamespace(string resourceGroup, string namespaceName)
        {
            while (true)
            {
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);

                if (getNamespaceResponse.ProvisioningState.Equals("Succeeded", StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
        }
    }
}

