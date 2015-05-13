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

using Microsoft.Azure.Subscriptions;
using ResourceGroups.Tests;

namespace Microsoft.Azure.Test
{
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using System;
    using System.Linq;

    public static class ResourcesManagementTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClientWithHandler(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A subscription client, created from the current context (environment variables)</returns>
        public static SubscriptionClient GetSubscriptionClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<SubscriptionClient>(new CSMTestEnvironmentFactory());
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
            foreach (var resource in provider.Provider.ResourceTypes)
            {
                if (string.Equals(resource.Name, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.LastOrDefault<string>();
                }
            }

            return location;
        }

        /// <summary>
        /// Equality comparison for locatiosn returned by resource management
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
