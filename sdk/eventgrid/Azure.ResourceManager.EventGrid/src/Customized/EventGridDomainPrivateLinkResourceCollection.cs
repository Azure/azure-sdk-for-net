// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
    /// <summary> Represents a collection of Event Grid domain private link resources. </summary>
    // GA-compat private-link surface: the generator emits one generic PrivateLinkResources group; main exposes
    // typed per-resource (Domain/Topic/PartnerNamespace) collections/resources. Rationale: PrivateLinkResourceCompat.cs.
    public partial class EventGridDomainPrivateLinkResourceCollection : ArmCollection, IAsyncEnumerable<EventGridDomainPrivateLinkResource>, IEnumerable<EventGridDomainPrivateLinkResource>
    {
        private readonly ClientDiagnostics _privateLinkResourcesClientDiagnostics;
        private readonly PrivateLinkResources _privateLinkResourcesRestClient;

        /// <summary> Initializes a new instance of the <see cref="EventGridDomainPrivateLinkResourceCollection"/> class. </summary>
        protected EventGridDomainPrivateLinkResourceCollection()
        {
        }

        internal EventGridDomainPrivateLinkResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(EventGridDomainPrivateLinkResource.ResourceType, out string apiVersion);
            _privateLinkResourcesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EventGrid", EventGridDomainPrivateLinkResource.ResourceType.Namespace, Diagnostics);
            _privateLinkResourcesRestClient = new PrivateLinkResources(_privateLinkResourcesClientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2025-07-15-preview");
            ValidateResourceId(id);
        }

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != EventGridDomainResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, EventGridDomainResource.ResourceType), nameof(id));
            }
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        public virtual async Task<Response<EventGridDomainPrivateLinkResource>> GetAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            MockableEventGridResourceGroupResource resourceGroup = new MockableEventGridResourceGroupResource(Client, Id.Parent);
            Response<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource> response = await resourceGroup.GetAsync("domains", Id.Name, privateLinkResourceName, cancellationToken).ConfigureAwait(false);
            return PrivateLinkResourceCompat.Convert(response, PrivateLinkResourceCompat.ToDomainResource(Client, response.Value));
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        public virtual Response<EventGridDomainPrivateLinkResource> Get(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            MockableEventGridResourceGroupResource resourceGroup = new MockableEventGridResourceGroupResource(Client, Id.Parent);
            Response<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource> response = resourceGroup.Get("domains", Id.Name, privateLinkResourceName, cancellationToken);
            return PrivateLinkResourceCompat.Convert(response, PrivateLinkResourceCompat.ToDomainResource(Client, response.Value));
        }

        /// <summary> Gets all private link resources. </summary>
        /// <param name="filter"> The filter to apply to the operation. </param>
        /// <param name="top"> The maximum number of items to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A pageable sequence of resources. </returns>
        public virtual AsyncPageable<EventGridDomainPrivateLinkResource> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource, EventGridDomainPrivateLinkResource>(
                new PrivateLinkResourcesGetByResourceAsyncCollectionResultOfT(
                    _privateLinkResourcesRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    "domains",
                    Id.Name,
                    filter,
                    top,
                    context,
                    "EventGridDomainPrivateLinkResourceCollection.GetAll"),
                item => PrivateLinkResourceCompat.ToDomainResource(Client, item));
        }

        /// <summary> Gets all private link resources. </summary>
        /// <param name="filter"> The filter to apply to the operation. </param>
        /// <param name="top"> The maximum number of items to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A pageable sequence of resources. </returns>
        public virtual Pageable<EventGridDomainPrivateLinkResource> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource, EventGridDomainPrivateLinkResource>(
                new PrivateLinkResourcesGetByResourceCollectionResultOfT(
                    _privateLinkResourcesRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    "domains",
                    Id.Name,
                    filter,
                    top,
                    context,
                    "EventGridDomainPrivateLinkResourceCollection.GetAll"),
                item => PrivateLinkResourceCompat.ToDomainResource(Client, item));
        }

        /// <summary> Checks whether a specific private link resource exists. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response indicating whether the resource exists. </returns>
        public virtual async Task<Response<bool>> ExistsAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("EventGridDomainPrivateLinkResourceCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", Id.Name, privateLinkResourceName, context);
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

        /// <summary> Checks whether a specific private link resource exists. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response indicating whether the resource exists. </returns>
        public virtual Response<bool> Exists(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("EventGridDomainPrivateLinkResourceCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", Id.Name, privateLinkResourceName, context);
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

        /// <summary> Gets a specific private link resource if it exists. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The resource if it exists; otherwise, an empty response. </returns>
        public virtual async Task<NullableResponse<EventGridDomainPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("EventGridDomainPrivateLinkResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", Id.Name, privateLinkResourceName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                return result.Status switch
                {
                    200 => Response.FromValue(PrivateLinkResourceCompat.ToDomainResource(Client, global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource.FromResponse(result)), result),
                    404 => new NoValueResponse<EventGridDomainPrivateLinkResource>(result),
                    _ => throw new RequestFailedException(result)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a specific private link resource if it exists. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The resource if it exists; otherwise, an empty response. </returns>
        public virtual NullableResponse<EventGridDomainPrivateLinkResource> GetIfExists(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("EventGridDomainPrivateLinkResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", Id.Name, privateLinkResourceName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                return result.Status switch
                {
                    200 => Response.FromValue(PrivateLinkResourceCompat.ToDomainResource(Client, global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource.FromResponse(result)), result),
                    404 => new NoValueResponse<EventGridDomainPrivateLinkResource>(result),
                    _ => throw new RequestFailedException(result)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<EventGridDomainPrivateLinkResource> IEnumerable<EventGridDomainPrivateLinkResource>.GetEnumerator() => GetAll().GetEnumerator();

        IAsyncEnumerator<EventGridDomainPrivateLinkResource> IAsyncEnumerable<EventGridDomainPrivateLinkResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();
    }
}
