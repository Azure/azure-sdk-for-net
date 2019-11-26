// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System.Net;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;

    public partial class ScenarioTests 
    {
        private ResourceManagementClient _resourceManagementClient;
        private ServiceBusManagementClient _serviceBusManagementClient;
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
                        _resourceManagementClient = ServiceBusManagementHelper.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        _serviceBusManagementClient = ServiceBusManagementHelper.GetServiceBusManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
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

        public ServiceBusManagementClient ServiceBusManagementClient
        {
            get
            {               
                return _serviceBusManagementClient;
            }
        }  
    }
}
