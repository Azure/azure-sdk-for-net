// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.Search;
    using Microsoft.Azure.Management.Search.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Sku = Management.Storage.Models.Sku;

    public class SharedPrivateLinkResourceFixture : ResourceGroupFixture
    {
        public string SharedPrivateLinkResourceName => $"pe-{StorageAccountName}";

        public string SharedPrivateLinkResourceGroupId => "blob";

        public string SharedPrivateLinkResourceRequestMessage => "Approve me";

        public string StorageAccountName { get; private set; }

        public string StorageAccountId { get; private set; }

        public string ServiceName { get; private set; }

        public MockContext MockContext { get; private set; }

        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            MockContext = context;

            ResourceManagementClient rmClient = context.GetServiceClient<ResourceManagementClient>();

            // Register subscription for storage and networking
            Provider provider = rmClient.Providers.Register("Microsoft.Storage");
            Assert.NotNull(provider);

            provider = rmClient.Providers.Register("Microsoft.Network");
            Assert.NotNull(provider);

            StorageAccountName = SearchTestUtilities.GenerateStorageAccountName();

            StorageManagementClient client = MockContext.GetServiceClient<StorageManagementClient>();

            StorageAccount account = client.StorageAccounts.Create(
                ResourceGroupName,
                StorageAccountName,
                new StorageAccountCreateParameters(
                    new Sku("Standard_LRS"),
                    kind: "StorageV2",
                    location: "centraluseuap"));

            Assert.NotNull(account);
            StorageAccountId = account.Id;

            SearchManagementClient searchMgmt = context.GetServiceClient<SearchManagementClient>();

            ServiceName = SearchTestUtilities.GenerateServiceName();
            SearchService service = DefineServiceWithSku(Management.Search.Models.SkuName.Basic);
            searchMgmt.Services.CreateOrUpdate(ResourceGroupName, ServiceName, service);
        }

        public override void Cleanup()
        {
            if (ResourceGroupName != null && StorageAccountName != null)
            {
                StorageManagementClient client = MockContext.GetServiceClient<StorageManagementClient>();
                client.StorageAccounts.Delete(ResourceGroupName, StorageAccountName);
            }

            if (ResourceGroupName != null && ServiceName != null)
            {
                SearchManagementClient searchMgmt = MockContext.GetServiceClient<SearchManagementClient>();
                searchMgmt.Services.Delete(ResourceGroupName, ServiceName);
            }

            base.Cleanup();
        }

        private SearchService DefineServiceWithSku(Management.Search.Models.SkuName sku)
        {
            return new SearchService()
            {
                Location = "CentralUSEUAP",
                Sku = new Management.Search.Models.Sku() { Name = sku },
                ReplicaCount = 1,
                PartitionCount = 1
            };
        }
    }
}