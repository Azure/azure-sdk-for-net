// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.ConfidentialLedger.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.ConfidentialLedger
{
    [CodeGenSuppress("CreateLedgerEntry", typeof(LedgerEntry), typeof(string), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("CreateLedgerEntryAsync", typeof(LedgerEntry), typeof(string), typeof(string), typeof(bool?), typeof(CancellationToken))]
    public partial class ConfidentialLedgerClient
    {
        /// <summary>
        /// Writes a ledger entry. A collection id may optionally be specified. By default, the operation
        /// returns after local commit; <see cref="LedgerWriteResult.TransactionId"/> is populated from the
        /// <c>x-ms-ccf-transaction-id</c> response header and can be used with <see cref="GetTransactionStatus(string, CancellationToken)"/>
        /// and <see cref="GetReceipt(string, CancellationToken)"/>.
        /// </summary>
        /// <param name="entry"> Ledger entry. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="tags"> Comma separated tags. </param>
        /// <param name="waitForCommit">
        /// Whether to wait for the transaction to be globally committed before
        /// returning. When true, the response includes the transaction receipt, but
        /// a disconnect before the response is received can prevent recovery of the
        /// specific write. Use the default behavior and poll the transaction status
        /// or receipt endpoints when unambiguous per-request recovery is required.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="entry"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<LedgerWriteResult> CreateLedgerEntry(LedgerEntry entry, string collectionId = default, string tags = default, bool? waitForCommit = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entry, nameof(entry));

            Response result = CreateLedgerEntry(entry, collectionId, tags, waitForCommit, cancellationToken.ToRequestContext());
            return Response.FromValue(LedgerWriteResult.FromResponse(result), result);
        }

        /// <summary>
        /// Writes a ledger entry. A collection id may optionally be specified. By default, the operation
        /// returns after local commit; <see cref="LedgerWriteResult.TransactionId"/> is populated from the
        /// <c>x-ms-ccf-transaction-id</c> response header and can be used with <see cref="GetTransactionStatusAsync(string, CancellationToken)"/>
        /// and <see cref="GetReceiptAsync(string, CancellationToken)"/>.
        /// </summary>
        /// <param name="entry"> Ledger entry. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="tags"> Comma separated tags. </param>
        /// <param name="waitForCommit">
        /// Whether to wait for the transaction to be globally committed before
        /// returning. When true, the response includes the transaction receipt, but
        /// a disconnect before the response is received can prevent recovery of the
        /// specific write. Use the default behavior and poll the transaction status
        /// or receipt endpoints when unambiguous per-request recovery is required.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="entry"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<LedgerWriteResult>> CreateLedgerEntryAsync(LedgerEntry entry, string collectionId = default, string tags = default, bool? waitForCommit = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entry, nameof(entry));

            Response result = await CreateLedgerEntryAsync(entry, collectionId, tags, waitForCommit, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue(LedgerWriteResult.FromResponse(result), result);
        }

        /// <summary>
        /// Posts a new entry to the ledger and tracks it until it is committed. The completed operation's
        /// <see cref="Operation{T}.Value"/> is a <see cref="LedgerWriteResult"/> whose
        /// <see cref="LedgerWriteResult.TransactionId"/> identifies the committed transaction.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="entry"> The ledger entry to post. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="tags"> Comma separated tags. </param>
        /// <param name="waitForCommit"> When <see langword="true"/>, the service holds the response until the transaction is globally committed and the returned operation is already completed (no status polling is performed). When <see langword="false"/>, the call returns after local commit and the transaction is tracked via status polling. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="entry"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the operation failed. </exception>
        public virtual Operation<LedgerWriteResult> PostLedgerEntry(
            WaitUntil waitUntil,
            LedgerEntry entry,
            string collectionId = null,
            string tags = null,
            bool waitForCommit = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entry, nameof(entry));

            var operation = (PostLedgerEntryOperation)PostLedgerEntryImpl(waitUntil, entry, collectionId, tags, waitForCommit, cancellationToken.ToRequestContext());
            return new PostLedgerEntryResultOperation(operation, collectionId);
        }

        /// <summary>
        /// Posts a new entry to the ledger and tracks it until it is committed. The completed operation's
        /// <see cref="Operation{T}.Value"/> is a <see cref="LedgerWriteResult"/> whose
        /// <see cref="LedgerWriteResult.TransactionId"/> identifies the committed transaction.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="entry"> The ledger entry to post. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="tags"> Comma separated tags. </param>
        /// <param name="waitForCommit"> When <see langword="true"/>, the service holds the response until the transaction is globally committed and the returned operation is already completed (no status polling is performed). When <see langword="false"/>, the call returns after local commit and the transaction is tracked via status polling. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="entry"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the operation failed. </exception>
        public virtual async Task<Operation<LedgerWriteResult>> PostLedgerEntryAsync(
            WaitUntil waitUntil,
            LedgerEntry entry,
            string collectionId = null,
            string tags = null,
            bool waitForCommit = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entry, nameof(entry));

            var operation = (PostLedgerEntryOperation)await PostLedgerEntryImplAsync(waitUntil, entry, collectionId, tags, waitForCommit, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return new PostLedgerEntryResultOperation(operation, collectionId);
        }

        /// <summary> Adds a user or updates a user's fields using merge-patch semantics; properties left unset are not changed. </summary>
        /// <param name="userId"> The user id, either an AAD object ID or certificate fingerprint. </param>
        /// <param name="user"> Details about a Confidential Ledger user. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="user"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<LedgerUser> CreateOrUpdateUser(string userId, LedgerUser user, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(user, nameof(user));

            Response result = CreateOrUpdateUser(userId, ToMergePatchContent(user), cancellationToken.ToRequestContext());
            return Response.FromValue((LedgerUser)result, result);
        }

        /// <summary> Adds a user or updates a user's fields using merge-patch semantics; properties left unset are not changed. </summary>
        /// <param name="userId"> The user id, either an AAD object ID or certificate fingerprint. </param>
        /// <param name="user"> Details about a Confidential Ledger user. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="user"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<LedgerUser>> CreateOrUpdateUserAsync(string userId, LedgerUser user, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(user, nameof(user));

            Response result = await CreateOrUpdateUserAsync(userId, ToMergePatchContent(user), cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((LedgerUser)result, result);
        }

        /// <summary> Adds a user with multiple roles or updates a user's fields using merge-patch semantics; properties left unset are not changed. </summary>
        /// <param name="userId"> The user id, either an AAD object ID or certificate fingerprint. </param>
        /// <param name="user"> Details about a Confidential Ledger user with multiple roles. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="user"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<LedgerUserMultipleRoles> CreateOrUpdateLedgerUser(string userId, LedgerUserMultipleRoles user, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(user, nameof(user));

            Response result = CreateOrUpdateLedgerUser(userId, ToMergePatchContent(user), cancellationToken.ToRequestContext());
            return Response.FromValue((LedgerUserMultipleRoles)result, result);
        }

        /// <summary> Adds a user with multiple roles or updates a user's fields using merge-patch semantics; properties left unset are not changed. </summary>
        /// <param name="userId"> The user id, either an AAD object ID or certificate fingerprint. </param>
        /// <param name="user"> Details about a Confidential Ledger user with multiple roles. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="user"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<LedgerUserMultipleRoles>> CreateOrUpdateLedgerUserAsync(string userId, LedgerUserMultipleRoles user, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(user, nameof(user));

            Response result = await CreateOrUpdateLedgerUserAsync(userId, ToMergePatchContent(user), cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((LedgerUserMultipleRoles)result, result);
        }

        /// <summary> Updates the JavaScript runtime options using merge-patch semantics; properties left unset are not changed. </summary>
        /// <param name="options"> The runtime options to update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<JsRuntimeOptions> UpdateRuntimeOptionsStable(JsRuntimeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            Response result = UpdateRuntimeOptionsStable(ToMergePatchContent(options), cancellationToken.ToRequestContext());
            return Response.FromValue((JsRuntimeOptions)result, result);
        }

        /// <summary> Updates the JavaScript runtime options using merge-patch semantics; properties left unset are not changed. </summary>
        /// <param name="options"> The runtime options to update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<JsRuntimeOptions>> UpdateRuntimeOptionsStableAsync(JsRuntimeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            Response result = await UpdateRuntimeOptionsStableAsync(ToMergePatchContent(options), cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((JsRuntimeOptions)result, result);
        }

        /// <summary> Updates user defined roles using merge-patch semantics. </summary>
        /// <param name="roles"> The user defined roles to update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roles"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<UserDefinedRoles> UpdateUserDefinedRoleStable(UserDefinedRoles roles, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roles, nameof(roles));

            Response result = UpdateUserDefinedRoleStable(ToMergePatchContent(roles), cancellationToken.ToRequestContext());
            return Response.FromValue((UserDefinedRoles)result, result);
        }

        /// <summary> Updates user defined roles using merge-patch semantics. </summary>
        /// <param name="roles"> The user defined roles to update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roles"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<UserDefinedRoles>> UpdateUserDefinedRoleStableAsync(UserDefinedRoles roles, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roles, nameof(roles));

            Response result = await UpdateUserDefinedRoleStableAsync(ToMergePatchContent(roles), cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((UserDefinedRoles)result, result);
        }

        // Wire-format serialization omits read-only and unset optional properties, which gives the
        // merge-patch semantics the service expects: only the fields set on the model are updated.
        private static RequestContent ToMergePatchContent<T>(T model) where T : System.ClientModel.Primitives.IPersistableModel<T> =>
            RequestContent.Create(model, ModelSerializationExtensions.WireOptions);
    }
}
