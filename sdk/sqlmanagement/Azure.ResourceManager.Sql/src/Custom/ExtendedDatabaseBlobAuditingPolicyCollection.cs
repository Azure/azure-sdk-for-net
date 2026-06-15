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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    // This resource is changed to singleton resource, the resource identifier is generated with blobAuditingPolicyName as "default", and the property is hidden from user.
    // Keeping this class for now to avoid breaking change, will remove it in future release.
    /// <summary>
    /// A class representing a collection of <see cref="ExtendedDatabaseBlobAuditingPolicyResource"/> and their operations.
    /// Each <see cref="ExtendedDatabaseBlobAuditingPolicyResource"/> in the collection will belong to the same instance of <see cref="SqlDatabaseResource"/>.
    /// To get an <see cref="ExtendedDatabaseBlobAuditingPolicyCollection"/> instance call the GetExtendedDatabaseBlobAuditingPolicies method from an instance of <see cref="SqlDatabaseResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ExtendedDatabaseBlobAuditingPolicyCollection : ArmCollection, IEnumerable<ExtendedDatabaseBlobAuditingPolicyResource>, IAsyncEnumerable<ExtendedDatabaseBlobAuditingPolicyResource>
    {
        private readonly ClientDiagnostics _extendedDatabaseBlobAuditingPoliciesClientDiagnostics;
        private readonly ExtendedDatabaseBlobAuditingPolicies _extendedDatabaseBlobAuditingPoliciesRestClient;

        /// <summary> Initializes a new instance of the <see cref="ExtendedDatabaseBlobAuditingPolicyCollection"/> class for mocking. </summary>
        protected ExtendedDatabaseBlobAuditingPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ExtendedDatabaseBlobAuditingPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ExtendedDatabaseBlobAuditingPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _extendedDatabaseBlobAuditingPoliciesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ExtendedDatabaseBlobAuditingPolicyResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ExtendedDatabaseBlobAuditingPolicyResource.ResourceType, out string extendedDatabaseBlobAuditingPolicyApiVersion);
            _extendedDatabaseBlobAuditingPoliciesRestClient = new ExtendedDatabaseBlobAuditingPolicies(_extendedDatabaseBlobAuditingPoliciesClientDiagnostics, Pipeline, Endpoint, extendedDatabaseBlobAuditingPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabaseResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabaseResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates an extended database's blob auditing policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="data"> The extended database blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ExtendedDatabaseBlobAuditingPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, BlobAuditingPolicyName blobAuditingPolicyName, ExtendedDatabaseBlobAuditingPolicyData data, CancellationToken cancellationToken = default)
        {
           Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _extendedDatabaseBlobAuditingPoliciesClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicyResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _extendedDatabaseBlobAuditingPoliciesRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", ExtendedDatabaseBlobAuditingPolicyData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ExtendedDatabaseBlobAuditingPolicyData> response = Response.FromValue(ExtendedDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SqlArmOperation<ExtendedDatabaseBlobAuditingPolicyResource> operation = new SqlArmOperation<ExtendedDatabaseBlobAuditingPolicyResource>(Response.FromValue(new ExtendedDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// Creates or updates an extended database's blob auditing policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="data"> The extended database blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ExtendedDatabaseBlobAuditingPolicyResource> CreateOrUpdate(WaitUntil waitUntil, BlobAuditingPolicyName blobAuditingPolicyName, ExtendedDatabaseBlobAuditingPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _extendedDatabaseBlobAuditingPoliciesClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicyResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _extendedDatabaseBlobAuditingPoliciesRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", ExtendedDatabaseBlobAuditingPolicyData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ExtendedDatabaseBlobAuditingPolicyData> response = Response.FromValue(ExtendedDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SqlArmOperation<ExtendedDatabaseBlobAuditingPolicyResource> operation = new SqlArmOperation<ExtendedDatabaseBlobAuditingPolicyResource>(Response.FromValue(new ExtendedDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// Gets an extended database's blob auditing policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ExtendedDatabaseBlobAuditingPolicyResource>> GetAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _extendedDatabaseBlobAuditingPoliciesClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicyResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _extendedDatabaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ExtendedDatabaseBlobAuditingPolicyData> response = Response.FromValue(ExtendedDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ExtendedDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an extended database's blob auditing policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ExtendedDatabaseBlobAuditingPolicyResource> Get(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _extendedDatabaseBlobAuditingPoliciesClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicyResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _extendedDatabaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ExtendedDatabaseBlobAuditingPolicyData> response = Response.FromValue(ExtendedDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ExtendedDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists extended auditing settings of a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_ListByDatabase</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ExtendedDatabaseBlobAuditingPolicyResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ExtendedDatabaseBlobAuditingPolicyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource is changed to singleton resource, the GetAll operation is not supported anymore.");
        }

        /// <summary>
        /// Lists extended auditing settings of a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_ListByDatabase</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ExtendedDatabaseBlobAuditingPolicyResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ExtendedDatabaseBlobAuditingPolicyResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource is changed to singleton resource, the GetAll operation is not supported anymore.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _extendedDatabaseBlobAuditingPoliciesClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicyResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _extendedDatabaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ExtendedDatabaseBlobAuditingPolicyData> response = Response.FromValue(ExtendedDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _extendedDatabaseBlobAuditingPoliciesClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicyResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _extendedDatabaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ExtendedDatabaseBlobAuditingPolicyData> response = Response.FromValue(ExtendedDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<ExtendedDatabaseBlobAuditingPolicyResource>> GetIfExistsAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _extendedDatabaseBlobAuditingPoliciesClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicyResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _extendedDatabaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ExtendedDatabaseBlobAuditingPolicyData> response = Response.FromValue(ExtendedDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                    return new NoValueResponse<ExtendedDatabaseBlobAuditingPolicyResource>(response.GetRawResponse());
                return Response.FromValue(new ExtendedDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExtendedDatabaseBlobAuditingPolicies_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ExtendedDatabaseBlobAuditingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<ExtendedDatabaseBlobAuditingPolicyResource> GetIfExists(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _extendedDatabaseBlobAuditingPoliciesClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicyResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _extendedDatabaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ExtendedDatabaseBlobAuditingPolicyData> response = Response.FromValue(ExtendedDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                    return new NoValueResponse<ExtendedDatabaseBlobAuditingPolicyResource>(response.GetRawResponse());
                return Response.FromValue(new ExtendedDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ExtendedDatabaseBlobAuditingPolicyResource> IEnumerable<ExtendedDatabaseBlobAuditingPolicyResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ExtendedDatabaseBlobAuditingPolicyResource> IAsyncEnumerable<ExtendedDatabaseBlobAuditingPolicyResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
