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
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    // This resource is changed to singleton resource, the resource identifier is generated with blobAuditingPolicyName as "default", and the property is hidden from user.
    // Keeping this class for now to avoid breaking change, will remove it in future release.
    /// <summary>
    /// A class representing a collection of <see cref="SqlDatabaseBlobAuditingPolicyResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SqlDatabaseBlobAuditingPolicyCollection : ArmCollection, IEnumerable<SqlDatabaseBlobAuditingPolicyResource>, IAsyncEnumerable<SqlDatabaseBlobAuditingPolicyResource>
    {
        private readonly ClientDiagnostics _databaseBlobAuditingPoliciesClientDiagnostics;
        private readonly DatabaseBlobAuditingPolicies _databaseBlobAuditingPoliciesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SqlDatabaseBlobAuditingPolicyCollection"/> class for mocking. </summary>
        protected SqlDatabaseBlobAuditingPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SqlDatabaseBlobAuditingPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SqlDatabaseBlobAuditingPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _databaseBlobAuditingPoliciesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", SqlDatabaseBlobAuditingPolicyResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SqlDatabaseBlobAuditingPolicyResource.ResourceType, out string sqlDatabaseBlobAuditingPolicyApiVersion);
            _databaseBlobAuditingPoliciesRestClient = new DatabaseBlobAuditingPolicies(_databaseBlobAuditingPoliciesClientDiagnostics, Pipeline, Endpoint, sqlDatabaseBlobAuditingPolicyApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabaseResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabaseResource.ResourceType), nameof(id));
        }

        /// <summary> Creates or updates a database's blob auditing policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="data"> The database blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<SqlDatabaseBlobAuditingPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, BlobAuditingPolicyName blobAuditingPolicyName, SqlDatabaseBlobAuditingPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _databaseBlobAuditingPoliciesClientDiagnostics.CreateScope("SqlDatabaseBlobAuditingPolicyResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _databaseBlobAuditingPoliciesRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", SqlDatabaseBlobAuditingPolicyData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SqlDatabaseBlobAuditingPolicyData> response = Response.FromValue(SqlDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SqlArmOperation<SqlDatabaseBlobAuditingPolicyResource> operation = new SqlArmOperation<SqlDatabaseBlobAuditingPolicyResource>(Response.FromValue(new SqlDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Creates or updates a database's blob auditing policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="data"> The database blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlDatabaseBlobAuditingPolicyResource> CreateOrUpdate(WaitUntil waitUntil, BlobAuditingPolicyName blobAuditingPolicyName, SqlDatabaseBlobAuditingPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _databaseBlobAuditingPoliciesClientDiagnostics.CreateScope("SqlDatabaseBlobAuditingPolicyResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _databaseBlobAuditingPoliciesRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", SqlDatabaseBlobAuditingPolicyData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SqlDatabaseBlobAuditingPolicyData> response = Response.FromValue(SqlDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SqlArmOperation<SqlDatabaseBlobAuditingPolicyResource> operation = new SqlArmOperation<SqlDatabaseBlobAuditingPolicyResource>(Response.FromValue(new SqlDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Gets a database's blob auditing policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SqlDatabaseBlobAuditingPolicyResource>> GetAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseBlobAuditingPoliciesClientDiagnostics.CreateScope("SqlDatabaseBlobAuditingPolicyResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SqlDatabaseBlobAuditingPolicyData> response = Response.FromValue(SqlDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new SqlDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a database's blob auditing policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SqlDatabaseBlobAuditingPolicyResource> Get(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseBlobAuditingPoliciesClientDiagnostics.CreateScope("SqlDatabaseBlobAuditingPolicyResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SqlDatabaseBlobAuditingPolicyData> response = Response.FromValue(SqlDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new SqlDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists auditing settings of a database. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlDatabaseBlobAuditingPolicyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource is changed to singleton resource, the GetAll operation is not supported anymore.");
        }

        /// <summary> Lists auditing settings of a database. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlDatabaseBlobAuditingPolicyResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource is changed to singleton resource, the GetAll operation is not supported anymore.");
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseBlobAuditingPoliciesClientDiagnostics.CreateScope("SqlDatabaseBlobAuditingPolicyResource.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SqlDatabaseBlobAuditingPolicyData> response = Response.FromValue(SqlDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseBlobAuditingPoliciesClientDiagnostics.CreateScope("SqlDatabaseBlobAuditingPolicyResource.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SqlDatabaseBlobAuditingPolicyData> response = Response.FromValue(SqlDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<SqlDatabaseBlobAuditingPolicyResource>> GetIfExistsAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseBlobAuditingPoliciesClientDiagnostics.CreateScope("SqlDatabaseBlobAuditingPolicyResource.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SqlDatabaseBlobAuditingPolicyData> response = Response.FromValue(SqlDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                    return new NoValueResponse<SqlDatabaseBlobAuditingPolicyResource>(response.GetRawResponse());
                return Response.FromValue(new SqlDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SqlDatabaseBlobAuditingPolicyResource> GetIfExists(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _databaseBlobAuditingPoliciesClientDiagnostics.CreateScope("SqlDatabaseBlobAuditingPolicyResource.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _databaseBlobAuditingPoliciesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, "default", context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SqlDatabaseBlobAuditingPolicyData> response = Response.FromValue(SqlDatabaseBlobAuditingPolicyData.FromResponse(result), result);
                if (response.Value == null)
                    return new NoValueResponse<SqlDatabaseBlobAuditingPolicyResource>(response.GetRawResponse());
                return Response.FromValue(new SqlDatabaseBlobAuditingPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SqlDatabaseBlobAuditingPolicyResource> IEnumerable<SqlDatabaseBlobAuditingPolicyResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SqlDatabaseBlobAuditingPolicyResource> IAsyncEnumerable<SqlDatabaseBlobAuditingPolicyResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
