// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

// NOTE: The following customization is intentionally retained for backward compatibility.
// There is a spec breaking change which defines a new resource model ProjectCapabilityHost with the similar properties as CapabilityHost for the existing resource operations.
// To avoid breaking existing customers, we are using customization code to reuse the existing data model CognitiveServicesCapabilityHostData for both resources.
// This customization will be removed if service team can align on a single resource model for both resource as before, otherwise it will remain for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    /// <summary>
    /// A class representing a collection of <see cref="CognitiveServicesProjectCapabilityHostResource"/> and their operations.
    /// Each <see cref="CognitiveServicesProjectCapabilityHostResource"/> in the collection will belong to the same instance of <see cref="CognitiveServicesProjectResource"/>.
    /// To get a <see cref="CognitiveServicesProjectCapabilityHostCollection"/> instance call the GetCognitiveServicesProjectCapabilityHosts method from an instance of <see cref="CognitiveServicesProjectResource"/>.
    /// </summary>
    public partial class CognitiveServicesProjectCapabilityHostCollection : ArmCollection, IEnumerable<CognitiveServicesProjectCapabilityHostResource>, IAsyncEnumerable<CognitiveServicesProjectCapabilityHostResource>
    {
        private readonly ClientDiagnostics _projectCapabilityHostsClientDiagnostics;
        private readonly ProjectCapabilityHosts _projectCapabilityHostsRestClient;

        /// <summary> Initializes a new instance of the <see cref="CognitiveServicesProjectCapabilityHostCollection"/> class for mocking. </summary>
        protected CognitiveServicesProjectCapabilityHostCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CognitiveServicesProjectCapabilityHostCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal CognitiveServicesProjectCapabilityHostCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(CognitiveServicesProjectCapabilityHostResource.ResourceType, out string cognitiveServicesProjectCapabilityHostApiVersion);
            _projectCapabilityHostsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.CognitiveServices", CognitiveServicesProjectCapabilityHostResource.ResourceType.Namespace, Diagnostics);
            _projectCapabilityHostsRestClient = new ProjectCapabilityHosts(_projectCapabilityHostsClientDiagnostics, Pipeline, Endpoint, cognitiveServicesProjectCapabilityHostApiVersion ?? "2026-03-01");
            ValidateResourceId(id);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != CognitiveServicesProjectResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, CognitiveServicesProjectResource.ResourceType), nameof(id));
            }
        }

        /// <summary>
        /// Create or update project capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_CreateOrUpdate. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="data"> CapabilityHost definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<CognitiveServicesProjectCapabilityHostResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string capabilityHostName, CognitiveServicesCapabilityHostData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityHostName, nameof(capabilityHostName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, capabilityHostName, CognitiveServicesProjectScopedCapabilityHostData.ToRequestContent(CognitiveServicesCapabilityHostData.ToProjectCapabilityHostData(data)), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CognitiveServicesArmOperation<CognitiveServicesProjectCapabilityHostResource> operation = new CognitiveServicesArmOperation<CognitiveServicesProjectCapabilityHostResource>(
                    new CognitiveServicesProjectCapabilityHostOperationSource(Client),
                    _projectCapabilityHostsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.OriginalUri);
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

        /// <summary>
        /// Create or update project capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_CreateOrUpdate. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="data"> CapabilityHost definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<CognitiveServicesProjectCapabilityHostResource> CreateOrUpdate(WaitUntil waitUntil, string capabilityHostName, CognitiveServicesCapabilityHostData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityHostName, nameof(capabilityHostName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, capabilityHostName, CognitiveServicesProjectScopedCapabilityHostData.ToRequestContent(CognitiveServicesCapabilityHostData.ToProjectCapabilityHostData(data)), context);
                Response response = Pipeline.ProcessMessage(message, context);
                CognitiveServicesArmOperation<CognitiveServicesProjectCapabilityHostResource> operation = new CognitiveServicesArmOperation<CognitiveServicesProjectCapabilityHostResource>(
                    new CognitiveServicesProjectCapabilityHostOperationSource(Client),
                    _projectCapabilityHostsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.OriginalUri);
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

        /// <summary>
        /// Get project capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<CognitiveServicesProjectCapabilityHostResource>> GetAsync(string capabilityHostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityHostName, nameof(capabilityHostName));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, capabilityHostName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<CognitiveServicesCapabilityHostData> response = Response.FromValue(CognitiveServicesCapabilityHostData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new CognitiveServicesProjectCapabilityHostResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get project capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<CognitiveServicesProjectCapabilityHostResource> Get(string capabilityHostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityHostName, nameof(capabilityHostName));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, capabilityHostName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<CognitiveServicesCapabilityHostData> response = Response.FromValue(CognitiveServicesCapabilityHostData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new CognitiveServicesProjectCapabilityHostResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesProjectCapabilityHostResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CognitiveServicesProjectCapabilityHostResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<CognitiveServicesCapabilityHostData, CognitiveServicesProjectCapabilityHostResource>(new OriginalProjectCapabilityHostsGetAllAsyncCollectionResultOfT(
                _projectCapabilityHostsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context,
                "CognitiveServicesProjectCapabilityHostCollection.GetAll"), data => new CognitiveServicesProjectCapabilityHostResource(Client, data));
        }

        /// <summary>
        /// List capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesProjectCapabilityHostResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CognitiveServicesProjectCapabilityHostResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<CognitiveServicesCapabilityHostData, CognitiveServicesProjectCapabilityHostResource>(new OriginalProjectCapabilityHostsGetAllCollectionResultOfT(
                _projectCapabilityHostsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context,
                "CognitiveServicesProjectCapabilityHostCollection.GetAll"), data => new CognitiveServicesProjectCapabilityHostResource(Client, data));
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string capabilityHostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityHostName, nameof(capabilityHostName));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, capabilityHostName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<CognitiveServicesCapabilityHostData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(CognitiveServicesCapabilityHostData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((CognitiveServicesCapabilityHostData)null, result);
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string capabilityHostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityHostName, nameof(capabilityHostName));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, capabilityHostName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<CognitiveServicesCapabilityHostData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(CognitiveServicesCapabilityHostData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((CognitiveServicesCapabilityHostData)null, result);
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<CognitiveServicesProjectCapabilityHostResource>> GetIfExistsAsync(string capabilityHostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityHostName, nameof(capabilityHostName));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, capabilityHostName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<CognitiveServicesCapabilityHostData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(CognitiveServicesCapabilityHostData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((CognitiveServicesCapabilityHostData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<CognitiveServicesProjectCapabilityHostResource>(response.GetRawResponse());
                }
                return Response.FromValue(new CognitiveServicesProjectCapabilityHostResource(Client, response.Value), response.GetRawResponse());
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProjectCapabilityHosts_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<CognitiveServicesProjectCapabilityHostResource> GetIfExists(string capabilityHostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityHostName, nameof(capabilityHostName));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, capabilityHostName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<CognitiveServicesCapabilityHostData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(CognitiveServicesCapabilityHostData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((CognitiveServicesCapabilityHostData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<CognitiveServicesProjectCapabilityHostResource>(response.GetRawResponse());
                }
                return Response.FromValue(new CognitiveServicesProjectCapabilityHostResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<CognitiveServicesProjectCapabilityHostResource> IEnumerable<CognitiveServicesProjectCapabilityHostResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<CognitiveServicesProjectCapabilityHostResource> IAsyncEnumerable<CognitiveServicesProjectCapabilityHostResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
