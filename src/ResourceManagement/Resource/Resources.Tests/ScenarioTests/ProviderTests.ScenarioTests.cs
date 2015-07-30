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
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Xunit;
using System.Net.Http;
using System.Net;
using Microsoft.Azure.Test;
using System.Threading;

namespace ResourceGroups.Tests
{
    public class LiveProviderTests : TestBase
    {
        private const string ProviderName = "microsoft.insights";
        private const string NetworkProvider = "Microsoft.Network";
        private const string SqlProvider = "Microsoft.Sql";

        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClient().WithHandler(handler);
        }

        [Fact]
        public void ProviderGetValidateMessage()
        {
            TestUtilities.StartTest();
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var reg = client.Providers.Register(ProviderName);
            Assert.NotNull(reg);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, reg.StatusCode);

            var result = client.Providers.Get(ProviderName);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.NotNull(result);
            Assert.NotEmpty(result.Provider.Id);
            Assert.Equal(ProviderName, result.Provider.Namespace);
            Assert.True(ProviderRegistrationState.Registered == result.Provider.RegistrationState ||
                ProviderRegistrationState.Registering == result.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", result.Provider.RegistrationState));
            Assert.NotEmpty(result.Provider.ResourceTypes);
            Assert.NotEmpty(result.Provider.ResourceTypes[0].Locations);
            TestUtilities.EndTest();
        }

        [Fact]
        public void ProviderListValidateMessage()
        {
            TestUtilities.StartTest();
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var reg = client.Providers.Register(ProviderName);
            Assert.NotNull(reg);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, reg.StatusCode);

            var result = client.Providers.List(null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.True(result.Providers.Any());
            var websiteProvider =
                result.Providers.First(
                    p => p.Namespace.Equals(ProviderName, StringComparison.InvariantCultureIgnoreCase));
            Assert.Equal(ProviderName, websiteProvider.Namespace);
            Assert.True(ProviderRegistrationState.Registered == websiteProvider.RegistrationState ||
                ProviderRegistrationState.Registering == websiteProvider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", websiteProvider.RegistrationState));
            Assert.NotEmpty(websiteProvider.ResourceTypes);
            Assert.NotEmpty(websiteProvider.ResourceTypes[0].Locations);
            TestUtilities.EndTest();
        }

        [Fact]
        public void VerifyProviderRegister()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);

