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
    public partial class Sample_KnowledgeRetrievalBilling
    {
        /// <summary>
        /// Creates a Standard-SKU service with Free knowledge-retrieval billing, reads the plan, and deletes the service.
        /// </summary>
        /// <remarks>
        /// Use an existing resource group, a supported region, and a new, globally unique service name.
        /// The authenticated identity must be allowed to create, read, and delete search services.
        /// A Free knowledge-retrieval plan does not make the Standard-SKU service free; hosting remains billable.
        /// This example deletes the service after reading it. If creation fails after provisioning has started,
        /// check for and remove any partially created service.
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

            SearchServiceData data = new SearchServiceData(location)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                ReplicaCount = 1,
                PartitionCount = 1,
                KnowledgeRetrieval = SearchKnowledgeRetrieval.Free
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
                Console.WriteLine($"Service: {response.Value.Id}");
                Console.WriteLine($"Knowledge-retrieval billing: {response.Value.Data.KnowledgeRetrieval}");
            }
            finally
            {
                // Do not skip cleanup if the caller cancels the read.
                await service.DeleteAsync(WaitUntil.Completed, cancellationToken: CancellationToken.None);
            }
        }

        /// <summary>
        /// Enables Standard knowledge-retrieval billing on an existing service and reads back the plan.
        /// </summary>
        /// <remarks>
        /// Requires a supported region and service tier using non-confidential compute, and an identity
        /// allowed to read and update the service. Standard knowledge retrieval is not supported on the Free service SKU.
        /// Standard permits billable knowledge-retrieval usage beyond the free quota. This example leaves
        /// the existing service on Standard billing; use <see cref="ConfigureFreeBillingAsync"/> to switch to Free.
        /// </remarks>
        public async Task<SearchServiceResource> ConfigureStandardBillingAsync(
            string subscriptionId,
            string resourceGroupName,
            string serviceName,
            CancellationToken cancellationToken = default)
        {
            TokenCredential credential = new DefaultAzureCredential();
            ArmClient client = new ArmClient(credential);
            ResourceIdentifier serviceId =
                SearchServiceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName);
            SearchServiceResource service = client.GetSearchServiceResource(serviceId);
            Response<SearchServiceResource> current = await service.GetAsync(
                cancellationToken: cancellationToken);

            // The update model requires a location, even for a billing-only change.
            SearchServicePatch patch = new SearchServicePatch(current.Value.Data.Location)
            {
                KnowledgeRetrieval = SearchKnowledgeRetrieval.Standard
            };
            await service.UpdateAsync(patch, cancellationToken: cancellationToken);

            Response<SearchServiceResource> response = await service.GetAsync(
                cancellationToken: cancellationToken);
            Console.WriteLine($"Knowledge-retrieval billing: {response.Value.Data.KnowledgeRetrieval}");

            return response.Value;
        }

        /// <summary>
        /// Selects Free knowledge-retrieval billing on an existing service and reads back the plan.
        /// </summary>
        /// <remarks>
        /// Requires a supported region and service tier, and an identity allowed to read and update the service.
        /// Free caps knowledge-retrieval usage at the free-plan limits. It does not change the service SKU
        /// or eliminate hosting charges. This example leaves the existing service on Free billing and does not delete it.
        /// </remarks>
        public async Task<SearchServiceResource> ConfigureFreeBillingAsync(
            string subscriptionId,
            string resourceGroupName,
            string serviceName,
            CancellationToken cancellationToken = default)
        {
            TokenCredential credential = new DefaultAzureCredential();
            ArmClient client = new ArmClient(credential);
            ResourceIdentifier serviceId =
                SearchServiceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName);
            SearchServiceResource service = client.GetSearchServiceResource(serviceId);
            Response<SearchServiceResource> current = await service.GetAsync(
                cancellationToken: cancellationToken);

            SearchServicePatch patch = new SearchServicePatch(current.Value.Data.Location)
            {
                KnowledgeRetrieval = SearchKnowledgeRetrieval.Free
            };
            await service.UpdateAsync(patch, cancellationToken: cancellationToken);

            Response<SearchServiceResource> response = await service.GetAsync(
                cancellationToken: cancellationToken);
            Console.WriteLine($"Knowledge-retrieval billing: {response.Value.Data.KnowledgeRetrieval}");

            return response.Value;
        }
    }
}
