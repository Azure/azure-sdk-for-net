// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using EventGrid.Tests.TestHelper;
using System;

namespace EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        private ResourceManagementClient resourceManagementClient;
        private EventGridManagementClient eventGridManagementClient;
        private RecordedDelegatingHandler handler = new RecordedDelegatingHandler();

        protected bool m_initialized = false;
        protected object m_lock = new object();

        protected void InitializeClients(MockContext context)
        {
            if (!m_initialized)
            {
                lock (m_lock)
                {
                    try
                    {
                        if (!m_initialized)
                        {
                            resourceManagementClient = EventGridManagementHelper.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                            eventGridManagementClient = EventGridManagementHelper.GetEventGridManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                        throw;
                    }
                }
            }
        }

        public ResourceManagementClient ResourceManagementClient
        {
            get
            {
                return resourceManagementClient;
            }
        }

        public EventGridManagementClient EventGridManagementClient
        {
            get
            {
                return eventGridManagementClient;
            }
        }
    }
}