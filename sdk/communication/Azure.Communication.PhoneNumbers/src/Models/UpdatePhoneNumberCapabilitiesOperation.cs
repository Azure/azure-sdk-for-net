// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers.Models
{
    [CodeGenModel("PhoneNumbersUpdateCapabilitiesOperation")]
    public partial class UpdatePhoneNumberCapabilitiesOperation
    {
        internal UpdatePhoneNumberCapabilitiesOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<AcquiredPhoneNumber>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "UpdatePhoneNumberCapabilitiesOperation");

            if (response.Headers.TryGetValue<string>("operation-id", out var id))
            {
                Id = id;
            }
        }

        /// <inheritdoc />
        public override string Id { get; }
    }
}
