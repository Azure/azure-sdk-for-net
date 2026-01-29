// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ServiceNetworking
{
    /// <summary>
    /// A class representing a collection of <see cref="FrontendResource"/> and their operations.
    /// Each <see cref="FrontendResource"/> in the collection will belong to the same instance of <see cref="TrafficControllerResource"/>.
    /// To get a <see cref="FrontendCollection"/> instance call the GetFrontends method from an instance of <see cref="TrafficControllerResource"/>.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `TrafficControllerFrontendCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class FrontendCollection : ArmCollection, IEnumerable<FrontendResource>, IAsyncEnumerable<FrontendResource>
    {
        private readonly ClientDiagnostics _frontendFrontendsInterfaceClientDiagnostics;
        private readonly FrontendsInterface _frontendFrontendsInterfaceRestClient;

        /// <summary> Initializes a new instance of the <see cref="FrontendCollection"/> class for mocking. </summary>
        protected FrontendCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FrontendCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FrontendCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _frontendFrontendsInterfaceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ServiceNetworking", FrontendResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FrontendResource.ResourceType, out string frontendFrontendsInterfaceApiVersion);
            _frontendFrontendsInterfaceRestClient = new FrontendsInterface(_frontendFrontendsInterfaceClientDiagnostics, Pipeline, Endpoint, frontendFrontendsInterfaceApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TrafficControllerResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TrafficControllerResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create a Frontend
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FrontendResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string frontendName, FrontendData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(frontendName, nameof(frontendName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _frontendFrontendsInterfaceClientDiagnostics.CreateScope("FrontendCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken };
                var message = _frontendFrontendsInterfaceRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, frontendName, TrafficControllerFrontendData.ToRequestContent(data.ToTrafficControllerFrontendData()), context);
                var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var operation = new ServiceNetworkingArmOperation<FrontendResource>(new FrontendOperationSource(Client), _frontendFrontendsInterfaceClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a Frontend
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FrontendResource> CreateOrUpdate(WaitUntil waitUntil, string frontendName, FrontendData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(frontendName, nameof(frontendName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _frontendFrontendsInterfaceClientDiagnostics.CreateScope("FrontendCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken };
                var message = _frontendFrontendsInterfaceRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, frontendName, TrafficControllerFrontendData.ToRequestContent(data.ToTrafficControllerFrontendData()), context);
                var response = Pipeline.ProcessMessage(message, context);
                var operation = new ServiceNetworkingArmOperation<FrontendResource>(new FrontendOperationSource(Client), _frontendFrontendsInterfaceClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a Frontend
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> is null. </exception>
        public virtual async Task<Response<FrontendResource>> GetAsync(string frontendName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(frontendName, nameof(frontendName));

            using var scope = _frontendFrontendsInterfaceClientDiagnostics.CreateScope("FrontendCollection.Get");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken };
                var message = _frontendFrontendsInterfaceRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, frontendName, context);
                var result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var response = Response.FromValue(TrafficControllerFrontendData.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FrontendResource(Client, new FrontendData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a Frontend
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> is null. </exception>
        public virtual Response<FrontendResource> Get(string frontendName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(frontendName, nameof(frontendName));

            using var scope = _frontendFrontendsInterfaceClientDiagnostics.CreateScope("FrontendCollection.Get");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken };
                var message = _frontendFrontendsInterfaceRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, frontendName, context);
                var result = Pipeline.ProcessMessage(message, context);
                var response = Response.FromValue(TrafficControllerFrontendData.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FrontendResource(Client, new FrontendData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List Frontend resources by TrafficController
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_ListByTrafficController</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FrontendResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FrontendResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<TrafficControllerFrontendData, FrontendResource>(
                new FrontendsInterfaceGetByTrafficControllerAsyncCollectionResultOfT(_frontendFrontendsInterfaceRestClient, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context),
                data => new FrontendResource(Client, new FrontendData(data)));
        }

        /// <summary>
        /// List Frontend resources by TrafficController
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_ListByTrafficController</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FrontendResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FrontendResource> GetAll(CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<TrafficControllerFrontendData, FrontendResource>(
                new FrontendsInterfaceGetByTrafficControllerCollectionResultOfT(_frontendFrontendsInterfaceRestClient, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context),
                data => new FrontendResource(Client, new FrontendData(data)));
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string frontendName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(frontendName, nameof(frontendName));

            using var scope = _frontendFrontendsInterfaceClientDiagnostics.CreateScope("FrontendCollection.Exists");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken };
                var message = _frontendFrontendsInterfaceRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, frontendName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                var result = message.Response;
                Response<TrafficControllerFrontendData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(TrafficControllerFrontendData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((TrafficControllerFrontendData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> is null. </exception>
        public virtual Response<bool> Exists(string frontendName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(frontendName, nameof(frontendName));

            using var scope = _frontendFrontendsInterfaceClientDiagnostics.CreateScope("FrontendCollection.Exists");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken };
                var message = _frontendFrontendsInterfaceRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, frontendName, context);
                Pipeline.Send(message, context.CancellationToken);
                var result = message.Response;
                Response<TrafficControllerFrontendData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(TrafficControllerFrontendData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((TrafficControllerFrontendData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> is null. </exception>
        public virtual async Task<NullableResponse<FrontendResource>> GetIfExistsAsync(string frontendName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(frontendName, nameof(frontendName));

            using var scope = _frontendFrontendsInterfaceClientDiagnostics.CreateScope("FrontendCollection.GetIfExists");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken };
                var message = _frontendFrontendsInterfaceRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, frontendName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                var result = message.Response;
                Response<TrafficControllerFrontendData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(TrafficControllerFrontendData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((TrafficControllerFrontendData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                    return new NoValueResponse<FrontendResource>(response.GetRawResponse());
                return Response.FromValue(new FrontendResource(Client, new FrontendData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> is null. </exception>
        public virtual NullableResponse<FrontendResource> GetIfExists(string frontendName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(frontendName, nameof(frontendName));

            using var scope = _frontendFrontendsInterfaceClientDiagnostics.CreateScope("FrontendCollection.GetIfExists");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken };
                var message = _frontendFrontendsInterfaceRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, frontendName, context);
                Pipeline.Send(message, context.CancellationToken);
                var result = message.Response;
                Response<TrafficControllerFrontendData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(TrafficControllerFrontendData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((TrafficControllerFrontendData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                    return new NoValueResponse<FrontendResource>(response.GetRawResponse());
                return Response.FromValue(new FrontendResource(Client, new FrontendData(response.Value)), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FrontendResource> IEnumerable<FrontendResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FrontendResource> IAsyncEnumerable<FrontendResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
