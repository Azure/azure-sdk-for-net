// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics;
#pragma warning restore format
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
    /// A Class representing a CognitiveServicesProjectCapabilityHost along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="CognitiveServicesProjectCapabilityHostResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetCognitiveServicesProjectCapabilityHostResource method.
    /// Otherwise you can get one from its parent resource <see cref="CognitiveServicesProjectResource"/> using the GetCognitiveServicesProjectCapabilityHost method.
    /// </summary>
    public partial class CognitiveServicesProjectCapabilityHostResource : ArmResource
    {
        private readonly ClientDiagnostics _projectCapabilityHostsClientDiagnostics;
        private readonly ProjectCapabilityHosts _projectCapabilityHostsRestClient;
        private readonly CognitiveServicesCapabilityHostData _data;
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.CognitiveServices/accounts/projects/capabilityHosts";

        /// <summary> Initializes a new instance of CognitiveServicesProjectCapabilityHostResource for mocking. </summary>
        protected CognitiveServicesProjectCapabilityHostResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CognitiveServicesProjectCapabilityHostResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal CognitiveServicesProjectCapabilityHostResource(ArmClient client, CognitiveServicesCapabilityHostData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of <see cref="CognitiveServicesProjectCapabilityHostResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal CognitiveServicesProjectCapabilityHostResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string cognitiveServicesProjectCapabilityHostApiVersion);
            _projectCapabilityHostsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.CognitiveServices", ResourceType.Namespace, Diagnostics);
            _projectCapabilityHostsRestClient = new ProjectCapabilityHosts(_projectCapabilityHostsClientDiagnostics, Pipeline, Endpoint, cognitiveServicesProjectCapabilityHostApiVersion ?? "2026-03-01");
            ValidateResourceId(id);
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual CognitiveServicesCapabilityHostData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }
                return _data;
            }
        }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="accountName"> The accountName. </param>
        /// <param name="projectName"> The projectName. </param>
        /// <param name="capabilityHostName"> The capabilityHostName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string projectName, string capabilityHostName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="CognitiveServicesProjectCapabilityHostResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CognitiveServicesProjectCapabilityHostResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="CognitiveServicesProjectCapabilityHostResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CognitiveServicesProjectCapabilityHostResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
        /// Delete project capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProjectCapabilityHosts_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CognitiveServicesProjectCapabilityHostResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CognitiveServicesArmOperation operation = new CognitiveServicesArmOperation(_projectCapabilityHostsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
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
        /// Delete project capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProjectCapabilityHosts_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CognitiveServicesProjectCapabilityHostResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                CognitiveServicesArmOperation operation = new CognitiveServicesArmOperation(_projectCapabilityHostsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
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
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProjectCapabilityHosts_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CognitiveServicesProjectCapabilityHostResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> CapabilityHost definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<CognitiveServicesProjectCapabilityHostResource>> UpdateAsync(WaitUntil waitUntil, CognitiveServicesCapabilityHostData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, CognitiveServicesProjectScopedCapabilityHostData.ToRequestContent(CognitiveServicesCapabilityHostData.ToProjectCapabilityHostData(data)), context);
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
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProjectCapabilityHosts_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CognitiveServicesProjectCapabilityHostResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> CapabilityHost definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<CognitiveServicesProjectCapabilityHostResource> Update(WaitUntil waitUntil, CognitiveServicesCapabilityHostData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _projectCapabilityHostsClientDiagnostics.CreateScope("CognitiveServicesProjectCapabilityHostResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _projectCapabilityHostsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, CognitiveServicesProjectScopedCapabilityHostData.ToRequestContent(CognitiveServicesCapabilityHostData.ToProjectCapabilityHostData(data)), context);
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
    }
}
