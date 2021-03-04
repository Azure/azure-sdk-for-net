// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using Microsoft.Azure.Management.DeviceUpdate.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.DeviceUpdate.Tests.ScenarioTests
{
    public abstract class DeviceUpdateTestBase
    {
        protected static string ResourceGroupName = "DeviceUpdateResourceGroup";
        protected static string DefaultLocation = "westus2";

        protected CancellationToken CancellationToken => CancellationToken.None;

        protected string Location => GetLocation().Replace(" ", "").ToLowerInvariant();

        private static string GetLocation()
        {
            var location = Environment.GetEnvironmentVariable("AZURE_LOCATION");
            return !string.IsNullOrEmpty(location) ? location : DefaultLocation;
        }

        protected TestEnvironment TestEnvironment => TestEnvironmentFactory.GetTestEnvironment();

        protected static DeviceUpdateClient CreateDeviceUpdateClient(MockContext context)
        {
            DelegatingHandler handler = new RecordedDelegatingHandler
            {
                IsPassThrough = true,
                StatusCodeToReturn = HttpStatusCode.Created
            };
            return context.GetServiceClient<DeviceUpdateClient>(handlers: handler);
        }
    }
}