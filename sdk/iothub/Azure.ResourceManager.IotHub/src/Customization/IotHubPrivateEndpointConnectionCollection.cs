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

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // The swagger-compatible route casing makes the generated collection require resourceName on every
    // operation. The previous GA collection was already scoped to a single IoT Hub resource, so callers
    // only supplied the private endpoint connection name. These overloads preserve that parent-scoped
    // collection experience by deriving the IoT Hub name from Id.Name and delegating to the generated
    // REST client/child resource operations.
    /// <summary>
    /// A class representing a collection of <see cref="IotHubPrivateEndpointConnectionResource"/> and their operations.
    /// Each <see cref="IotHubPrivateEndpointConnectionResource"/> in the collection will belong to the same instance of <see cref="IotHubDescriptionResource"/>.
    /// To get a <see cref="IotHubPrivateEndpointConnectionCollection"/> instance call the GetIotHubPrivateEndpointConnections method from an instance of <see cref="IotHubDescriptionResource"/>.
    /// </summary>
    public partial class IotHubPrivateEndpointConnectionCollection
    {
        /// <summary>
        /// Update the state of the specified private endpoint connection associated with the IotHub.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="data"> The private endpoint connection data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<IotHubPrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, IotHubPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
            => await GetChildResource(privateEndpointConnectionName).UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update the state of the specified private endpoint connection associated with the IotHub.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="data"> The private endpoint connection data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<IotHubPrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, IotHubPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
            => GetChildResource(privateEndpointConnectionName).Update(waitUntil, data, cancellationToken);

        /// <summary>
        /// Get private endpoint connection properties
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IotHubPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => await GetChildResource(privateEndpointConnectionName).GetAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get private endpoint connection properties
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IotHubPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => GetChildResource(privateEndpointConnectionName).Get(cancellationToken);

        /// <summary> Checks whether a private endpoint connection resource exists. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            NullableResponse<IotHubPrivateEndpointConnectionResource> response = await GetIfExistsAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        /// <summary> Checks whether a private endpoint connection resource exists. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            NullableResponse<IotHubPrivateEndpointConnectionResource> response = GetIfExists(privateEndpointConnectionName, cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        /// <summary> Tries to get details for this private endpoint connection. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<IotHubPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _privateEndpointConnectionsRestClient.CreateGetRequest(System.Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, context);
            await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
            return CreateNullableResponse(message.Response);
        }

        /// <summary> Tries to get details for this private endpoint connection. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<IotHubPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _privateEndpointConnectionsRestClient.CreateGetRequest(System.Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, context);
            Pipeline.Send(message, context.CancellationToken);
            return CreateNullableResponse(message.Response);
        }

        /// <summary>
        /// List private endpoint connection properties
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateEndpointConnections. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<IotHubPrivateEndpointConnectionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return new IotHubPrivateEndpointConnectionResourceAsyncPageable(this, cancellationToken);
        }

        /// <summary>
        /// List private endpoint connection properties
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateEndpointConnections. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
