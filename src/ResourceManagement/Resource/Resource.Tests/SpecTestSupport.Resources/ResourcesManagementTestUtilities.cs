//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using ResourceGroups.Tests;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;

namespace Microsoft.Azure.Test
{


    public static class ResourcesManagementTestUtilities
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
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClientWithHandler(this TestBase testBase, MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A subscription client, created from the current context (environment variables)</returns>
        public static SubscriptionClient GetSubscriptionClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<SubscriptionClient>();
            return client;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A subscription client, created from the current context (environment variables)</returns>
        public static SubscriptionClient GetSubscriptionClientWithHandler(this TestBase testBase, MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<SubscriptionClient>(handlers: handler);
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
            string location = null;
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.ResourceTypes)
            {
                if (string.Equals(resource.ResourceType, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.LastOrDefault<string>();
                }
            }

            return location;
        }

        /// <summary>
        /// Equality comparison for locations returned by resource management
        /// </summary>
        /// <param name="expected">The expected location</param>
        /// <param name="actual">The actual location returned by resource management</param>
        /// <returns>true if the locations are equivalent, otherwise false</returns>
        public static bool LocationsAreEqual(string expected, string actual)
        {
            bool result = string.Equals(expected, actual, System.StringComparison.OrdinalIgnoreCase);
            if (!result && !string.IsNullOrEmpty(expected))
            {
                string normalizedLocation = expected.ToLower().Replace(" ", null);
                result = string.Equals(normalizedLocation, actual, StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }

    }
}
