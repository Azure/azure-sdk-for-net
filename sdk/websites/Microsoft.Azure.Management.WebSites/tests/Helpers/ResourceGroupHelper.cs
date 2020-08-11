﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace WebSites.Tests.Helpers
{
    public static class ResourceGroupHelper
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            return client;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static WebSiteManagementClient GetWebSiteManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<WebSiteManagementClient>();
            return client;
        }

        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(ResourceManagementClient client, string resourceType)
        {
            var supportedLocations = new HashSet<string>(new[] { "East Asia", "West US", "North Central US", "North Europe", "West Europe", "South Central US", "East US" }, StringComparer.OrdinalIgnoreCase);

            string location = null;
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.ResourceTypes)
            {
                if (string.Equals(resource.ResourceType, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.FirstOrDefault(supportedLocations.Contains);
                }
            }

            return location;
        }

        public static string GetServerFarmId(string subscription, string resourceGroup, string serverFarm)
        {
            var serverFarmIdFormat = "/subscriptions/{0}/resourcegroups/{1}/providers/Microsoft.Web/serverfarms/{2}";

            return string.Format(serverFarmIdFormat, subscription, resourceGroup, serverFarm);
        }
    }
}
