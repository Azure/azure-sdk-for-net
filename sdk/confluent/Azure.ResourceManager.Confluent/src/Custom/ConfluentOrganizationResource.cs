// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Confluent.Models;

namespace Azure.ResourceManager.Confluent
{
    public partial class ConfluentOrganizationResource
    {
        /// <summary>
        /// Backward-compatible shim. Use <see cref="ConfluentClusterResource.CreateApiKey"/> on the cluster resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetConfluentCluster(clusterId).Value.CreateApiKey(content) instead.")]
        public virtual Response<ConfluentApiKeyRecord> CreateApiKey(string environmentId, string clusterId, ConfluentApiKeyCreateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));
            Argument.AssertNotNull(content, nameof(content));

            var resourceId = ConfluentClusterResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId, clusterId);
            var resource = Client.GetConfluentClusterResource(resourceId);
            return resource.CreateApiKey(content, cancellationToken);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="ConfluentClusterResource.CreateApiKeyAsync"/> on the cluster resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetConfluentCluster(clusterId).Value.CreateApiKey(content) instead.")]
        public virtual async Task<Response<ConfluentApiKeyRecord>> CreateApiKeyAsync(string environmentId, string clusterId, ConfluentApiKeyCreateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));
            Argument.AssertNotNull(content, nameof(content));

            var resourceId = ConfluentClusterResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId, clusterId);
            var resource = Client.GetConfluentClusterResource(resourceId);
            return await resource.CreateApiKeyAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetConfluentEnvironment"/> and then <see cref="ConfluentEnvironmentResource.GetConfluentCluster"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetConfluentCluster(clusterId) instead.")]
        public virtual Response<SCClusterRecord> GetCluster(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));

            var resourceId = ConfluentClusterResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId, clusterId);
            var resource = Client.GetConfluentClusterResource(resourceId);
            var response = resource.Get(cancellationToken);
            return Response.FromValue(SCClusterRecord.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetConfluentEnvironmentAsync"/> and then <see cref="ConfluentEnvironmentResource.GetConfluentClusterAsync"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetConfluentCluster(clusterId) instead.")]
        public virtual async Task<Response<SCClusterRecord>> GetClusterAsync(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));

            var resourceId = ConfluentClusterResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId, clusterId);
            var resource = Client.GetConfluentClusterResource(resourceId);
            var response = await resource.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(SCClusterRecord.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="ConfluentEnvironmentResource.GetConfluentClusters"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetConfluentClusters().GetAll() instead.")]
        public virtual Pageable<SCClusterRecord> GetClusters(string environmentId, int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var envResourceId = ConfluentEnvironmentResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetConfluentEnvironmentResource(envResourceId);
            var pageable = envResource.GetConfluentClusters().GetAll(pageSize, pageToken, cancellationToken);
            return new MappedPageable<ConfluentClusterResource, SCClusterRecord>(pageable, r => SCClusterRecord.FromData(r.Data));
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="ConfluentEnvironmentResource.GetConfluentClusters"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetConfluentClusters().GetAll() instead.")]
        public virtual AsyncPageable<SCClusterRecord> GetClustersAsync(string environmentId, int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var envResourceId = ConfluentEnvironmentResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetConfluentEnvironmentResource(envResourceId);
            var pageable = envResource.GetConfluentClusters().GetAllAsync(pageSize, pageToken, cancellationToken);
            return new MappedAsyncPageable<ConfluentClusterResource, SCClusterRecord>(pageable, r => SCClusterRecord.FromData(r.Data));
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetConfluentEnvironment"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId) instead.")]
        public virtual Response<SCEnvironmentRecord> GetEnvironment(string environmentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var response = GetConfluentEnvironment(environmentId, cancellationToken);
            return Response.FromValue(SCEnvironmentRecord.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetConfluentEnvironmentAsync"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId) instead.")]
        public virtual async Task<Response<SCEnvironmentRecord>> GetEnvironmentAsync(string environmentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var response = await GetConfluentEnvironmentAsync(environmentId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(SCEnvironmentRecord.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetConfluentEnvironments"/> collection instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironments().GetAll() instead.")]
        public virtual Pageable<SCEnvironmentRecord> GetEnvironments(int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var pageable = GetConfluentEnvironments().GetAll(pageSize, pageToken, cancellationToken);
            return new MappedPageable<ConfluentEnvironmentResource, SCEnvironmentRecord>(pageable, r => SCEnvironmentRecord.FromData(r.Data));
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetConfluentEnvironments"/> collection instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironments().GetAll() instead.")]
        public virtual AsyncPageable<SCEnvironmentRecord> GetEnvironmentsAsync(int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var pageable = GetConfluentEnvironments().GetAllAsync(pageSize, pageToken, cancellationToken);
            return new MappedAsyncPageable<ConfluentEnvironmentResource, SCEnvironmentRecord>(pageable, r => SCEnvironmentRecord.FromData(r.Data));
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="ConfluentEnvironmentResource.GetSchemaRegistryCluster"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetSchemaRegistryCluster(clusterId) instead.")]
        public virtual Response<SchemaRegistryClusterRecord> GetSchemaRegistryCluster(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));

            var envResourceId = ConfluentEnvironmentResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetConfluentEnvironmentResource(envResourceId);
            return envResource.GetSchemaRegistryCluster(clusterId, cancellationToken);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="ConfluentEnvironmentResource.GetSchemaRegistryClusterAsync"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetSchemaRegistryCluster(clusterId) instead.")]
        public virtual async Task<Response<SchemaRegistryClusterRecord>> GetSchemaRegistryClusterAsync(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));

            var envResourceId = ConfluentEnvironmentResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetConfluentEnvironmentResource(envResourceId);
            return await envResource.GetSchemaRegistryClusterAsync(clusterId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="ConfluentEnvironmentResource.GetSchemaRegistryClusters"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetSchemaRegistryClusters() instead.")]
        public virtual Pageable<SchemaRegistryClusterRecord> GetSchemaRegistryClusters(string environmentId, int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var envResourceId = ConfluentEnvironmentResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetConfluentEnvironmentResource(envResourceId);
            return envResource.GetSchemaRegistryClusters(pageSize, pageToken, cancellationToken);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="ConfluentEnvironmentResource.GetSchemaRegistryClustersAsync"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetConfluentEnvironment(environmentId).Value.GetSchemaRegistryClusters() instead.")]
        public virtual AsyncPageable<SchemaRegistryClusterRecord> GetSchemaRegistryClustersAsync(string environmentId, int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var envResourceId = ConfluentEnvironmentResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetConfluentEnvironmentResource(envResourceId);
            return envResource.GetSchemaRegistryClustersAsync(pageSize, pageToken, cancellationToken);
        }
    }
}
