// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Search.Models;

namespace Azure.ResourceManager.Search.Samples
{
    public partial class Sample_Serverless
    {
        /// <summary>
        /// Creates a serverless search service, reads its properties, and deletes the service.
        /// </summary>
        /// <remarks>
        /// Use an existing resource group, a supported region, and a new, globally unique service name.
        /// The authenticated identity must be allowed to create, read, and delete search services.
        /// Serverless usage is billable. This example deletes the service after reading it.
        /// If creation fails after provisioning has started, check for and remove any partially created service.
        /// </remarks>
        public async Task CreateReadAndDeleteAsync(
            string subscriptionId,
            string resourceGroupName,
            string serviceName,
            AzureLocation location,
            CancellationToken cancellationToken = default)
        {
            TokenCredential credential = new DefaultAzureCredential();
            ArmClient client = new ArmClient(credential);
            ResourceIdentifier resourceGroupId =
                ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroup = client.GetResourceGroupResource(resourceGroupId);
            SearchServiceCollection services = resourceGroup.GetSearchServices();

            // Replica and partition counts do not apply to serverless and must be omitted.
            SearchServiceData data = new SearchServiceData(location)
            {
                SearchSkuName = SearchServiceSkuName.Serverless
            };
            ArmOperation<SearchServiceResource> operation = await services.CreateOrUpdateAsync(
                WaitUntil.Completed,
                serviceName,
                data,
                cancellationToken: cancellationToken);
            SearchServiceResource service = operation.Value;

            try
            {
                Response<SearchServiceResource> response = await service.GetAsync(
                    cancellationToken: cancellationToken);
                SearchServiceData current = response.Value.Data;
                Console.WriteLine($"Service: {current.Id}");
                Console.WriteLine($"SKU: {current.SearchSkuName}");
                Console.WriteLine($"Endpoint: {current.Endpoint}");
            }
            finally
            {
                // Do not skip cleanup if the caller cancels the read.
                await service.DeleteAsync(WaitUntil.Completed, cancellationToken: CancellationToken.None);
            }
        }

        /// <summary>
        /// Reads and displays serverless quota usage without provisioning a search service.
        /// </summary>
        /// <remarks>
        /// Use a region that supports the serverless SKU and an identity allowed to read subscription quotas.
        /// Quota is scoped to the subscription, region, and SKU; it is not a particular service's usage.
        /// </remarks>
        public async Task<QuotaUsageResult> GetQuotaAsync(
            string subscriptionId,
            AzureLocation location,
            CancellationToken cancellationToken = default)
        {
            TokenCredential credential = new DefaultAzureCredential();
            ArmClient client = new ArmClient(credential);
            ResourceIdentifier subscriptionResourceId =
                SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscription = client.GetSubscriptionResource(subscriptionResourceId);

            Response<QuotaUsageResult> response = await subscription.UsageBySubscriptionSkuAsync(
                location,
                SearchServiceSkuName.Serverless.ToString(),
                cancellationToken: cancellationToken);
            QuotaUsageResult quota = response.Value;
            Console.WriteLine($"Serverless quota in {location}:");
            Console.WriteLine($"Current usage: {quota.CurrentValue}; limit: {quota.Limit}; unit: {quota.Unit}");

            return quota;
        }
    }
}
