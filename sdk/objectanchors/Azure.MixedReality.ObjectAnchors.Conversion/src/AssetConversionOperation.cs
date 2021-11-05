// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// A long running asset conversion process for Object Anchors
    /// </summary>
    public class AssetConversionOperation : Operation<AssetConversionProperties>
    {
        private static readonly TimeSpan defaultPollingInterval = TimeSpan.FromSeconds(15);
        private readonly ObjectAnchorsConversionClient _objectAnchorsConversionClient;
        private readonly Guid _jobId;
        private Response<AssetConversionProperties> _lastConversionResponse;
        private Response<AssetConversionProperties> _conclusiveConversionResponse;
        private bool _conversionEnded;
        private object _updateStatusLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionOperation"/> class.
        /// You must call <see cref="UpdateStatus(CancellationToken)"/> or <see cref="UpdateStatusAsync(CancellationToken)"/> before you can get the <see cref="Value"/>.
        /// </summary>
        /// <param name="jobId">The ID of this operation.</param>
        /// <param name="objectAnchorsConversionClient">The client used to check for completion.</param>
        public AssetConversionOperation(Guid jobId, ObjectAnchorsConversionClient objectAnchorsConversionClient)
        {
            _objectAnchorsConversionClient = objectAnchorsConversionClient;
            _jobId = jobId;
        }

        /// <summary> Initializes a new instance of <see cref="AssetConversionOperation" /> for mocking. </summary>
        protected AssetConversionOperation() {}

        /// <inheritdoc/>
        public override string Id => _jobId.ToString();

        /// <inheritdoc/>
        public override AssetConversionProperties Value
        {
            get
            {
                lock (_updateStatusLock)
                {
                    return OperationHelpers.GetValue(ref _lastConversionResponse);
                }
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => _conversionEnded;

        /// <inheritdoc/>
        public override bool HasValue => _lastConversionResponse != null;

        /// <summary>
        /// Whether the operation has completed and has a successful final status
        /// </summary>
        public bool HasCompletedSuccessfully => HasCompleted && HasValue && (this.Value.ConversionStatus == AssetConversionStatus.Succeeded);

        /// <inheritdoc/>
        public override Response GetRawResponse() => _lastConversionResponse.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            Response<AssetConversionProperties> updatedStatus = _objectAnchorsConversionClient.GetAssetConversionStatus(_jobId, cancellationToken: cancellationToken);
            lock (_updateStatusLock)
            {
                _lastConversionResponse = updatedStatus;
                switch (updatedStatus.Value.ConversionStatus)
                {
                    case AssetConversionStatus.NotStarted:
                    case AssetConversionStatus.Running:
                        _conversionEnded = false;
                        _conclusiveConversionResponse = null;
                        return _lastConversionResponse.GetRawResponse();
                }

                _conversionEnded = true;
                _conclusiveConversionResponse = updatedStatus;
                return updatedStatus.GetRawResponse();
            }
        }

        /// <inheritdoc/>
        public async override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            Response<AssetConversionProperties> updatedStatus = await _objectAnchorsConversionClient.GetAssetConversionStatusAsync(_jobId, cancellationToken: cancellationToken).ConfigureAwait(false);
            lock (_updateStatusLock)
            {
                _lastConversionResponse = updatedStatus;
                switch (updatedStatus.Value.ConversionStatus)
                {
                    case AssetConversionStatus.NotStarted:
                    case AssetConversionStatus.Running:
                        _conversionEnded = false;
                        _conclusiveConversionResponse = null;
                        return _lastConversionResponse.GetRawResponse();
                }

                _conversionEnded = true;
                _conclusiveConversionResponse = updatedStatus;
                return updatedStatus.GetRawResponse();
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
