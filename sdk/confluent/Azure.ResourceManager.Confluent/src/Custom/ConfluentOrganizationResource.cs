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
        /// Backward-compatible shim. Use <see cref="SCClusterRecordResource.CreateApiKey"/> on the cluster resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSCClusterRecord(clusterId).Value.CreateApiKey(content) instead.")]
        public virtual Response<ConfluentApiKeyRecord> CreateApiKey(string environmentId, string clusterId, ConfluentApiKeyCreateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));
            Argument.AssertNotNull(content, nameof(content));

            var resourceId = SCClusterRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId, clusterId);
            var resource = Client.GetSCClusterRecordResource(resourceId);
            return resource.CreateApiKey(content, cancellationToken);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="SCClusterRecordResource.CreateApiKeyAsync"/> on the cluster resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSCClusterRecord(clusterId).Value.CreateApiKey(content) instead.")]
        public virtual async Task<Response<ConfluentApiKeyRecord>> CreateApiKeyAsync(string environmentId, string clusterId, ConfluentApiKeyCreateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));
            Argument.AssertNotNull(content, nameof(content));

            var resourceId = SCClusterRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId, clusterId);
            var resource = Client.GetSCClusterRecordResource(resourceId);
            return await resource.CreateApiKeyAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetSCEnvironmentRecord"/> and then <see cref="SCEnvironmentRecordResource.GetSCClusterRecord"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSCClusterRecord(clusterId) instead.")]
        public virtual Response<SCClusterRecord> GetCluster(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));

            var resourceId = SCClusterRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId, clusterId);
            var resource = Client.GetSCClusterRecordResource(resourceId);
            var response = resource.Get(cancellationToken);
            return Response.FromValue(SCClusterRecord.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetSCEnvironmentRecordAsync"/> and then <see cref="SCEnvironmentRecordResource.GetSCClusterRecordAsync"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSCClusterRecord(clusterId) instead.")]
        public virtual async Task<Response<SCClusterRecord>> GetClusterAsync(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));

            var resourceId = SCClusterRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId, clusterId);
            var resource = Client.GetSCClusterRecordResource(resourceId);
            var response = await resource.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(SCClusterRecord.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="SCEnvironmentRecordResource.GetSCClusterRecords"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSCClusterRecords().GetAll() instead.")]
        public virtual Pageable<SCClusterRecord> GetClusters(string environmentId, int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var envResourceId = SCEnvironmentRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetSCEnvironmentRecordResource(envResourceId);
            var pageable = envResource.GetSCClusterRecords().GetAll(pageSize, pageToken, cancellationToken);
            return new MappedPageable<SCClusterRecordResource, SCClusterRecord>(pageable, r => SCClusterRecord.FromData(r.Data));
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="SCEnvironmentRecordResource.GetSCClusterRecords"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSCClusterRecords().GetAll() instead.")]
        public virtual AsyncPageable<SCClusterRecord> GetClustersAsync(string environmentId, int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var envResourceId = SCEnvironmentRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetSCEnvironmentRecordResource(envResourceId);
            var pageable = envResource.GetSCClusterRecords().GetAllAsync(pageSize, pageToken, cancellationToken);
            return new MappedAsyncPageable<SCClusterRecordResource, SCClusterRecord>(pageable, r => SCClusterRecord.FromData(r.Data));
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetSCEnvironmentRecord"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId) instead.")]
        public virtual Response<SCEnvironmentRecord> GetEnvironment(string environmentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var response = GetSCEnvironmentRecord(environmentId, cancellationToken);
            return Response.FromValue(SCEnvironmentRecord.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetSCEnvironmentRecordAsync"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId) instead.")]
        public virtual async Task<Response<SCEnvironmentRecord>> GetEnvironmentAsync(string environmentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var response = await GetSCEnvironmentRecordAsync(environmentId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(SCEnvironmentRecord.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetSCEnvironmentRecords"/> collection instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecords().GetAll() instead.")]
        public virtual Pageable<SCEnvironmentRecord> GetEnvironments(int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var pageable = GetSCEnvironmentRecords().GetAll(pageSize, pageToken, cancellationToken);
            return new MappedPageable<SCEnvironmentRecordResource, SCEnvironmentRecord>(pageable, r => SCEnvironmentRecord.FromData(r.Data));
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="GetSCEnvironmentRecords"/> collection instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecords().GetAll() instead.")]
        public virtual AsyncPageable<SCEnvironmentRecord> GetEnvironmentsAsync(int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var pageable = GetSCEnvironmentRecords().GetAllAsync(pageSize, pageToken, cancellationToken);
            return new MappedAsyncPageable<SCEnvironmentRecordResource, SCEnvironmentRecord>(pageable, r => SCEnvironmentRecord.FromData(r.Data));
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="SCEnvironmentRecordResource.GetSchemaRegistryCluster"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSchemaRegistryCluster(clusterId) instead.")]
        public virtual Response<SchemaRegistryClusterRecord> GetSchemaRegistryCluster(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));

            var envResourceId = SCEnvironmentRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetSCEnvironmentRecordResource(envResourceId);
            return envResource.GetSchemaRegistryCluster(clusterId, cancellationToken);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="SCEnvironmentRecordResource.GetSchemaRegistryClusterAsync"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSchemaRegistryCluster(clusterId) instead.")]
        public virtual async Task<Response<SchemaRegistryClusterRecord>> GetSchemaRegistryClusterAsync(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));
            Argument.AssertNotNullOrEmpty(clusterId, nameof(clusterId));

            var envResourceId = SCEnvironmentRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetSCEnvironmentRecordResource(envResourceId);
            return await envResource.GetSchemaRegistryClusterAsync(clusterId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="SCEnvironmentRecordResource.GetSchemaRegistryClusters"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSchemaRegistryClusters() instead.")]
        public virtual Pageable<SchemaRegistryClusterRecord> GetSchemaRegistryClusters(string environmentId, int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var envResourceId = SCEnvironmentRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetSCEnvironmentRecordResource(envResourceId);
            return envResource.GetSchemaRegistryClusters(pageSize, pageToken, cancellationToken);
        }

        /// <summary>
        /// Backward-compatible shim. Use <see cref="SCEnvironmentRecordResource.GetSchemaRegistryClustersAsync"/> on the environment resource instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetSCEnvironmentRecord(environmentId).Value.GetSchemaRegistryClusters() instead.")]
        public virtual AsyncPageable<SchemaRegistryClusterRecord> GetSchemaRegistryClustersAsync(string environmentId, int? pageSize = default, string pageToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(environmentId, nameof(environmentId));

            var envResourceId = SCEnvironmentRecordResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, environmentId);
            var envResource = Client.GetSCEnvironmentRecordResource(envResourceId);
            return envResource.GetSchemaRegistryClustersAsync(pageSize, pageToken, cancellationToken);
        }
    }
}
