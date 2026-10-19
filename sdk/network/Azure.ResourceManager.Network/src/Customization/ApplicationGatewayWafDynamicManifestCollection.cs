// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Network
{
    // Preserve the released regional collection because native generation exposes only a singleton.
    // Listing must use the real paginated endpoint, not a page synthesized from the singleton GET.
    /// <summary> A collection of regional application gateway WAF manifests. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This collection facade is deprecated and retained for backward compatibility. There is no equivalent native public listing API.")]
    public partial class ApplicationGatewayWafDynamicManifestCollection : ArmCollection, IEnumerable<ApplicationGatewayWafDynamicManifestResource>, IAsyncEnumerable<ApplicationGatewayWafDynamicManifestResource>
    {
        private const string ListMessage = "This collection facade is deprecated and retained for backward compatibility. There is no equivalent native public listing API.";
        private const string GetMessage = "For singleton access, use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).Get(cancellationToken). Handle 404 when checking for existence.";
        private const string GetAsyncMessage = "For singleton access, use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).GetAsync(cancellationToken). Handle 404 when checking for existence.";

        private readonly AzureLocation _location;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ApplicationGatewayWafDynamicManifests _listRestClient;
        private readonly ApplicationGatewayWafDynamicManifestsDefault _singletonRestClient;

        /// <summary> Initializes a new instance for mocking. </summary>
        protected ApplicationGatewayWafDynamicManifestCollection()
        {
        }

        internal ApplicationGatewayWafDynamicManifestCollection(ArmClient client, ResourceIdentifier id, AzureLocation location) : base(client, id)
        {
            _location = location;
            Argument.AssertNotNullOrEmpty(_location.ToString(), nameof(location));
            TryGetApiVersion(ApplicationGatewayWafDynamicManifestResource.ResourceType, out string apiVersion);
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ApplicationGatewayWafDynamicManifestResource.ResourceType.Namespace, Diagnostics);
            _listRestClient = new ApplicationGatewayWafDynamicManifests(_clientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, apiVersion ?? "2026-01-01");
            _singletonRestClient = new ApplicationGatewayWafDynamicManifestsDefault(_clientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, apiVersion ?? "2026-01-01");
        }

        /// <summary> Lists manifests in the collection's location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(ListMessage)]
        public virtual Pageable<ApplicationGatewayWafDynamicManifestResource> GetAll(CancellationToken cancellationToken = default)
            => new ManifestPageable(this, cancellationToken);

        /// <summary> Lists manifests in the collection's location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(ListMessage)]
        public virtual AsyncPageable<ApplicationGatewayWafDynamicManifestResource> GetAllAsync(CancellationToken cancellationToken = default)
            => new ManifestAsyncPageable(this, cancellationToken);

        /// <summary> Gets the singleton manifest in the collection's location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetMessage)]
        [ForwardsClientCalls]
        public virtual Response<ApplicationGatewayWafDynamicManifestResource> Get(CancellationToken cancellationToken = default)
            => GetResource().Get(cancellationToken);

        /// <summary> Gets the singleton manifest in the collection's location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetAsyncMessage)]
        [ForwardsClientCalls]
        public virtual Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetAsync(CancellationToken cancellationToken = default)
            => GetResource().GetAsync(cancellationToken);

        /// <summary> Gets the singleton manifest if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetMessage)]
        public virtual NullableResponse<ApplicationGatewayWafDynamicManifestResource> GetIfExists(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("ApplicationGatewayWafDynamicManifestCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _singletonRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), _location, context);
                Pipeline.Send(message, cancellationToken);
                return CreateNullableResponse(message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the singleton manifest if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetAsyncMessage)]
        public virtual async Task<NullableResponse<ApplicationGatewayWafDynamicManifestResource>> GetIfExistsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("ApplicationGatewayWafDynamicManifestCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _singletonRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), _location, context);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return CreateNullableResponse(message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks whether the singleton manifest exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetMessage)]
        [ForwardsClientCalls]
        public virtual Response<bool> Exists(CancellationToken cancellationToken = default)
        {
            NullableResponse<ApplicationGatewayWafDynamicManifestResource> response = GetIfExists(cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        /// <summary> Checks whether the singleton manifest exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetAsyncMessage)]
        [ForwardsClientCalls]
        public virtual async Task<Response<bool>> ExistsAsync(CancellationToken cancellationToken = default)
        {
            NullableResponse<ApplicationGatewayWafDynamicManifestResource> response = await GetIfExistsAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        // Named overloads preserve released signatures; the service exposes only the literal /dafault singleton.
        /// <summary> Gets the regional singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetMessage)]
        [ForwardsClientCalls]
        public virtual Response<ApplicationGatewayWafDynamicManifestResource> Get(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGatewayWafDynamicManifestName, nameof(applicationGatewayWafDynamicManifestName));
            return Get(cancellationToken);
        }

        /// <summary> Gets the regional singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetAsyncMessage)]
        [ForwardsClientCalls]
        public virtual Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetAsync(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGatewayWafDynamicManifestName, nameof(applicationGatewayWafDynamicManifestName));
            return GetAsync(cancellationToken);
        }

        /// <summary> Gets the regional singleton manifest if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetMessage)]
        [ForwardsClientCalls]
        public virtual NullableResponse<ApplicationGatewayWafDynamicManifestResource> GetIfExists(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGatewayWafDynamicManifestName, nameof(applicationGatewayWafDynamicManifestName));
            return GetIfExists(cancellationToken);
        }

        /// <summary> Gets the regional singleton manifest if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetAsyncMessage)]
        [ForwardsClientCalls]
        public virtual Task<NullableResponse<ApplicationGatewayWafDynamicManifestResource>> GetIfExistsAsync(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGatewayWafDynamicManifestName, nameof(applicationGatewayWafDynamicManifestName));
            return GetIfExistsAsync(cancellationToken);
        }

        /// <summary> Checks whether the regional singleton manifest exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetMessage)]
        [ForwardsClientCalls]
        public virtual Response<bool> Exists(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGatewayWafDynamicManifestName, nameof(applicationGatewayWafDynamicManifestName));
            return Exists(cancellationToken);
        }

        /// <summary> Checks whether the regional singleton manifest exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(GetAsyncMessage)]
        [ForwardsClientCalls]
        public virtual Task<Response<bool>> ExistsAsync(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGatewayWafDynamicManifestName, nameof(applicationGatewayWafDynamicManifestName));
            return ExistsAsync(cancellationToken);
        }

        IEnumerator<ApplicationGatewayWafDynamicManifestResource> IEnumerable<ApplicationGatewayWafDynamicManifestResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        IAsyncEnumerator<ApplicationGatewayWafDynamicManifestResource> IAsyncEnumerable<ApplicationGatewayWafDynamicManifestResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);

        private ApplicationGatewayWafDynamicManifestResource GetResource()
            => Client.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(Id.SubscriptionId, _location));

        private NullableResponse<ApplicationGatewayWafDynamicManifestResource> CreateNullableResponse(Response response)
        {
            if (response.Status == 404)
            {
                return new NoValueResponse<ApplicationGatewayWafDynamicManifestResource>(response);
            }
            if (response.Status != 200)
            {
                throw new RequestFailedException(response);
            }
            ApplicationGatewayWafDynamicManifestData data = ApplicationGatewayWafDynamicManifestData.FromResponse(response);
            return data is null
                ? new NoValueResponse<ApplicationGatewayWafDynamicManifestResource>(response)
                : Response.FromValue(new ApplicationGatewayWafDynamicManifestResource(Client, data), response);
        }

        private HttpMessage CreateListRequest(string continuationToken, RequestContext context)
            => string.IsNullOrEmpty(continuationToken)
                ? _listRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), _location, context)
                : _listRestClient.CreateNextGetRequest(new Uri(continuationToken, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), _location, context);

        private Page<ApplicationGatewayWafDynamicManifestResource> CreatePage(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            var values = new List<ApplicationGatewayWafDynamicManifestResource>();
            foreach (JsonElement item in document.RootElement.GetProperty("value").EnumerateArray())
            {
                ApplicationGatewayWafDynamicManifestData data = ApplicationGatewayWafDynamicManifestData.DeserializeApplicationGatewayWafDynamicManifestData(item, ModelSerializationExtensions.WireOptions);
                values.Add(new ApplicationGatewayWafDynamicManifestResource(Client, data));
            }
            string nextLink = document.RootElement.TryGetProperty("nextLink", out JsonElement next) ? next.GetString() : null;
            return Page<ApplicationGatewayWafDynamicManifestResource>.FromValues(values, nextLink, response);
        }

        private IEnumerable<Page<ApplicationGatewayWafDynamicManifestResource>> GetPages(string continuationToken, CancellationToken cancellationToken)
        {
            do
            {
                cancellationToken.ThrowIfCancellationRequested();
                Page<ApplicationGatewayWafDynamicManifestResource> page;
                using (DiagnosticScope scope = _clientDiagnostics.CreateScope("ApplicationGatewayWafDynamicManifestCollection.GetAll"))
                {
                    scope.Start();
                    try
                    {
                        RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                        HttpMessage message = CreateListRequest(continuationToken, context);
                        page = CreatePage(Pipeline.ProcessMessage(message, context));
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                yield return page;
                continuationToken = page.ContinuationToken;
            }
            while (!string.IsNullOrEmpty(continuationToken));
        }

        private async IAsyncEnumerable<Page<ApplicationGatewayWafDynamicManifestResource>> GetPagesAsync(string continuationToken, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            do
            {
                cancellationToken.ThrowIfCancellationRequested();
                Page<ApplicationGatewayWafDynamicManifestResource> page;
                using (DiagnosticScope scope = _clientDiagnostics.CreateScope("ApplicationGatewayWafDynamicManifestCollection.GetAll"))
                {
                    scope.Start();
                    try
                    {
                        RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                        HttpMessage message = CreateListRequest(continuationToken, context);
                        Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                        page = CreatePage(response);
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                yield return page;
                continuationToken = page.ContinuationToken;
            }
            while (!string.IsNullOrEmpty(continuationToken));
        }

        private sealed class ManifestPageable : Pageable<ApplicationGatewayWafDynamicManifestResource>
        {
            private readonly ApplicationGatewayWafDynamicManifestCollection _collection;

            internal ManifestPageable(ApplicationGatewayWafDynamicManifestCollection collection, CancellationToken cancellationToken) : base(cancellationToken)
                => _collection = collection;

            public override IEnumerable<Page<ApplicationGatewayWafDynamicManifestResource>> AsPages(string continuationToken = default, int? pageSizeHint = default)
                => _collection.GetPages(continuationToken, CancellationToken);
        }

        private sealed class ManifestAsyncPageable : AsyncPageable<ApplicationGatewayWafDynamicManifestResource>
        {
            private readonly ApplicationGatewayWafDynamicManifestCollection _collection;

            internal ManifestAsyncPageable(ApplicationGatewayWafDynamicManifestCollection collection, CancellationToken cancellationToken) : base(cancellationToken)
                => _collection = collection;

            public override IAsyncEnumerable<Page<ApplicationGatewayWafDynamicManifestResource>> AsPages(string continuationToken = default, int? pageSizeHint = default)
                => _collection.GetPagesAsync(continuationToken, CancellationToken);
        }
    }
}
