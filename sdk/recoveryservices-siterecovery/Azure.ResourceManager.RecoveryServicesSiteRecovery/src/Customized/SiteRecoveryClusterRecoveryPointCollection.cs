// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Models;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    /// <summary>
    /// A class representing a collection of <see cref="SiteRecoveryClusterRecoveryPointResource"/>.
    /// </summary>
    public partial class SiteRecoveryClusterRecoveryPointCollection : ArmCollection, IEnumerable<SiteRecoveryClusterRecoveryPointResource>, IAsyncEnumerable<SiteRecoveryClusterRecoveryPointResource>
    {
        private readonly ClientDiagnostics _clusterRecoveryPointClientDiagnostics;
        private readonly ClusterRecoveryPoint _clusterRecoveryPointRestClient;
        private readonly ClientDiagnostics _clusterRecoveryPointsClientDiagnostics;
        private readonly ClusterRecoveryPoints _clusterRecoveryPointsRestClient;

        /// <summary> Initializes a new instance of SiteRecoveryClusterRecoveryPointCollection for mocking. </summary>
        protected SiteRecoveryClusterRecoveryPointCollection()
        {
        }

        internal SiteRecoveryClusterRecoveryPointCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(SiteRecoveryClusterRecoveryPointResource.ResourceType, out string apiVersion);
            _clusterRecoveryPointClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.RecoveryServicesSiteRecovery", SiteRecoveryClusterRecoveryPointResource.ResourceType.Namespace, Diagnostics);
            _clusterRecoveryPointRestClient = new ClusterRecoveryPoint(_clusterRecoveryPointClientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2026-01-01");
            _clusterRecoveryPointsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.RecoveryServicesSiteRecovery", SiteRecoveryClusterRecoveryPointResource.ResourceType.Namespace, Diagnostics);
            _clusterRecoveryPointsRestClient = new ClusterRecoveryPoints(_clusterRecoveryPointsClientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2026-01-01");
            ValidateResourceId(id);
        }

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteRecoveryReplicationProtectionClusterResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, SiteRecoveryReplicationProtectionClusterResource.ResourceType), nameof(id));
            }
        }

        private static SiteRecoveryClusterRecoveryPointData ToData(SiteRecoveryClusterRecoveryPoint m)
        {
            if (m == null) return null;
            ResourceType resourceType = string.IsNullOrEmpty(m.Type) ? SiteRecoveryClusterRecoveryPointResource.ResourceType : new ResourceType(m.Type);
            return new SiteRecoveryClusterRecoveryPointData(m.Id, m.Name, resourceType, default, m.Properties);
        }

        public virtual async Task<Response<SiteRecoveryClusterRecoveryPointResource>> GetAsync(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoveryPointName, nameof(recoveryPointName));
            using DiagnosticScope scope = _clusterRecoveryPointClientDiagnostics.CreateScope("SiteRecoveryClusterRecoveryPointCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _clusterRecoveryPointRestClient.CreateGetRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Name,
                    Id.Parent.Name,
                    Id.Name,
                    recoveryPointName,
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

        public virtual Response<SiteRecoveryClusterRecoveryPointResource> Get(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoveryPointName, nameof(recoveryPointName));
            using DiagnosticScope scope = _clusterRecoveryPointClientDiagnostics.CreateScope("SiteRecoveryClusterRecoveryPointCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _clusterRecoveryPointRestClient.CreateGetRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Name,
                    Id.Parent.Name,
                    Id.Name,
                    recoveryPointName,
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

        public virtual AsyncPageable<SiteRecoveryClusterRecoveryPointResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<SiteRecoveryClusterRecoveryPoint, SiteRecoveryClusterRecoveryPointResource>(
                new ClusterRecoveryPointsGetByReplicationProtectionClusterAsyncCollectionResultOfT(
                    _clusterRecoveryPointsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Name,
                    Id.Parent.Name,
                    Id.Name,
                    context,
                    "SiteRecoveryClusterRecoveryPointCollection.GetAll"),
                m => new SiteRecoveryClusterRecoveryPointResource(Client, ToData(m)));
        }

        public virtual Pageable<SiteRecoveryClusterRecoveryPointResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<SiteRecoveryClusterRecoveryPoint, SiteRecoveryClusterRecoveryPointResource>(
                new ClusterRecoveryPointsGetByReplicationProtectionClusterCollectionResultOfT(
                    _clusterRecoveryPointsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Name,
                    Id.Parent.Name,
                    Id.Name,
                    context,
                    "SiteRecoveryClusterRecoveryPointCollection.GetAll"),
                m => new SiteRecoveryClusterRecoveryPointResource(Client, ToData(m)));
        }

        public virtual async Task<Response<bool>> ExistsAsync(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoveryPointName, nameof(recoveryPointName));
            using DiagnosticScope scope = _clusterRecoveryPointClientDiagnostics.CreateScope("SiteRecoveryClusterRecoveryPointCollection.Exists");
            scope.Start();
            try
            {
                NullableResponse<SiteRecoveryClusterRecoveryPointResource> result = await GetIfExistsAsync(recoveryPointName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(result.HasValue, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<bool> Exists(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoveryPointName, nameof(recoveryPointName));
            using DiagnosticScope scope = _clusterRecoveryPointClientDiagnostics.CreateScope("SiteRecoveryClusterRecoveryPointCollection.Exists");
            scope.Start();
            try
            {
                NullableResponse<SiteRecoveryClusterRecoveryPointResource> result = GetIfExists(recoveryPointName, cancellationToken);
                return Response.FromValue(result.HasValue, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<NullableResponse<SiteRecoveryClusterRecoveryPointResource>> GetIfExistsAsync(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoveryPointName, nameof(recoveryPointName));
            using DiagnosticScope scope = _clusterRecoveryPointClientDiagnostics.CreateScope("SiteRecoveryClusterRecoveryPointCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
                HttpMessage message = _clusterRecoveryPointRestClient.CreateGetRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Name,
                    Id.Parent.Name,
                    Id.Name,
                    recoveryPointName,
                    context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                if (result.Status == 404)
                {
                    return new NoValueResponse<SiteRecoveryClusterRecoveryPointResource>(result);
                }
                Response<SiteRecoveryClusterRecoveryPointData> response = Response.FromValue(SiteRecoveryClusterRecoveryPointData.FromResponse(result), result);
                if (response.Value == null)
                {
                    return new NoValueResponse<SiteRecoveryClusterRecoveryPointResource>(response.GetRawResponse());
                }
                return Response.FromValue(new SiteRecoveryClusterRecoveryPointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual NullableResponse<SiteRecoveryClusterRecoveryPointResource> GetIfExists(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoveryPointName, nameof(recoveryPointName));
            using DiagnosticScope scope = _clusterRecoveryPointClientDiagnostics.CreateScope("SiteRecoveryClusterRecoveryPointCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
                HttpMessage message = _clusterRecoveryPointRestClient.CreateGetRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Parent.Parent.Name,
                    Id.Parent.Parent.Name,
                    Id.Parent.Name,
                    Id.Name,
                    recoveryPointName,
                    context);
                Response result = Pipeline.ProcessMessage(message, context);
                if (result.Status == 404)
                {
                    return new NoValueResponse<SiteRecoveryClusterRecoveryPointResource>(result);
                }
                Response<SiteRecoveryClusterRecoveryPointData> response = Response.FromValue(SiteRecoveryClusterRecoveryPointData.FromResponse(result), result);
                if (response.Value == null)
                {
                    return new NoValueResponse<SiteRecoveryClusterRecoveryPointResource>(response.GetRawResponse());
                }
                return Response.FromValue(new SiteRecoveryClusterRecoveryPointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteRecoveryClusterRecoveryPointResource> IEnumerable<SiteRecoveryClusterRecoveryPointResource>.GetEnumerator() => GetAll().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();
        IAsyncEnumerator<SiteRecoveryClusterRecoveryPointResource> IAsyncEnumerable<SiteRecoveryClusterRecoveryPointResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
