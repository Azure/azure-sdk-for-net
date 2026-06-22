// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

#pragma warning disable CS1591 // Compatibility overloads mirror existing generated API documentation.

namespace Azure.ResourceManager.IotHub
{
    public partial class IotHubPrivateEndpointConnectionCollection
    {
        // Customization justification:
        // The swagger-compatible route casing makes the generated collection require resourceName on every
        // operation. The previous GA collection was already scoped to a single IoT Hub resource, so callers
        // only supplied the private endpoint connection name. These overloads preserve that parent-scoped
        // collection experience by deriving the IoT Hub name from Id.Name and delegating to the generated
        // REST client/child resource operations.
        public virtual async Task<ArmOperation<IotHubPrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, IotHubPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
            => await GetChildResource(privateEndpointConnectionName).UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);

        public virtual ArmOperation<IotHubPrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, IotHubPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
            => GetChildResource(privateEndpointConnectionName).Update(waitUntil, data, cancellationToken);

        public virtual async Task<Response<IotHubPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => await GetChildResource(privateEndpointConnectionName).GetAsync(cancellationToken).ConfigureAwait(false);

        public virtual Response<IotHubPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => GetChildResource(privateEndpointConnectionName).Get(cancellationToken);

        public virtual async Task<Response<bool>> ExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            NullableResponse<IotHubPrivateEndpointConnectionResource> response = await GetIfExistsAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        public virtual Response<bool> Exists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            NullableResponse<IotHubPrivateEndpointConnectionResource> response = GetIfExists(privateEndpointConnectionName, cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        public virtual async Task<NullableResponse<IotHubPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _privateEndpointConnectionsRestClient.CreateGetRequest(System.Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, context);
            await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
            return CreateNullableResponse(message.Response);
        }

        public virtual NullableResponse<IotHubPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _privateEndpointConnectionsRestClient.CreateGetRequest(System.Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, context);
            Pipeline.Send(message, context.CancellationToken);
            return CreateNullableResponse(message.Response);
        }

        public virtual AsyncPageable<IotHubPrivateEndpointConnectionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return new IotHubPrivateEndpointConnectionResourceAsyncPageable(this, cancellationToken);
        }

        public virtual Pageable<IotHubPrivateEndpointConnectionResource> GetAll(CancellationToken cancellationToken = default)
        {
            return Pageable<IotHubPrivateEndpointConnectionResource>.FromPages(GetAllPages(cancellationToken));
        }

        private IEnumerable<Page<IotHubPrivateEndpointConnectionResource>> GetAllPages(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            yield return CreatePrivateEndpointConnectionPage(GetAllResponse(context));
        }

        private async Task<Response> GetAllResponseAsync(RequestContext context)
        {
            HttpMessage message = _privateEndpointConnectionsRestClient.CreateGetIotHubPrivateEndpointConnectionsRequest(System.Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
            return message.Response;
        }

        private Response GetAllResponse(RequestContext context)
        {
            HttpMessage message = _privateEndpointConnectionsRestClient.CreateGetIotHubPrivateEndpointConnectionsRequest(System.Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Pipeline.Send(message, context.CancellationToken);
            return message.Response;
        }

        private Page<IotHubPrivateEndpointConnectionResource> CreatePrivateEndpointConnectionPage(Response response)
        {
            if (response.Status != 200)
            {
                throw new RequestFailedException(response);
            }

            List<IotHubPrivateEndpointConnectionResource> items = new List<IotHubPrivateEndpointConnectionResource>();
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            foreach (JsonElement element in document.RootElement.EnumerateArray())
            {
                IotHubPrivateEndpointConnectionData data = IotHubPrivateEndpointConnectionData.DeserializeIotHubPrivateEndpointConnectionData(element, ModelSerializationExtensions.WireOptions);
                items.Add(new IotHubPrivateEndpointConnectionResource(Client, data));
            }

            return Page<IotHubPrivateEndpointConnectionResource>.FromValues(items, null, response);
        }

        private IotHubPrivateEndpointConnectionResource GetChildResource(string privateEndpointConnectionName)
        {
            ResourceIdentifier resourceId = new ResourceIdentifier($"{Id}/privateEndpointConnections/{privateEndpointConnectionName}");
            return new IotHubPrivateEndpointConnectionResource(Client, resourceId);
        }

        private NullableResponse<IotHubPrivateEndpointConnectionResource> CreateNullableResponse(Response response)
        {
            if (response.Status == 404)
            {
                return new NoValueResponse<IotHubPrivateEndpointConnectionResource>(response);
            }

            if (response.Status != 200)
            {
                throw new RequestFailedException(response);
            }

            IotHubPrivateEndpointConnectionData data = IotHubPrivateEndpointConnectionData.FromResponse(response);
            return Response.FromValue(new IotHubPrivateEndpointConnectionResource(Client, data), response);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        private sealed class IotHubPrivateEndpointConnectionResourceAsyncPageable : AsyncPageable<IotHubPrivateEndpointConnectionResource>
        {
            private readonly IotHubPrivateEndpointConnectionCollection _collection;

            public IotHubPrivateEndpointConnectionResourceAsyncPageable(IotHubPrivateEndpointConnectionCollection collection, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _collection = collection;
            }

            public override async IAsyncEnumerable<Page<IotHubPrivateEndpointConnectionResource>> AsPages(string continuationToken = default, int? pageSizeHint = default)
            {
                if (continuationToken != null)
                {
                    yield break;
                }

                RequestContext context = new RequestContext { CancellationToken = CancellationToken };
                yield return _collection.CreatePrivateEndpointConnectionPage(await _collection.GetAllResponseAsync(context).ConfigureAwait(false));
            }
        }
    }
}

#pragma warning restore CS1591
