// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    // Backward-compat: baseline GetConfigurations returned Pageable<ServerConfigurationData>.
    // New generator returns Pageable<NodeConfigurationResource> because it resource-wraps the
    // paging result, even though this operation is an ARM Action (not a List).
    // This is potentially a generator bug: https://github.com/Azure/azure-sdk-for-net/issues/57110
    // If the bug is confirmed and fixed, this Customized file can be removed.
    [CodeGenSuppress("GetConfigurations", typeof(CancellationToken))]
    [CodeGenSuppress("GetConfigurationsAsync", typeof(CancellationToken))]
    public partial class CosmosDBForPostgreSqlClusterServerResource
    {
        /// <summary> List all the configurations of a server in cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<CosmosDBForPostgreSqlServerConfigurationData> GetConfigurations(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new ConfigurationsGetConfigurationsCollectionResultOfT(
                _configurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context);
        }

        /// <summary> List all the configurations of a server in cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<CosmosDBForPostgreSqlServerConfigurationData> GetConfigurationsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new ConfigurationsGetConfigurationsAsyncCollectionResultOfT(
                _configurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context);
        }
    }
}
