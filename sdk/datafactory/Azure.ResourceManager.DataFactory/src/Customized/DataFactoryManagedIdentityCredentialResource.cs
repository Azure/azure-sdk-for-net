// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.DataFactory
{
    /// <summary>
    /// A Class representing a DataFactoryManagedIdentityCredential along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="DataFactoryManagedIdentityCredentialResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetDataFactoryManagedIdentityCredentialResource method.
    /// Otherwise you can get one from its parent resource <see cref="DataFactoryResource"/> using the GetDataFactoryManagedIdentityCredential method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DataFactoryManagedIdentityCredentialResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DataFactoryManagedIdentityCredentialResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="factoryName"> The factoryName. </param>
        /// <param name="credentialName"> The credentialName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string credentialName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _dataFactoryManagedIdentityCredentialCredentialOperationsClientDiagnostics;
        private readonly ManagedIdentityCredentialRestOperations _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient;
        private readonly DataFactoryManagedIdentityCredentialData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DataFactory/factories/credentials";

        /// <summary> Initializes a new instance of the <see cref="DataFactoryManagedIdentityCredentialResource"/> class for mocking. </summary>
        protected DataFactoryManagedIdentityCredentialResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DataFactoryManagedIdentityCredentialResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DataFactoryManagedIdentityCredentialResource(ArmClient client, DataFactoryManagedIdentityCredentialData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DataFactoryManagedIdentityCredentialResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DataFactoryManagedIdentityCredentialResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dataFactoryManagedIdentityCredentialCredentialOperationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.DataFactory", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string dataFactoryManagedIdentityCredentialCredentialOperationsApiVersion);
            _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient = new ManagedIdentityCredentialRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dataFactoryManagedIdentityCredentialCredentialOperationsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DataFactoryManagedIdentityCredentialData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a credential.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CredentialOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataFactoryManagedIdentityCredentialResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataFactoryManagedIdentityCredentialResource>> GetAsync(string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _dataFactoryManagedIdentityCredentialCredentialOperationsClientDiagnostics.CreateScope("DataFactoryManagedIdentityCredentialResource.Get");
            scope.Start();
            try
            {
                var response = await _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a credential.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CredentialOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataFactoryManagedIdentityCredentialResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataFactoryManagedIdentityCredentialResource> Get(string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _dataFactoryManagedIdentityCredentialCredentialOperationsClientDiagnostics.CreateScope("DataFactoryManagedIdentityCredentialResource.Get");
            scope.Start();
            try
            {
                var response = _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifNoneMatch, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a credential.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CredentialOperations_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataFactoryManagedIdentityCredentialResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _dataFactoryManagedIdentityCredentialCredentialOperationsClientDiagnostics.CreateScope("DataFactoryManagedIdentityCredentialResource.Delete");
            scope.Start();
            try
            {
                var response = await _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var uri = _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.CreateDeleteRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new DataFactoryArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a credential.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CredentialOperations_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataFactoryManagedIdentityCredentialResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _dataFactoryManagedIdentityCredentialCredentialOperationsClientDiagnostics.CreateScope("DataFactoryManagedIdentityCredentialResource.Delete");
            scope.Start();
            try
            {
                var response = _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var uri = _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.CreateDeleteRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new DataFactoryArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a credential.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CredentialOperations_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataFactoryManagedIdentityCredentialResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Credential resource definition. </param>
        /// <param name="ifMatch"> ETag of the credential entity. Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DataFactoryManagedIdentityCredentialResource>> UpdateAsync(WaitUntil waitUntil, DataFactoryManagedIdentityCredentialData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _dataFactoryManagedIdentityCredentialCredentialOperationsClientDiagnostics.CreateScope("DataFactoryManagedIdentityCredentialResource.Update");
            scope.Start();
            try
            {
                var response = await _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, ifMatch, cancellationToken).ConfigureAwait(false);
                var uri = _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, ifMatch);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new DataFactoryArmOperation<DataFactoryManagedIdentityCredentialResource>(Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Creates or updates a credential.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CredentialOperations_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataFactoryManagedIdentityCredentialResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Credential resource definition. </param>
        /// <param name="ifMatch"> ETag of the credential entity. Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DataFactoryManagedIdentityCredentialResource> Update(WaitUntil waitUntil, DataFactoryManagedIdentityCredentialData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _dataFactoryManagedIdentityCredentialCredentialOperationsClientDiagnostics.CreateScope("DataFactoryManagedIdentityCredentialResource.Update");
            scope.Start();
            try
            {
                var response = _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, ifMatch, cancellationToken);
                var uri = _dataFactoryManagedIdentityCredentialCredentialOperationsRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, ifMatch);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new DataFactoryArmOperation<DataFactoryManagedIdentityCredentialResource>(Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
    }
}
