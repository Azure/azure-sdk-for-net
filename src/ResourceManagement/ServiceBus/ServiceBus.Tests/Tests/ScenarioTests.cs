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
