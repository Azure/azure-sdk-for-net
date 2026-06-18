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
#pragma warning disable SA1402 // Keep closely related compatibility partials together.

namespace Azure.ResourceManager.IotHub
{
    // Compatibility shims for previous GA collection-style APIs and string If-Match overloads.
    public partial class IotHubDescriptionResource
    {
        public virtual IotHubPrivateEndpointConnectionCollection GetIotHubPrivateEndpointConnections()
            => GetCachedClient(client => new IotHubPrivateEndpointConnectionCollection(client, Id));

        [ForwardsClientCalls]
        public virtual async Task<Response<IotHubPrivateEndpointConnectionResource>> GetIotHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => await GetIotHubPrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);

        [ForwardsClientCalls]
        public virtual Response<IotHubPrivateEndpointConnectionResource> GetIotHubPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => GetIotHubPrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);

        public virtual IotHubPrivateEndpointGroupInformationCollection GetAllIotHubPrivateEndpointGroupInformation()
            => GetCachedClient(client => new IotHubPrivateEndpointGroupInformationCollection(client, Id));

        [ForwardsClientCalls]
        public virtual async Task<Response<IotHubPrivateEndpointGroupInformationResource>> GetIotHubPrivateEndpointGroupInformationAsync(string groupId, CancellationToken cancellationToken = default)
            => await GetAllIotHubPrivateEndpointGroupInformation().GetAsync(groupId, cancellationToken).ConfigureAwait(false);

        [ForwardsClientCalls]
        public virtual Response<IotHubPrivateEndpointGroupInformationResource> GetIotHubPrivateEndpointGroupInformation(string groupId, CancellationToken cancellationToken = default)
            => GetAllIotHubPrivateEndpointGroupInformation().Get(groupId, cancellationToken);
    }

    // Back-compat overloads use string ETags because the previous GA surface exposed If-Match as string.
    public partial class IotHubDescriptionCollection
    {
        public virtual async Task<ArmOperation<IotHubDescriptionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resourceName, IotHubDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, resourceName, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        public virtual ArmOperation<IotHubDescriptionResource> CreateOrUpdate(WaitUntil waitUntil, string resourceName, IotHubDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, resourceName, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }

    // Back-compat overloads use string ETags because the previous GA surface exposed If-Match as string.
    public partial class IotHubCertificateDescriptionCollection
    {
        public virtual async Task<ArmOperation<IotHubCertificateDescriptionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string certificateName, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, certificateName, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        public virtual ArmOperation<IotHubCertificateDescriptionResource> CreateOrUpdate(WaitUntil waitUntil, string certificateName, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, certificateName, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }

    // Back-compat overloads use string ETags because the previous GA surface exposed If-Match as string.
    public partial class IotHubCertificateDescriptionResource
    {
        public virtual async Task<ArmOperation<IotHubCertificateDescriptionResource>> UpdateAsync(WaitUntil waitUntil, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        public virtual ArmOperation<IotHubCertificateDescriptionResource> Update(WaitUntil waitUntil, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }

    public partial class IotHubPrivateEndpointConnectionCollection
    {
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

#pragma warning restore SA1402
#pragma warning restore CS1591
