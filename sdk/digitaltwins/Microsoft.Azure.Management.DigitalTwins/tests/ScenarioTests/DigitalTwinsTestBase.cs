// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DigitalTwins.Tests.Helpers;
using Microsoft.Azure.Management.DigitalTwins;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;

namespace DigitalTwins.Tests.ScenarioTests
{
    public class DigitalTwinsTestBase
    {
        private readonly object _initializeLock = new object();

        protected static string DefaultLocation = "westcentralus";
        protected static string DefaultInstanceName = "DigitalTwinsSdk";
        protected static string DefaultEndpointName = "DigitalTwinsSdkEndpoint";
        protected static string DefaultTsdbConnectionName = "DigitalTwinsSdkTsdbConnection";
        protected static string DefaultResourceGroupName = "DigitalTwinsSdkRg";

        // Time series database connection endpoints configuration
        protected static string DefaultAdxClusterName = "DigitalTwinsSdkCluster";
        protected static string DefaultAdxEndpointUri = $"https://{DefaultAdxClusterName}.kusto.windows.net";
        protected static string DefaultAdxDatabaseName = "DigitalTwinsSdkDatabase";
        protected static string DefaultAdxTableName = "DigitalTwinsSdkDatabase";
        protected static string DefaultAdxResourceId = $"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.Kusto/clusters/{DefaultAdxClusterName}";
        protected static string DefaultEventHubNamespaceName = "DigitalTwinsSdkEventHubNamespace";
        protected static string DefaultEventHubEndpointUri = $"sb://{DefaultEventHubNamespaceName}.servicebus.windows.net/";
        protected static string DefaultEventHubNamespaceResourceId = $"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.EventHub/namespaces/{DefaultEventHubNamespaceName}";
        protected static string DefaultEventHubName = "DigitalTwinsSdkEventHub";

        protected bool IsInitialized { get; private set; } = false;
        protected ResourceManagementClient ResourcesClient { get; private set; }
        protected AzureDigitalTwinsManagementClient DigitalTwinsClient { get; private set; }
        protected string Location { get; private set; }
        protected TestEnvironment TestEnv { get; private set; }

        protected void Initialize(MockContext context)
        {
            if (IsInitialized)
            {
                return;
            }

            lock (_initializeLock)
            {
                if (IsInitialized)
                {
                    return;
                }

                TestEnv = TestEnvironmentFactory.GetTestEnvironment();

                ResourcesClient = GetResourceManagementClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                DigitalTwinsClient = GetDigitalTwinsClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_LOCATION")))
                {
                    Location = DefaultLocation;
                }
                else
                {
                    Location = Environment.GetEnvironmentVariable("AZURE_LOCATION").Replace(" ", "").ToLower();
                }

                IsInitialized = true;
            }
        }

        private static AzureDigitalTwinsManagementClient GetDigitalTwinsClient(
            MockContext context,
            RecordedDelegatingHandler handler = null)
        {
            if (handler == null)
            {
                handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            }
            else
            {
                handler.IsPassthrough = true;
            }

            return context.GetServiceClient<AzureDigitalTwinsManagementClient>(false, handler);
        }

        private static ResourceManagementClient GetResourceManagementClient(
            MockContext context,
            RecordedDelegatingHandler handler)
        {
            handler.IsPassthrough = true;
            return context.GetServiceClient<ResourceManagementClient>(false, handler);
        }
    }
}
