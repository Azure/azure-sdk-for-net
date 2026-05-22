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
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage
{
    // Justification: @@markAsPageable(StorageAccounts.regenerateKey) is set in client.tsp but the
    // generator does not emit resource-level RegenerateKey methods (only REST-layer ops). Suppress
    // and reimplement manually to return Pageable<StorageAccountKey> matching prior GA surface.
    [CodeGenSuppress("RegenerateKeyAsync", typeof(StorageAccountRegenerateKeyContent), typeof(CancellationToken))]
    [CodeGenSuppress("RegenerateKey", typeof(StorageAccountRegenerateKeyContent), typeof(CancellationToken))]
    public partial class StorageAccountResource
    {
        // Backward-compatible overload: Failover with no failoverType parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> FailoverAsync(WaitUntil waitUntil, CancellationToken cancellationToken) =>
            await FailoverAsync(waitUntil, (FailoverRequestFailoverType?)null, cancellationToken).ConfigureAwait(false);

        // Backward-compatible overload: Failover with no failoverType parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Failover(WaitUntil waitUntil, CancellationToken cancellationToken) =>
            Failover(waitUntil, (FailoverRequestFailoverType?)null, cancellationToken);

        // Backward-compatible overload: Failover with StorageAccountFailoverType parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> FailoverAsync(WaitUntil waitUntil, StorageAccountFailoverType? failoverType, CancellationToken cancellationToken) =>
            await FailoverAsync(waitUntil, failoverType.HasValue ? new FailoverRequestFailoverType(failoverType.Value.ToString()) : (FailoverRequestFailoverType?)null, cancellationToken).ConfigureAwait(false);

        // Backward-compatible overload: Failover with StorageAccountFailoverType parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Failover(WaitUntil waitUntil, StorageAccountFailoverType? failoverType, CancellationToken cancellationToken) =>
            Failover(waitUntil, failoverType.HasValue ? new FailoverRequestFailoverType(failoverType.Value.ToString()) : (FailoverRequestFailoverType?)null, cancellationToken);

        // Backward-compat: prior GA returned Pageable<StorageAccountKey> instead of Response<StorageAccountListKeysResult>.

        // Backward-compatible overload: GetKeys with old StorageListKeyExpand parameter type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageAccountKey> GetKeys(StorageListKeyExpand? expand, CancellationToken cancellationToken = default)
        {
            var response = GetKeys(expand.HasValue ? new ListKeysRequestExpand(expand.Value.ToString()) : (ListKeysRequestExpand?)null, cancellationToken);
            return new SinglePagePageable<StorageAccountKey>(response.Value.Keys.ToList(), response.GetRawResponse());
        }

        // Backward-compatible parameterless overload for GetKeys.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageAccountKey> GetKeys()
            => GetKeys((StorageListKeyExpand?)null, default);

        // Backward-compatible overload: GetKeysAsync with old StorageListKeyExpand parameter type.
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0107 // async call wraps result, no sync alternative available
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<StorageAccountKey> GetKeysAsync(StorageListKeyExpand? expand, CancellationToken cancellationToken = default)
        {
            return new DeferredAsyncPageable<StorageAccountKey>(async () =>
            {
                var response = await GetKeysAsync(expand.HasValue ? new ListKeysRequestExpand(expand.Value.ToString()) : (ListKeysRequestExpand?)null, cancellationToken).ConfigureAwait(false);
                return (response.Value.Keys.ToList(), response.GetRawResponse());
            });
        }
#pragma warning restore AZC0107

        // Backward-compatible parameterless overload for GetKeysAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0107 // async call wraps result, no sync alternative available
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<StorageAccountKey> GetKeysAsync()
            => GetKeysAsync((StorageListKeyExpand?)null, default);
#pragma warning restore AZC0107

        // Justification: Prior GA returned Pageable<StorageAccountKey>; generated code returns
        // Response<StorageAccountListKeysResult>. Cannot overload by return type alone, so suppress
        // generated methods and replace with Pageable wrappers to preserve backward compatibility.

        /// <summary>
        /// Regenerates one of the access keys or Kerberos keys for the specified storage account.
        /// </summary>
        /// <param name="content"> Specifies name of the key which should be regenerated -- key1, key2, kerb1, kerb2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Pageable<StorageAccountKey> RegenerateKey(StorageAccountRegenerateKeyContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _storageAccountsClientDiagnostics.CreateScope("StorageAccountResource.RegenerateKey");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _storageAccountsRestClient.CreateRegenerateKeyRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, StorageAccountRegenerateKeyContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                var response = StorageAccountListKeysResult.FromResponse(result);
                return new SinglePagePageable<StorageAccountKey>(response.Keys.ToList(), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Regenerates one of the access keys or Kerberos keys for the specified storage account.
        /// </summary>
        /// <param name="content"> Specifies name of the key which should be regenerated -- key1, key2, kerb1, kerb2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0107 // async wrapper with pageable return
        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<StorageAccountKey> RegenerateKeyAsync(StorageAccountRegenerateKeyContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return new DeferredAsyncPageable<StorageAccountKey>(async () =>
            {
                using DiagnosticScope scope = _storageAccountsClientDiagnostics.CreateScope("StorageAccountResource.RegenerateKey");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _storageAccountsRestClient.CreateRegenerateKeyRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, StorageAccountRegenerateKeyContent.ToRequestContent(content), context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    var response = StorageAccountListKeysResult.FromResponse(result);
                    return (response.Keys.ToList(), result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
        }
#pragma warning restore AZC0107

        // Backward-compatible overload: Gets the private link resources that need to be created for a storage account.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<StoragePrivateLinkResourceData> GetPrivateLinkResourcesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<StoragePrivateLinkResourceData>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetByStorageAccountAsync(cancellationToken).ConfigureAwait(false);
                return Page<StoragePrivateLinkResourceData>.FromValues(response.Value.Value.ToArray(), null, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        // Backward-compatible overload: Gets the private link resources that need to be created for a storage account.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<StoragePrivateLinkResourceData> GetPrivateLinkResources(CancellationToken cancellationToken = default)
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
