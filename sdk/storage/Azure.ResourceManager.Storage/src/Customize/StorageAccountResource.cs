// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Adds many method overloads/aliases to preserve prior GA surface:
// - Failover overloads (old FailoverType enum -> new FailoverRequestFailoverType)
// - SAS method casing (GetAccountSas -> GetAccountSAS)
// - GetKeys/RegenerateKey Pageable overloads (old returned Pageable<StorageAccountKey>)
// - GetPrivateLinkResources Pageable overloads
// - RestoreBlobRanges custom LRO returning specialized operation type
// - EnableHierarchicalNamespace (removed from API, throws NotSupportedException)
// Most of these cannot be replaced by spec changes due to return type/parameter type changes.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountResource
    {
        /// <summary> Failover with no failoverType parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> FailoverAsync(WaitUntil waitUntil, CancellationToken cancellationToken) =>
            await FailoverAsync(waitUntil, (FailoverRequestFailoverType?)null, cancellationToken).ConfigureAwait(false);

        /// <summary> Failover with no failoverType parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Failover(WaitUntil waitUntil, CancellationToken cancellationToken) =>
            Failover(waitUntil, (FailoverRequestFailoverType?)null, cancellationToken);

        /// <summary> Failover with StorageAccountFailoverType parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> FailoverAsync(WaitUntil waitUntil, StorageAccountFailoverType? failoverType, CancellationToken cancellationToken) =>
            await FailoverAsync(waitUntil, failoverType.HasValue ? new FailoverRequestFailoverType(failoverType.Value.ToString()) : (FailoverRequestFailoverType?)null, cancellationToken).ConfigureAwait(false);

        /// <summary> Failover with StorageAccountFailoverType parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Failover(WaitUntil waitUntil, StorageAccountFailoverType? failoverType, CancellationToken cancellationToken) =>
            Failover(waitUntil, failoverType.HasValue ? new FailoverRequestFailoverType(failoverType.Value.ToString()) : (FailoverRequestFailoverType?)null, cancellationToken);

        /// <summary> GetAccountSas with old casing. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<GetAccountSasResult> GetAccountSas(AccountSasContent content, CancellationToken cancellationToken = default)
            => GetAccountSAS(content, cancellationToken);

        /// <summary> GetAccountSasAsync with old casing. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<GetAccountSasResult>> GetAccountSasAsync(AccountSasContent content, CancellationToken cancellationToken = default)
            => GetAccountSASAsync(content, cancellationToken);

        /// <summary> GetServiceSas with old casing. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<GetServiceSasResult> GetServiceSas(ServiceSasContent content, CancellationToken cancellationToken = default)
            => GetServiceSAS(content, cancellationToken);

        /// <summary> GetServiceSasAsync with old casing. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<GetServiceSasResult>> GetServiceSasAsync(ServiceSasContent content, CancellationToken cancellationToken = default)
            => GetServiceSASAsync(content, cancellationToken);

        /// <summary> EnableHierarchicalNamespace is not available in this API version. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation EnableHierarchicalNamespace(WaitUntil waitUntil, string requestType, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("EnableHierarchicalNamespace is not supported in this version of the SDK. This operation has been removed from the API.");

        /// <summary> EnableHierarchicalNamespaceAsync is not available in this API version. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> EnableHierarchicalNamespaceAsync(WaitUntil waitUntil, string requestType, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("EnableHierarchicalNamespace is not supported in this version of the SDK. This operation has been removed from the API.");

        /// <summary> Parameterless GetBlobInventoryPolicy. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BlobInventoryPolicyResource GetBlobInventoryPolicy()
            => GetBlobInventoryPolicy(BlobInventoryPolicyName.Default).Value;

        /// <summary> Parameterless GetStorageAccountManagementPolicy. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StorageAccountManagementPolicyResource GetStorageAccountManagementPolicy()
            => GetStorageAccountManagementPolicy(ManagementPolicyName.Default).Value;

        /// <summary> GetStorageTaskAssignmentsInstancesReports renamed to GetAll. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageTaskReportInstance> GetStorageTaskAssignmentsInstancesReports(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAll(maxpagesize, filter, cancellationToken);

        /// <summary> GetStorageTaskAssignmentsInstancesReportsAsync renamed to GetAllAsync. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StorageTaskReportInstance> GetStorageTaskAssignmentsInstancesReportsAsync(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize, filter, cancellationToken);

        // Backward-compat: prior GA returned Pageable<StorageAccountKey> instead of Response<StorageAccountListKeysResult>.

        /// <summary> GetKeys with old StorageListKeyExpand parameter type. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageAccountKey> GetKeys(StorageListKeyExpand? expand, CancellationToken cancellationToken)
        {
            var response = GetKeys(expand.HasValue ? new ListKeysRequestExpand(expand.Value.ToString()) : (ListKeysRequestExpand?)null, cancellationToken);
            return new SinglePagePageable<StorageAccountKey>(response.Value.Keys.ToList(), response.GetRawResponse());
        }

        /// <summary> GetKeysAsync with old StorageListKeyExpand parameter type. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0107 // async call wraps result, no sync alternative available
        public virtual AsyncPageable<StorageAccountKey> GetKeysAsync(StorageListKeyExpand? expand, CancellationToken cancellationToken)
        {
            return new DeferredAsyncPageable<StorageAccountKey>(async () =>
            {
                var response = await GetKeysAsync(expand.HasValue ? new ListKeysRequestExpand(expand.Value.ToString()) : (ListKeysRequestExpand?)null, cancellationToken).ConfigureAwait(false);
                return (response.Value.Keys.ToList(), response.GetRawResponse());
            });
        }
#pragma warning restore AZC0107

        // NOTE: RegenerateKey/RegenerateKeyAsync cannot return Pageable<StorageAccountKey> (prior GA)
        // because the parameter types match the generated methods — only the return type differs,
        // and C# does not allow overloading by return type alone.
        // @@markAsPageable is in client.tsp but the mgmt generator does not support it for action
        // operations (ArmResourceActionSync) with non-standard response shapes — listKeys and
        // regenerateKey return StorageAccountListKeysResult with a "keys" array, not the standard
        // "value" array used by list operations.
        // These 2 violations must remain in the ApiCompat baseline.

        /// <summary> Gets the private link resources that need to be created for a storage account. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StoragePrivateLinkResourceData> GetPrivateLinkResourcesAsync(CancellationToken cancellationToken)
        {
            async Task<Page<StoragePrivateLinkResourceData>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetByStorageAccountAsync(cancellationToken).ConfigureAwait(false);
                return Page<StoragePrivateLinkResourceData>.FromValues(response.Value.Value.ToArray(), null, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Gets the private link resources that need to be created for a storage account. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StoragePrivateLinkResourceData> GetPrivateLinkResources(CancellationToken cancellationToken)
        {
            Page<StoragePrivateLinkResourceData> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetByStorageAccount(cancellationToken);
                return Page<StoragePrivateLinkResourceData>.FromValues(response.Value.Value.ToArray(), null, response.GetRawResponse());
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Restore blobs in the specified blob ranges
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_RestoreBlobRanges</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StorageAccountResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The parameters to provide for restore blob ranges. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<StorageAccountRestoreBlobRangesOperation> RestoreBlobRangesAsync(WaitUntil waitUntil, BlobRestoreContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountsClientDiagnostics.CreateScope("StorageAccountResource.RestoreBlobRanges");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _storageAccountsRestClient.CreateRestoreBlobRangesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, BlobRestoreContent.ToRequestContent(content), context);
                var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var operation = new StorageAccountRestoreBlobRangesOperation(new BlobRestoreStatusOperationSource(), _storageAccountsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
        /// Restore blobs in the specified blob ranges
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_RestoreBlobRanges</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StorageAccountResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The parameters to provide for restore blob ranges. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual StorageAccountRestoreBlobRangesOperation RestoreBlobRanges(WaitUntil waitUntil, BlobRestoreContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountsClientDiagnostics.CreateScope("StorageAccountResource.RestoreBlobRanges");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _storageAccountsRestClient.CreateRestoreBlobRangesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, BlobRestoreContent.ToRequestContent(content), context);
                Pipeline.ProcessMessage(message, context);
                var response = message.Response;
                var operation = new StorageAccountRestoreBlobRangesOperation(new BlobRestoreStatusOperationSource(), _storageAccountsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
