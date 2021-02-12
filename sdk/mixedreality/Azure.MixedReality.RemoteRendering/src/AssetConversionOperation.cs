// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// Operation which represents an ongoing conversion operation.
    /// It is returned by StartConversion, but can also be constructed from the id of a preexisting conversion.
    /// </summary>
    public class AssetConversionOperation : Operation<AssetConversion>
    {
        private RemoteRenderingClient _client;
        private Response<AssetConversion> _response;

        /// <summary>
        /// Construct an operation from a conversion which already exists.
        /// </summary>
        /// <param name="conversionId"></param>
        /// <param name="client"></param>
        public AssetConversionOperation(string conversionId, RemoteRenderingClient client)
        {
            _client = client;
            _response = client.GetConversionInternal(conversionId, $"{nameof(AssetConversionOperation)}.{nameof(AssetConversionOperation)}");
        }

        /// <summary>
        /// Internal constructor.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="response"></param>
        internal AssetConversionOperation(RemoteRenderingClient client, Response<AssetConversion> response)
        {
            _client = client;
            _response = response;
        }

        /// <inheritdoc />
        public override string Id => _response.Value.ConversionId;

        /// <inheritdoc />
        public override AssetConversion Value
        {
            get
            {
                return _response.Value;
            }
        }

        /// <inheritdoc />
        public override bool HasCompleted
        {
            get { return (_response.Value.Status != AssetConversionStatus.NotStarted) && (_response.Value.Status != AssetConversionStatus.Running); }
        }

        /// <inheritdoc />
        public override bool HasValue
        {
            get { return true; }
        }

        /// <inheritdoc />
        public override Response GetRawResponse()
        {
            return _response.GetRawResponse();
        }

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                _response = _client.GetConversionInternal(_response.Value.ConversionId, $"{nameof(AssetConversionOperation)}.{nameof(UpdateStatus)}", cancellationToken);
            }
            return _response.GetRawResponse();
        }

        /// <inheritdoc />
        public async override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                _response = await _client.GetConversionInternalAsync(_response.Value.ConversionId, $"{nameof(AssetConversionOperation)}.{nameof(UpdateStatus)}", cancellationToken).ConfigureAwait(false);
            }
            return _response.GetRawResponse();
        }

        /// <inheritdoc />
        public async override ValueTask<Response<AssetConversion>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionAsync(TimeSpan.FromSeconds(10), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async override ValueTask<Response<AssetConversion>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                if (HasCompleted)
                {
                    break;
                }
                await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
            }
            return _response;
        }

        /// <summary> Initializes a new instance of AssetConversionOperation for mocking. </summary>
        protected AssetConversionOperation()
        {
        }
    }
}