                AzureOperationResponse result = client.Providers.Register(ProviderName);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);

                ProviderGetResult provider = client.Providers.Get(ProviderName);
                Assert.True(provider.Provider.RegistrationState == ProviderRegistrationState.Registered ||
                            provider.Provider.RegistrationState == ProviderRegistrationState.Registering);
            }
        }

        [Fact]
        public void VerifyProviderUnregister()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);

                AzureOperationResponse registerResult = client.Providers.Register(ProviderName);

                Assert.Equal(HttpStatusCode.OK, registerResult.StatusCode);

                ProviderGetResult provider = client.Providers.Get(ProviderName);
                Assert.True(provider.Provider.RegistrationState == ProviderRegistrationState.Registered ||
                            provider.Provider.RegistrationState == ProviderRegistrationState.Registering);

                AzureOperationResponse unregisterResult = client.Providers.Unregister(ProviderName);

                Assert.Equal(HttpStatusCode.OK, unregisterResult.StatusCode);

                provider = client.Providers.Get(ProviderName);
                Assert.True(provider.Provider.RegistrationState == ProviderRegistrationState.NotRegistered ||
                            provider.Provider.RegistrationState == ProviderRegistrationState.Unregistering,
                            "RegistrationState is expected NotRegistered or Unregistering. Actual value " +
                            provider.Provider.RegistrationState);
            }
        }

        [Fact]
        public void ProviderOperationsList()
        {
            TestUtilities.StartTest();
            const string DefaultApiVersion = "2014-06-01";

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);
            var insightsProvider = client.Providers.Get(ProviderName);

            // Validate result
            Assert.True(insightsProvider != null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.NotEmpty(insightsProvider.Provider.ResourceTypes);
            var operationResourceType = insightsProvider.Provider.ResourceTypes.Single(x => x.Name == "operations");
            IList<string> operationsSupportedApiVersions = operationResourceType.ApiVersions;
            string latestSupportedApiVersion = DefaultApiVersion;
            
            if (operationsSupportedApiVersions != null && operationsSupportedApiVersions.Any())
            {
                latestSupportedApiVersion = operationsSupportedApiVersions.First();
            }

            ResourceIdentity identity = new ResourceIdentity
            {
                ResourceName = string.Empty,
                ResourceType = "operations",
                ResourceProviderNamespace = ProviderName,
                ResourceProviderApiVersion = latestSupportedApiVersion
            };

            var operations = client.ResourceProviderOperationDetails.List(identity);

            Assert.NotNull(operations);
            Assert.NotEmpty(operations.ResourceProviderOperationDetails);
            Assert.NotEmpty(operations.ResourceProviderOperationDetails[0].Name);
            Assert.NotNull(operations.ResourceProviderOperationDetails[0].ResourceProviderOperationDisplayProperties);
            IEnumerable<ResourceProviderOperationDefinition> definitions =
                operations.ResourceProviderOperationDetails.Where(op => string.Equals(op.Name, "Microsoft.Insights/AlertRules/Write", StringComparison.InvariantCultureIgnoreCase));
            Assert.NotNull(definitions);
            Assert.NotEmpty(definitions);
            Assert.Equal(1, definitions.Count());

            // Negative case with unsupported api version
            identity = new ResourceIdentity
            {
                ResourceName = string.Empty,
                ResourceType = "operations",
                ResourceProviderNamespace = ProviderName,
                ResourceProviderApiVersion = "2015-01-01"
            };

            Assert.Throws<Hyak.Common.CloudException>(() => client.ResourceProviderOperationDetails.List(identity));
            TestUtilities.EndTest();
        }

        [Fact]
        public void ProviderOperationsMetadataGetById()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var client = GetResourceManagementClient(handler);

                var providerOperationsMetadata = client.ProviderOperationsMetadata.Get(NetworkProvider);

                Assert.NotNull(providerOperationsMetadata);
                ValidateNetworkProviderOperations(providerOperationsMetadata.Provider);
            }
        }

        [Fact]
        public void ProviderOperationsMetadataGetAll()
        {
           
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var client = GetResourceManagementClient(handler);

                var providers = client.ProviderOperationsMetadata.List();

                // check for Microsoft.Network provider
                ProviderOperationsMetadata network = providers.Providers.FirstOrDefault(p => p.Name.Equals(NetworkProvider, StringComparison.OrdinalIgnoreCase));
                ValidateNetworkProviderOperations(network);

                ProviderOperationsMetadata sql = providers.Providers.FirstOrDefault(p => p.Name.Equals(SqlProvider, StringComparison.OrdinalIgnoreCase));
                ValidateSqlProviderOperations(sql);
            }        
        }

        private static void ValidateSqlProviderOperations(ProviderOperationsMetadata provider)
        {
            Assert.NotNull(provider);

            ResourceType resourceType = provider.ResourceTypes.FirstOrDefault(rt => rt.Name.Equals("servers"));
            Assert.NotNull(resourceType);

            Operation op = resourceType.Operations.FirstOrDefault(p => p.Name.Equals("Microsoft.Sql/servers/write"));
            Assert.NotNull(op);

            Assert.Null(op.Origin);
            Assert.Null(op.Properties);
        }

        private static void ValidateNetworkProviderOperations(ProviderOperationsMetadata provider)
        {
            Assert.NotNull(provider);

            // check for expected Resourcetype
            ResourceType resourceType = provider.ResourceTypes.FirstOrDefault(rt => rt.Name.Equals("networksecuritygroups/providers/Microsoft.Insights/logDefinitions"));
            Assert.NotNull(resourceType);

            Operation op = resourceType.Operations.FirstOrDefault(p => p.Name.Equals("Microsoft.Network/networksecuritygroups/providers/Microsoft.Insights/logDefinitions/read"));
            Assert.NotNull(op);

            Assert.Equal<string>("system", op.Origin);

            Assert.True(op.Properties != null && op.Properties.ToString().Contains("serviceSpecification"));
        }
    }
}
