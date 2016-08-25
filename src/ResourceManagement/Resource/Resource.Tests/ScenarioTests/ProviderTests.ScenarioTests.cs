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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace ResourceGroups.Tests
{
    public class LiveProviderTests : TestBase
    {
        private const string ProviderName = "microsoft.insights";
        public ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClientWithHandler(context, handler);
        }

        [Fact]
        public void ProviderGetValidateMessage()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

                var client = GetResourceManagementClient(context, handler);

                var reg = client.Providers.Register(ProviderName);
                Assert.NotNull(reg);

                var result = client.Providers.Get(ProviderName);

                // Validate headers
                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

                // Validate result
                Assert.NotNull(result);
                Assert.NotEmpty(result.Id);
                Assert.Equal(ProviderName, result.NamespaceProperty);
                Assert.True("Registered" == result.RegistrationState ||
                    "Registering" == result.RegistrationState,
                    string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", result.RegistrationState));
                Assert.NotEmpty(result.ResourceTypes);
                Assert.NotEmpty(result.ResourceTypes[0].Locations);
            }
        }

        [Fact]
        public void ProviderListValidateMessage()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

                var client = GetResourceManagementClient(context, handler);

                var reg = client.Providers.Register(ProviderName);
                Assert.NotNull(reg);

                var result = client.Providers.List(null);

                // Validate headers
                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

                // Validate result
                Assert.True(result.Any());
                var websiteProvider =
                    result.First(
                        p => p.NamespaceProperty.Equals(ProviderName, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(ProviderName, websiteProvider.NamespaceProperty);
                Assert.True("Registered" == websiteProvider.RegistrationState ||
                    "Registering" == websiteProvider.RegistrationState,
                    string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", websiteProvider.RegistrationState));
                Assert.NotEmpty(websiteProvider.ResourceTypes);
                Assert.NotEmpty(websiteProvider.ResourceTypes[0].Locations);
            }
        }

        [Fact]
        public void GetProviderWithAliases()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var computeNamespace = "Microsoft.Compute";
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

                var client = GetResourceManagementClient(context, handler);

                var reg = client.Providers.Register(computeNamespace);
                Assert.NotNull(reg);

                var result = client.Providers.List(expand: "resourceTypes/aliases");

                // Validate headers
                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

                // Validate result
                Assert.True(result.Any());
                var computeProvider = result.First(
                    provider => string.Equals(provider.NamespaceProperty, computeNamespace, StringComparison.OrdinalIgnoreCase));

                Assert.NotEmpty(computeProvider.ResourceTypes);
                var virtualMachinesType = computeProvider.ResourceTypes.First(
                    resourceType => string.Equals(resourceType.ResourceType, "virtualMachines", StringComparison.OrdinalIgnoreCase));

                Assert.NotEmpty(virtualMachinesType.Aliases);
                Assert.Equal("Microsoft.Compute/virtualMachines/sku.name", virtualMachinesType.Aliases[0].Name);
                Assert.Equal("properties.hardwareProfile.vmSize", virtualMachinesType.Aliases[0].Paths[0].Path);

                computeProvider = client.Providers.Get(resourceProviderNamespace: computeNamespace, expand: "resourceTypes/aliases");

                Assert.NotEmpty(computeProvider.ResourceTypes);
                virtualMachinesType = computeProvider.ResourceTypes.First(
                    resourceType => string.Equals(resourceType.ResourceType, "virtualMachines", StringComparison.OrdinalIgnoreCase));

                Assert.NotEmpty(virtualMachinesType.Aliases);
                Assert.Equal("Microsoft.Compute/virtualMachines/sku.name", virtualMachinesType.Aliases[0].Name);
                Assert.Equal("properties.hardwareProfile.vmSize", virtualMachinesType.Aliases[0].Paths[0].Path);
            }
        }

        [Fact]
        public void VerifyProviderRegister()
        {
            var handler = new RecordedDelegatingHandler() {StatusCodeToReturn = HttpStatusCode.OK};
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetResourceManagementClient(context, handler);

                client.Providers.Register(ProviderName);

                var provider = client.Providers.Get(ProviderName);
                Assert.True(provider.RegistrationState == "Registered" ||
                            provider.RegistrationState == "Registering");
            }
        }

        [Fact]
        public void VerifyProviderUnregister()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetResourceManagementClient(context, handler);

                var registerResult = client.Providers.Register(ProviderName);

                var provider = client.Providers.Get(ProviderName);
                Assert.True(provider.RegistrationState == "Registered" ||
                            provider.RegistrationState == "Registering");

                var unregisterResult = client.Providers.Unregister(ProviderName);

                provider = client.Providers.Get(ProviderName);
                Assert.True(provider.RegistrationState == "NotRegistered" ||
                            provider.RegistrationState == "Unregistering",
                            "RegistrationState is expected NotRegistered or Unregistering. Actual value " +
                            provider.RegistrationState);
            }
        }
    }
}
