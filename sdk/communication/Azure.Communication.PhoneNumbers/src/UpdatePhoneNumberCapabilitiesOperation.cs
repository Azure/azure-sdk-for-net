// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("InternalPhoneNumbersUpdateCapabilitiesOperation")]
    public partial class UpdatePhoneNumberCapabilitiesOperation
    {
        internal UpdatePhoneNumberCapabilitiesOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            var nextLinkOperation = NextLinkOperationImplementation.Create(this, pipeline, request.Method, request.Uri.ToUri(), response, OperationFinalStateVia.LocationOverride);
            _operation = new OperationInternal<PurchasedPhoneNumber>(nextLinkOperation, clientDiagnostics, response, "UpdatePhoneNumberCapabilitiesOperation");

            if (response.Headers.TryGetValue<string>("operation-id", out var id))
            {
                Id = id;
            }
        }

        /// <inheritdoc />
        public override string Id { get; }
    }
}
