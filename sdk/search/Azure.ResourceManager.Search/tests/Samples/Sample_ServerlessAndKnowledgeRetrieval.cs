// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Search.Models;

namespace Azure.ResourceManager.Search.Samples
{
    public partial class Sample_ServerlessAndKnowledgeRetrieval
    {
        /// <summary>
        /// Creates a billable serverless search service in an existing resource group.
        /// </summary>
        /// <remarks>
        /// Use an authenticated client, a supported region, and a globally unique service name.
        /// When the service is no longer needed, call <c>DeleteAsync(WaitUntil.Completed)</c>
        /// on the returned resource to avoid ongoing charges.
        /// </remarks>
        public async Task<SearchServiceResource> CreateServerlessAsync(
            ArmClient client,
            string subscriptionId,
            string resourceGroupName,
            string serviceName,
            AzureLocation location,
            CancellationToken cancellationToken = default)
        {
            ResourceIdentifier resourceGroupId =
                ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroup = client.GetResourceGroupResource(resourceGroupId);
            SearchServiceCollection services = resourceGroup.GetSearchServices();

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

            return service;
        }

        /// <summary>
        /// Configures knowledge-retrieval billing for an existing search service.
        /// </summary>
        /// <remarks>
        /// This setting requires a supported service tier and region.
        /// Choose <see cref="SearchKnowledgeRetrieval.Free"/> or <see cref="SearchKnowledgeRetrieval.Standard"/>
        /// for <paramref name="billingPlan"/>; Standard permits billable usage beyond the free quota.
        /// The current service is read first to preserve the location required by the update model.
        /// </remarks>
        public async Task<SearchServiceResource> ConfigureKnowledgeRetrievalAsync(
            SearchServiceResource service,
            SearchKnowledgeRetrieval billingPlan,
            CancellationToken cancellationToken = default)
        {
            Response<SearchServiceResource> current = await service.GetAsync(
                cancellationToken: cancellationToken);
            SearchServicePatch patch = new SearchServicePatch(current.Value.Data.Location)
            {
                KnowledgeRetrieval = billingPlan
            };

            Response<SearchServiceResource> response = await service.UpdateAsync(
                patch,
                cancellationToken: cancellationToken);
            SearchServiceResource updatedService = response.Value;

            return updatedService;
        }

        /// <summary>
        /// Reads serverless quota usage for a subscription and region without provisioning a resource.
        /// </summary>
        /// <remarks>
        /// Use an authenticated client and a region that supports the serverless SKU.
        /// </remarks>
        public async Task<QuotaUsageResult> GetServerlessQuotaAsync(
            ArmClient client,
            string subscriptionId,
            AzureLocation location,
            CancellationToken cancellationToken = default)
        {
            ResourceIdentifier subscriptionResourceId =
                SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscription = client.GetSubscriptionResource(subscriptionResourceId);

            Response<QuotaUsageResult> response = await subscription.UsageBySubscriptionSkuAsync(
                location,
                SearchServiceSkuName.Serverless.ToString(),
                cancellationToken: cancellationToken);
            QuotaUsageResult quota = response.Value;

            return quota;
        }
    }
}
