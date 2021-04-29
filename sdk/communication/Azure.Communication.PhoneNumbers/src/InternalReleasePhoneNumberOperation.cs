﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("InternalPhoneNumbersReleasePhoneNumberOperation")]
    internal partial class InternalReleasePhoneNumberOperation
    {
        internal InternalReleasePhoneNumberOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<Response>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "ReleasePhoneNumberOperation");

            if (response.Headers.TryGetValue<string>("operation-id", out var id))
            {
                Id = id;
            }
        }

        /// <inheritdoc />
        public override string Id { get; }
    }
}
