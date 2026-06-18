// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRoutePortAuthorizationCollection type. </summary>
    public partial class ExpressRoutePortAuthorizationCollection
    {
        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ExpressRoutePortAuthorizationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string authorizationName, ExpressRoutePortAuthorizationData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, Id.Name, authorizationName, data, cancellationToken);

        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<ExpressRoutePortAuthorizationResource> CreateOrUpdate(WaitUntil waitUntil, string authorizationName, ExpressRoutePortAuthorizationData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, Id.Name, authorizationName, data, cancellationToken);

        /// <summary> Invokes the GetAsync compatibility operation. </summary>
        public virtual Task<Response<ExpressRoutePortAuthorizationResource>> GetAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetAsync(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the Get compatibility operation. </summary>
        public virtual Response<ExpressRoutePortAuthorizationResource> Get(string authorizationName, CancellationToken cancellationToken = default)
            => Get(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the GetAllAsync compatibility operation. </summary>
        public virtual AsyncPageable<ExpressRoutePortAuthorizationResource> GetAllAsync(CancellationToken cancellationToken = default)
            => GetAllAsync(Id.Name, cancellationToken);

        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual Pageable<ExpressRoutePortAuthorizationResource> GetAll(CancellationToken cancellationToken = default)
            => GetAll(Id.Name, cancellationToken);

        /// <summary> Invokes the ExistsAsync compatibility operation. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string authorizationName, CancellationToken cancellationToken = default)
            => ExistsAsync(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the Exists compatibility operation. </summary>
        public virtual Response<bool> Exists(string authorizationName, CancellationToken cancellationToken = default)
            => Exists(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the GetIfExistsAsync compatibility operation. </summary>
        public virtual Task<NullableResponse<ExpressRoutePortAuthorizationResource>> GetIfExistsAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the GetIfExists compatibility operation. </summary>
        public virtual NullableResponse<ExpressRoutePortAuthorizationResource> GetIfExists(string authorizationName, CancellationToken cancellationToken = default)
            => GetIfExists(Id.Name, authorizationName, cancellationToken);

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();

        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual async Task<ArmOperation<ExpressRoutePortAuthorizationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string expressRoutePortName, string authorizationName, ExpressRoutePortAuthorizationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRoutePortName, nameof(expressRoutePortName));
            Argument.AssertNotNullOrEmpty(authorizationName, nameof(authorizationName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _expressRoutePortAuthorizationsClientDiagnostics.CreateScope("ExpressRoutePortAuthorizationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _expressRoutePortAuthorizationsRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, expressRoutePortName, authorizationName, ExpressRoutePortAuthorizationData.ToRequestContent(data), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetworkArmOperation<ExpressRoutePortAuthorizationResource> operation = new NetworkArmOperation<ExpressRoutePortAuthorizationResource>(
                    new ExpressRoutePortAuthorizationResourceOperationSource(Client),
                    _expressRoutePortAuthorizationsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<ExpressRoutePortAuthorizationResource> CreateOrUpdate(WaitUntil waitUntil, string expressRoutePortName, string authorizationName, ExpressRoutePortAuthorizationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRoutePortName, nameof(expressRoutePortName));
            Argument.AssertNotNullOrEmpty(authorizationName, nameof(authorizationName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _expressRoutePortAuthorizationsClientDiagnostics.CreateScope("ExpressRoutePortAuthorizationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _expressRoutePortAuthorizationsRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, expressRoutePortName, authorizationName, ExpressRoutePortAuthorizationData.ToRequestContent(data), context);
                Response response = Pipeline.ProcessMessage(message, context);
                NetworkArmOperation<ExpressRoutePortAuthorizationResource> operation = new NetworkArmOperation<ExpressRoutePortAuthorizationResource>(
                    new ExpressRoutePortAuthorizationResourceOperationSource(Client),
                    _expressRoutePortAuthorizationsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Invokes the GetAsync compatibility operation. </summary>
        public virtual async Task<Response<ExpressRoutePortAuthorizationResource>> GetAsync(string expressRoutePortName, string authorizationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRoutePortName, nameof(expressRoutePortName));
            Argument.AssertNotNullOrEmpty(authorizationName, nameof(authorizationName));

            using DiagnosticScope scope = _expressRoutePortAuthorizationsClientDiagnostics.CreateScope("ExpressRoutePortAuthorizationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _expressRoutePortAuthorizationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, expressRoutePortName, authorizationName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ExpressRoutePortAuthorizationData> response = Response.FromValue(ExpressRoutePortAuthorizationData.FromResponse(result), result);
                if (response.Value is null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ExpressRoutePortAuthorizationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Invokes the Get compatibility operation. </summary>
        public virtual Response<ExpressRoutePortAuthorizationResource> Get(string expressRoutePortName, string authorizationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRoutePortName, nameof(expressRoutePortName));
            Argument.AssertNotNullOrEmpty(authorizationName, nameof(authorizationName));

            using DiagnosticScope scope = _expressRoutePortAuthorizationsClientDiagnostics.CreateScope("ExpressRoutePortAuthorizationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _expressRoutePortAuthorizationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, expressRoutePortName, authorizationName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ExpressRoutePortAuthorizationData> response = Response.FromValue(ExpressRoutePortAuthorizationData.FromResponse(result), result);
                if (response.Value is null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ExpressRoutePortAuthorizationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Invokes the GetAllAsync compatibility operation. </summary>
        public virtual AsyncPageable<ExpressRoutePortAuthorizationResource> GetAllAsync(string expressRoutePortName, CancellationToken cancellationToken = default)
            => AsyncPageable<ExpressRoutePortAuthorizationResource>.FromPages(GetAllPages(expressRoutePortName, cancellationToken));

        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual Pageable<ExpressRoutePortAuthorizationResource> GetAll(string expressRoutePortName, CancellationToken cancellationToken = default)
            => Pageable<ExpressRoutePortAuthorizationResource>.FromPages(GetAllPages(expressRoutePortName, cancellationToken));

        /// <summary> Invokes the ExistsAsync compatibility operation. </summary>
        public virtual async Task<Response<bool>> ExistsAsync(string expressRoutePortName, string authorizationName, CancellationToken cancellationToken = default)
        {
            Response<ExpressRoutePortAuthorizationData> response = await GetIfExistsDataAsync(expressRoutePortName, authorizationName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value != null, response.GetRawResponse());
        }

        /// <summary> Invokes the Exists compatibility operation. </summary>
        public virtual Response<bool> Exists(string expressRoutePortName, string authorizationName, CancellationToken cancellationToken = default)
        {
            Response<ExpressRoutePortAuthorizationData> response = GetIfExistsData(expressRoutePortName, authorizationName, cancellationToken);
            return Response.FromValue(response.Value != null, response.GetRawResponse());
        }

        /// <summary> Invokes the GetIfExistsAsync compatibility operation. </summary>
        public virtual async Task<NullableResponse<ExpressRoutePortAuthorizationResource>> GetIfExistsAsync(string expressRoutePortName, string authorizationName, CancellationToken cancellationToken = default)
        {
            Response<ExpressRoutePortAuthorizationData> response = await GetIfExistsDataAsync(expressRoutePortName, authorizationName, cancellationToken).ConfigureAwait(false);
            return response.Value is null
                ? new NoValueResponse<ExpressRoutePortAuthorizationResource>(response.GetRawResponse())
                : Response.FromValue(new ExpressRoutePortAuthorizationResource(Client, response.Value), response.GetRawResponse());
        }

        /// <summary> Invokes the GetIfExists compatibility operation. </summary>
        public virtual NullableResponse<ExpressRoutePortAuthorizationResource> GetIfExists(string expressRoutePortName, string authorizationName, CancellationToken cancellationToken = default)
        {
            Response<ExpressRoutePortAuthorizationData> response = GetIfExistsData(expressRoutePortName, authorizationName, cancellationToken);
            return response.Value is null
                ? new NoValueResponse<ExpressRoutePortAuthorizationResource>(response.GetRawResponse())
                : Response.FromValue(new ExpressRoutePortAuthorizationResource(Client, response.Value), response.GetRawResponse());
        }

        private IEnumerable<Page<ExpressRoutePortAuthorizationResource>> GetAllPages(string expressRoutePortName, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(expressRoutePortName, nameof(expressRoutePortName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            Uri nextPage = null;
            do
            {
                HttpMessage message = nextPage is null
                    ? _expressRoutePortAuthorizationsRestClient.CreateGetAllRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, expressRoutePortName, context)
                    : _expressRoutePortAuthorizationsRestClient.CreateNextGetAllRequest(nextPage, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, expressRoutePortName, context);
                using DiagnosticScope scope = _expressRoutePortAuthorizationsClientDiagnostics.CreateScope("ExpressRoutePortAuthorizationCollection.GetAll");
                scope.Start();
                Response response;
                try
                {
                    response = Pipeline.ProcessMessage(message, context);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }

                IReadOnlyList<ExpressRoutePortAuthorizationResource> values = DeserializePage(response, out nextPage);
                yield return Page<ExpressRoutePortAuthorizationResource>.FromValues(values, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
            }
            while (nextPage != null);
        }

        private IReadOnlyList<ExpressRoutePortAuthorizationResource> DeserializePage(Response response, out Uri nextPage)
        {
            List<ExpressRoutePortAuthorizationResource> resources = new List<ExpressRoutePortAuthorizationResource>();
            nextPage = null;
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            JsonElement root = document.RootElement;
            if (root.TryGetProperty("value", out JsonElement value) && value.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement item in value.EnumerateArray())
                {
                    resources.Add(new ExpressRoutePortAuthorizationResource(Client, ExpressRoutePortAuthorizationData.DeserializeExpressRoutePortAuthorizationData(item, ModelSerializationExtensions.WireOptions)));
                }
            }
            if (root.TryGetProperty("nextLink", out JsonElement nextLinkElement) && nextLinkElement.ValueKind != JsonValueKind.Null)
            {
                string nextLink = nextLinkElement.GetString();
                nextPage = string.IsNullOrEmpty(nextLink) ? null : new Uri(nextLink, UriKind.RelativeOrAbsolute);
            }
            return resources;
        }

        private async Task<Response<ExpressRoutePortAuthorizationData>> GetIfExistsDataAsync(string expressRoutePortName, string authorizationName, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(expressRoutePortName, nameof(expressRoutePortName));
            Argument.AssertNotNullOrEmpty(authorizationName, nameof(authorizationName));

            using DiagnosticScope scope = _expressRoutePortAuthorizationsClientDiagnostics.CreateScope("ExpressRoutePortAuthorizationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _expressRoutePortAuthorizationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, expressRoutePortName, authorizationName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                return CreateNullableDataResponse(message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<ExpressRoutePortAuthorizationData> GetIfExistsData(string expressRoutePortName, string authorizationName, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(expressRoutePortName, nameof(expressRoutePortName));
            Argument.AssertNotNullOrEmpty(authorizationName, nameof(authorizationName));

            using DiagnosticScope scope = _expressRoutePortAuthorizationsClientDiagnostics.CreateScope("ExpressRoutePortAuthorizationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _expressRoutePortAuthorizationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, expressRoutePortName, authorizationName, context);
                Pipeline.Send(message, context.CancellationToken);
                return CreateNullableDataResponse(message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static Response<ExpressRoutePortAuthorizationData> CreateNullableDataResponse(Response result)
            => result.Status switch
            {
                200 => Response.FromValue(ExpressRoutePortAuthorizationData.FromResponse(result), result),
                404 => Response.FromValue((ExpressRoutePortAuthorizationData)null, result),
                _ => throw new RequestFailedException(result)
            };
    }
}
