// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.Search.Models;

namespace Azure.Provisioning.Search.Tests
{
    public class SearchTests : ProvisioningTestBase
    {
        public SearchTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SearchResources()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var search = new SearchService(infrastructure, sku: SearchSkuName.Standard);
            search.AssignRole(RoleDefinition.SearchServiceContributor, Guid.Empty);
            search.AssignRole(RoleDefinition.SearchIndexDataContributor, Guid.Empty);
            search.AssignProperty(data => data.ReplicaCount, "1");
            search.AssignProperty(data => data.PartitionCount, "1");
            search.AssignProperty(data => data.HostingMode, "'default'");
            search.AssignProperty(data => data.IsLocalAuthDisabled, "true");

            search.AddOutput("connectionString", "'Endpoint=https://${{{0}}}.search.windows.net'", data => data.Name);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingSearchResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            infra.AddResource(SearchService.FromExisting(infra, "'existingSearchService'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
