// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DeviceUpdate.Tests;
using Microsoft.Azure.Management.DeviceUpdate;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;

namespace DigitalTwins.Tests.ScenarioTests
{
    public class DeviceUpdateTestBase
    {
        private readonly object _initializeLock = new object();

        protected static string DefaultLocation = "westus2";
        protected static string DefaultInstanceName = "blue";
        protected static string DefaultEndpointName = "_foo_";
        protected static string DefaultResourceGroupName = "_bar_";

        protected bool IsInitialized { get; private set; } = false;
        protected ResourceManagementClient ResourcesClient { get; private set; }
        protected DeviceUpdateClient DeviceUpdateClient { get; private set; }
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

                DeviceUpdateClient = GetDeviceUpdateClient(
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

        private static DeviceUpdateClient GetDeviceUpdateClient(
            MockContext context,
            RecordedDelegatingHandler handler = null)
        {
            if (handler == null)
            {
                handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            }
            else
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<DeviceUpdateClient>(false, handler);
        }

        private static ResourceManagementClient GetResourceManagementClient(
            MockContext context,
            RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return context.GetServiceClient<ResourceManagementClient>(false, handler);
        }
    }
}
