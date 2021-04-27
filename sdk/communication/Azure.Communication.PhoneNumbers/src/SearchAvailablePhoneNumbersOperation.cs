// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("InternalPhoneNumbersSearchAvailablePhoneNumbersOperation")]
    public partial class SearchAvailablePhoneNumbersOperation
    {
        internal SearchAvailablePhoneNumbersOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<PhoneNumberSearchResult>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "SearchAvailablePhoneNumbersOperation");

            if (response.Headers.TryGetValue<string>("operation-id", out var id))
            {
                Id = id;
            }
        }

        /// <inheritdoc />
        public override string Id { get; }
    }
}
