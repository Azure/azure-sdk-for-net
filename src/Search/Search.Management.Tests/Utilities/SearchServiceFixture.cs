// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using Microsoft.Azure.Management.Search;
    using Microsoft.Azure.Management.Search.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class SearchServiceFixture : ResourceGroupFixture
    {
        public string SearchServiceName { get; private set; }

        public string PrimaryApiKey { get; private set; }

        public string QueryApiKey { get; private set; }

        public MockContext MockContext { get; private set; }

        public override void Initialize(MockContext context)
        {
            base.Initialize(context);
            
            MockContext = context;

            SearchManagementClient client = context.GetServiceClient<SearchManagementClient>();

            SearchServiceName = EnsureSearchService(client);

            AdminKeyResult adminKeyResult = client.AdminKeys.List(ResourceGroupName, SearchServiceName);
            Assert.NotNull(adminKeyResult);

            PrimaryApiKey = adminKeyResult.PrimaryKey;

            ListQueryKeysResult queryKeyResult = client.QueryKeys.List(ResourceGroupName, SearchServiceName);
            Assert.NotNull(queryKeyResult);
            Assert.Equal(1, queryKeyResult.Value.Count);

            QueryApiKey = queryKeyResult.Value[0].Key;
        }

        public override void Cleanup()
        {
            // Normally we could just rely on resource group deletion to clean things up for us. However, resource
            // group deletion is asynchronous and can be slow, especially when we're running in test environments that
            // aren't 100% reliable. To avoid interfering with other tests by exhausting free service quota, we
            // eagerly delete the search service here.
            if (ResourceGroupName != null && SearchServiceName != null)
            {
                SearchManagementClient client = MockContext.GetServiceClient<SearchManagementClient>();
                client.Services.Delete(ResourceGroupName, SearchServiceName);
            }

            base.Cleanup();
        }

        private string EnsureSearchService(SearchManagementClient client)
        {
            // Ensuring a search service involves creating it, and then waiting until its DNS resolves. The approach
            // we take depends on what kind of test run this is. If it's a Record or Playback run, we need determinism
            // since the mock server has no clue how many times we retried DNS lookup in the original test run. In
            // this case, we can't just delete and re-create the search service if DNS doesn't resolve in a timely
            // manner. However, we do fail fast in the interests of speeding up interactive dev cycles.
            //
            // If we're in None mode (i.e. -- no mock recording or playback), we assume we're running automated tests
            // in batch. In this case, non-determinism is not a problem (because mocks aren't involved), and
            // reliability is paramount. For this reason, we retry the entire sequence several times, deleting and
            // trying to re-create the service each time.
            int maxAttempts = (HttpMockServer.Mode == HttpRecorderMode.None) ? 10 : 1;

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                string searchServiceName = SearchTestUtilities.GenerateServiceName();

                var createServiceParameters =
                    new SearchServiceCreateOrUpdateParameters()
                    {
                        Location = Location,
                        Properties = new SearchServiceProperties() { Sku = new Sku() { Name = SkuType.Free } }
                    };

                client.Services.CreateOrUpdate(ResourceGroupName, searchServiceName, createServiceParameters);

                // In the common case, DNS propagation happens in less than 15 seconds. In the uncommon case, it can
                // take many minutes. The timeout we use depends on the mock mode. If we're in Playback, the delay is
                // irrelevant. If we're in Record mode, we can't delete and re-create the service, so we get more
                // reliable results if we wait longer. In "None" mode, we can delete and re-create, which is often
                // faster than waiting a long time for DNS propagation. In that case, rather than force all tests to
                // wait several minutes, we fail fast here.
                TimeSpan maxDelay = 
                    (HttpMockServer.Mode == HttpRecorderMode.Record) ? 
                        TimeSpan.FromMinutes(1) : TimeSpan.FromSeconds(15);
                
                if (SearchTestUtilities.WaitForSearchServiceDns(searchServiceName, maxDelay))
                {
                    return searchServiceName;
                }

                // If the service DNS isn't resolvable in a timely manner, delete it and try to create another one.
                // We need to delete it since there can be only one free service per subscription.
                client.Services.Delete(ResourceGroupName, searchServiceName);
            }

            throw new InvalidOperationException("Failed to provision a search service in a timely manner.");
        }
    }
}
