// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.PhoneNumbers.Models;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary> Releases a purchased phone number. </summary>
    public class PurchasePhoneNumbersOperation : Operation<PurchasePhoneNumbersResult>
    {
        private readonly InternalPurchasePhoneNumbersOperation _operation;
        private PurchasePhoneNumbersResult _value;

        internal PurchasePhoneNumbersOperation(InternalPurchasePhoneNumbersOperation operation)
            => _operation = operation;

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override PurchasePhoneNumbersResult Value => _value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            Response response = _operation.UpdateStatus(cancellationToken);
            if (_operation.HasCompleted)
                UpdateFinalResult();
            return response;
        }

        /// <inheritdoc />
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            Response response = await _operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
            if (_operation.HasCompleted)
                UpdateFinalResult();
            return response;
        }

        /// <inheritdoc />
        public override async ValueTask<Response<PurchasePhoneNumbersResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            Response<Response> response = await _operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            UpdateFinalResult();
            return Response.FromValue(_value, response.GetRawResponse());
        }

        /// <inheritdoc />
        public override async ValueTask<Response<PurchasePhoneNumbersResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            Response<Response> response = await _operation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            UpdateFinalResult();
            return Response.FromValue(_value, response.GetRawResponse());
        }

        private void UpdateFinalResult()
            => _value = new PurchasePhoneNumbersResult();
    }
}
