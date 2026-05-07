// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    /// <summary>
    /// A class representing a SiteRecoveryClusterRecoveryPoint along with the instance operations that can be performed on it.
    /// </summary>
    public partial class SiteRecoveryClusterRecoveryPointResource : ArmResource, IJsonModel<SiteRecoveryClusterRecoveryPointData>
    {
        private readonly ClientDiagnostics _clusterRecoveryPointClientDiagnostics;
        private readonly ClusterRecoveryPoint _clusterRecoveryPointRestClient;
        private readonly SiteRecoveryClusterRecoveryPointData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationProtectionClusters/recoveryPoints";

        /// <summary> Initializes a new instance of SiteRecoveryClusterRecoveryPointResource for mocking. </summary>
        protected SiteRecoveryClusterRecoveryPointResource()
        {
        }

        internal SiteRecoveryClusterRecoveryPointResource(ArmClient client, SiteRecoveryClusterRecoveryPointData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        internal SiteRecoveryClusterRecoveryPointResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string apiVersion);
            _clusterRecoveryPointClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.RecoveryServicesSiteRecovery", ResourceType.Namespace, Diagnostics);
            _clusterRecoveryPointRestClient = new ClusterRecoveryPoint(_clusterRecoveryPointClientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2026-01-01");
            ValidateResourceId(id);
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Resource. </summary>
        public virtual SiteRecoveryClusterRecoveryPointData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }
                return _data;
            }
        }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string replicationProtectionClusterName, string recoveryPointName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationFabrics/{fabricName}/replicationProtectionContainers/{protectionContainerName}/replicationProtectionClusters/{replicationProtectionClusterName}/recoveryPoints/{recoveryPointName}";
            return new ResourceIdentifier(resourceId);
        }

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }

        /// <summary> Gets the cluster recovery point. </summary>
        public virtual async Task<Response<SiteRecoveryClusterRecoveryPointResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clusterRecoveryPointClientDiagnostics.CreateScope("SiteRecoveryClusterRecoveryPointResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _clusterRecoveryPointRestClient.CreateGetRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Name,
                    Id.Parent.Name,
                    Id.Name,
                    context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SiteRecoveryClusterRecoveryPointData> response = Response.FromValue(SiteRecoveryClusterRecoveryPointData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new SiteRecoveryClusterRecoveryPointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the cluster recovery point. </summary>
        public virtual Response<SiteRecoveryClusterRecoveryPointResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clusterRecoveryPointClientDiagnostics.CreateScope("SiteRecoveryClusterRecoveryPointResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _clusterRecoveryPointRestClient.CreateGetRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Name,
                    Id.Parent.Name,
                    Id.Name,
                    context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SiteRecoveryClusterRecoveryPointData> response = Response.FromValue(SiteRecoveryClusterRecoveryPointData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new SiteRecoveryClusterRecoveryPointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        SiteRecoveryClusterRecoveryPointData IJsonModel<SiteRecoveryClusterRecoveryPointData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<SiteRecoveryClusterRecoveryPointData>)Data).Create(ref reader, options);
        void IJsonModel<SiteRecoveryClusterRecoveryPointData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SiteRecoveryClusterRecoveryPointData>)Data).Write(writer, options);
        SiteRecoveryClusterRecoveryPointData IPersistableModel<SiteRecoveryClusterRecoveryPointData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ((IPersistableModel<SiteRecoveryClusterRecoveryPointData>)Data).Create(data, options);
        string IPersistableModel<SiteRecoveryClusterRecoveryPointData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<SiteRecoveryClusterRecoveryPointData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<SiteRecoveryClusterRecoveryPointData>)Data).Write(options);
    }
}
