// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.MixedReality.ObjectAnchors
{
    /// <summary> A long running asset conversion process for Object Anchors</summary>
    public class AssetConversionOperation : Operation<AssetConversionProperties>
    {
        private static readonly TimeSpan defaultPollingInterval = TimeSpan.FromSeconds(15);
        private readonly ClientDiagnostics _diagnostics;
        private readonly ObjectAnchorsClient _objectAnchorsClient;
        private readonly Guid _jobId;
        private Response _lastConversionResponse;
        private Response<AssetConversionProperties> _conclusiveConversionResponse;
        private bool _conversionEnded;
        private object _updateStatusLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionOperation"/> class.
        /// You must call <see cref="UpdateStatus(CancellationToken)"/> or <see cref="UpdateStatusAsync(CancellationToken)"/> before you can get the <see cref="Value"/>.
        /// </summary>
        /// <param name="jobId">The ID of this operation.</param>
        /// <param name="objectAnchorsClient">The client used to check for completion.</param>
        public AssetConversionOperation(Guid jobId, ObjectAnchorsClient objectAnchorsClient) : this(jobId, objectAnchorsClient, objectAnchorsClient._clientDiagnostics)
        {
        }

        internal AssetConversionOperation(Guid jobId, ObjectAnchorsClient objectAnchorsClient, ClientDiagnostics diagnostics)
        {
            _objectAnchorsClient = objectAnchorsClient;
            _jobId = jobId;
            _diagnostics = diagnostics;
        }

        /// <inheritdoc/>
        public override string Id => _jobId.ToString();

        /// <inheritdoc/>
        public override AssetConversionProperties Value
        {
            get
            {
                lock (_lastConversionResponse)
                {
                    return OperationHelpers.GetValue(ref _conclusiveConversionResponse);
                }
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => _conversionEnded;

        /// <inheritdoc/>
        public override bool HasValue => _conversionEnded;

        /// <summary> Whether the operation has completed and has a successful final status </summary>
        public bool HasCompletedSuccessfully => HasCompleted && HasValue && (this.Value.ConversionStatus == AssetConversionStatus.Succeeded);

        /// <inheritdoc/>
        public override Response GetRawResponse() => _lastConversionResponse;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(AssetConversionOperation)}.{nameof(UpdateStatusAsync)}");
            scope.Start();

            try
            {
                Response<AssetConversionProperties> updatedStatus = _objectAnchorsClient.GetAssetConversionStatus(_jobId, cancellationToken: cancellationToken);
                lock (_updateStatusLock)
                {
                    _lastConversionResponse = updatedStatus.GetRawResponse();
                    switch (updatedStatus.Value.ConversionStatus)
                    {
                        case AssetConversionStatus.NotStarted:
                        case AssetConversionStatus.Running:
                            _conversionEnded = false;
                            _conclusiveConversionResponse = null;
                            return _lastConversionResponse;
                    }

                    _conversionEnded = true;
                    _conclusiveConversionResponse = updatedStatus;
                    return updatedStatus.GetRawResponse();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public async override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(AssetConversionOperation)}.{nameof(UpdateStatusAsync)}");
            scope.Start();

            try
            {
                Response<AssetConversionProperties> updatedStatus = await _objectAnchorsClient.GetAssetConversionStatusAsync(_jobId, cancellationToken: cancellationToken).ConfigureAwait(false);
                lock (_updateStatusLock)
                {
                    _lastConversionResponse = updatedStatus.GetRawResponse();
                    switch (updatedStatus.Value.ConversionStatus)
                    {
                        case AssetConversionStatus.NotStarted:
                        case AssetConversionStatus.Running:
                            _conversionEnded = false;
                            _conclusiveConversionResponse = null;
                            return _lastConversionResponse;
                    }

                    _conversionEnded = true;
                    _conclusiveConversionResponse = updatedStatus;
                    return updatedStatus.GetRawResponse();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public async override ValueTask<Response<AssetConversionProperties>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionAsync(defaultPollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async override ValueTask<Response<AssetConversionProperties>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            return await OperationHelpers.DefaultWaitForCompletionAsync(this, pollingInterval, cancellationToken).ConfigureAwait(false);
        }
    }
}
