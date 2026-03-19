// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary> A class representing the specific long-running operation StorageAccountRestoreBlobRangesOperation. </summary>
    public class StorageAccountRestoreBlobRangesOperation : ArmOperation<BlobRestoreStatus>
    {
        private readonly StorageArmOperation<BlobRestoreStatus> _operation;

        private readonly IOperationSource<BlobRestoreStatus> _operationSource;

        private readonly AsyncLockWithValue<BlobRestoreStatus> _stateLock;

        private readonly Response _interimResponse;

        /// <summary> Initializes a new instance of StorageAccountRestoreBlobRangesOperation for mocking. </summary>
        protected StorageAccountRestoreBlobRangesOperation()
        {
        }

        internal StorageAccountRestoreBlobRangesOperation(IOperationSource<BlobRestoreStatus> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia)
        {
            _operation = new StorageArmOperation<BlobRestoreStatus>(source, clientDiagnostics, pipeline, request, response, finalStateVia);
            _operationSource = source;
            _stateLock = new AsyncLockWithValue<BlobRestoreStatus>();
            _interimResponse = response;
        }

        /// <inheritdoc />
#pragma warning disable CA1822
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override BlobRestoreStatus Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response<BlobRestoreStatus> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<BlobRestoreStatus> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<BlobRestoreStatus>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<BlobRestoreStatus>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary> Gets interim status of the long-running operation. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The interim status of the long-running operation. </returns>
        public virtual async ValueTask<BlobRestoreStatus> GetCurrentStatusAsync(CancellationToken cancellationToken = default) => await GetCurrentState(true, cancellationToken).ConfigureAwait(false);

        /// <summary> Gets interim status of the long-running operation. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The interim status of the long-running operation. </returns>
        public virtual BlobRestoreStatus GetCurrentStatus(CancellationToken cancellationToken = default) => GetCurrentState(false, cancellationToken).EnsureCompleted();

        private async ValueTask<BlobRestoreStatus> GetCurrentState(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _stateLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }
            var val = async ? await _operationSource.CreateResultAsync(_interimResponse, cancellationToken).ConfigureAwait(false)
                    : _operationSource.CreateResult(_interimResponse, cancellationToken);
            asyncLock.SetValue(val);
            return val;
        }
    }
}
