// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("InternalPhoneNumbersPurchaseReservationOperation")]
    internal partial class InternalPurchaseReservationOperation
    {
        internal InternalPurchaseReservationOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            var nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, OperationFinalStateVia.Location);
            _operation = new OperationInternal(nextLinkOperation, clientDiagnostics, response, "PurchasePhoneNumbersOperation");

            if (response.Headers.TryGetValue<string>("operation-id", out var id))
            {
                Id = id;
            }
        }
        /// <inheritdoc />
        public override string Id { get; }
    }
}
