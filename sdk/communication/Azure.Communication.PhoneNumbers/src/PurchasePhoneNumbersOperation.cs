﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary> Releases a purchased phone number. </summary>
    public class PurchasePhoneNumbersOperation : Operation
    {
        private readonly InternalPurchasePhoneNumbersOperation _operation;

        internal PurchasePhoneNumbersOperation(InternalPurchasePhoneNumbersOperation operation)
            => _operation = operation;

        /// <summary> Initializes a new instance of <see cref="PurchasePhoneNumbersOperation" /> for mocking. </summary>
        protected PurchasePhoneNumbersOperation() {}

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => await _operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override async ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
        {
            Response response = await _operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc />
        public override async ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            Response response = await _operation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

            return response;
        }
    }
}
