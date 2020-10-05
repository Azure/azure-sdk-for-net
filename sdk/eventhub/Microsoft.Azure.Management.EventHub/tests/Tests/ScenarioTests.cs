// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System.Net;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.KeyVault;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;

    public partial class ScenarioTests 
    {
        private ResourceManagementClient _resourceManagementClient;
        private EventHubManagementClient _EventHubManagementClient;
        private KeyVaultManagementClient _KeyVaultManagementClient;
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
                        _resourceManagementClient = EventHubManagementHelper.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        _EventHubManagementClient = EventHubManagementHelper.GetEventHubManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        _KeyVaultManagementClient = EventHubManagementHelper.GetKeyVaultManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
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

        public EventHubManagementClient EventHubManagementClient
        {
            get
            {               
                return _EventHubManagementClient;
            }
        }

        public KeyVaultManagementClient KeyVaultManagementClient
        {
            get
            {
                return _KeyVaultManagementClient;
            }
        }
    }
}
