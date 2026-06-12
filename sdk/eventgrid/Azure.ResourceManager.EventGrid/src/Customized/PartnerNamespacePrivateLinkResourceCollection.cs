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
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.EventGrid.Mocking;

namespace Azure.ResourceManager.EventGrid
{
    public partial class PartnerNamespacePrivateLinkResourceCollection : ArmCollection, IAsyncEnumerable<PartnerNamespacePrivateLinkResource>, IEnumerable<PartnerNamespacePrivateLinkResource>
    {
        private readonly ClientDiagnostics _privateLinkResourcesClientDiagnostics;
        private readonly PrivateLinkResources _privateLinkResourcesRestClient;

        protected PartnerNamespacePrivateLinkResourceCollection()
        {
        }

        internal PartnerNamespacePrivateLinkResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(PartnerNamespacePrivateLinkResource.ResourceType, out string apiVersion);
            _privateLinkResourcesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EventGrid", PartnerNamespacePrivateLinkResource.ResourceType.Namespace, Diagnostics);
            _privateLinkResourcesRestClient = new PrivateLinkResources(_privateLinkResourcesClientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2025-07-15-preview");
            ValidateResourceId(id);
        }

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != PartnerNamespaceResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, PartnerNamespaceResource.ResourceType), nameof(id));
            }
        }

        public virtual async Task<Response<PartnerNamespacePrivateLinkResource>> GetAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            MockableEventGridResourceGroupResource resourceGroup = new MockableEventGridResourceGroupResource(Client, Id.Parent);
            Response<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource> response = await resourceGroup.GetAsync("partnerNamespaces", Id.Name, privateLinkResourceName, cancellationToken).ConfigureAwait(false);
            return PrivateLinkResourceCompat.Convert(response, PrivateLinkResourceCompat.ToPartnerNamespaceResource(Client, response.Value));
        }

        public virtual Response<PartnerNamespacePrivateLinkResource> Get(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            MockableEventGridResourceGroupResource resourceGroup = new MockableEventGridResourceGroupResource(Client, Id.Parent);
            Response<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource> response = resourceGroup.Get("partnerNamespaces", Id.Name, privateLinkResourceName, cancellationToken);
            return PrivateLinkResourceCompat.Convert(response, PrivateLinkResourceCompat.ToPartnerNamespaceResource(Client, response.Value));
        }

        public virtual AsyncPageable<PartnerNamespacePrivateLinkResource> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource, PartnerNamespacePrivateLinkResource>(
                new PrivateLinkResourcesGetByResourceAsyncCollectionResultOfT(
                    _privateLinkResourcesRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    "partnerNamespaces",
                    Id.Name,
                    filter,
                    top,
                    context,
                    "PartnerNamespacePrivateLinkResourceCollection.GetAll"),
                item => PrivateLinkResourceCompat.ToPartnerNamespaceResource(Client, item));
        }

        public virtual Pageable<PartnerNamespacePrivateLinkResource> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource, PartnerNamespacePrivateLinkResource>(
                new PrivateLinkResourcesGetByResourceCollectionResultOfT(
                    _privateLinkResourcesRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    "partnerNamespaces",
                    Id.Name,
                    filter,
                    top,
                    context,
                    "PartnerNamespacePrivateLinkResourceCollection.GetAll"),
                item => PrivateLinkResourceCompat.ToPartnerNamespaceResource(Client, item));
        }

        public virtual async Task<Response<bool>> ExistsAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("PartnerNamespacePrivateLinkResourceCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", Id.Name, privateLinkResourceName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                return result.Status switch
                {
                    200 => Response.FromValue(true, result),
                    404 => Response.FromValue(false, result),
                    _ => throw new RequestFailedException(result)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<bool> Exists(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("PartnerNamespacePrivateLinkResourceCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", Id.Name, privateLinkResourceName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                return result.Status switch
                {
                    200 => Response.FromValue(true, result),
                    404 => Response.FromValue(false, result),
                    _ => throw new RequestFailedException(result)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<NullableResponse<PartnerNamespacePrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("PartnerNamespacePrivateLinkResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", Id.Name, privateLinkResourceName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                return result.Status switch
                {
                    200 => Response.FromValue(PrivateLinkResourceCompat.ToPartnerNamespaceResource(Client, global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource.FromResponse(result)), result),
                    404 => new NoValueResponse<PartnerNamespacePrivateLinkResource>(result),
                    _ => throw new RequestFailedException(result)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual NullableResponse<PartnerNamespacePrivateLinkResource> GetIfExists(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("PartnerNamespacePrivateLinkResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", Id.Name, privateLinkResourceName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                return result.Status switch
                {
                    200 => Response.FromValue(PrivateLinkResourceCompat.ToPartnerNamespaceResource(Client, global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource.FromResponse(result)), result),
                    404 => new NoValueResponse<PartnerNamespacePrivateLinkResource>(result),
                    _ => throw new RequestFailedException(result)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PartnerNamespacePrivateLinkResource> IEnumerable<PartnerNamespacePrivateLinkResource>.GetEnumerator() => GetAll().GetEnumerator();

        IAsyncEnumerator<PartnerNamespacePrivateLinkResource> IAsyncEnumerable<PartnerNamespacePrivateLinkResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();
    }
}
