// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure;
using Azure.Core;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a response for an Attestation Service API.
    /// </summary>
    public class AttestationResponse<T> : Response<T>
        where T: class
    {
        private readonly AttestationToken _token;
        private readonly Response _response;

        internal AttestationResponse(Response response, AttestationToken underlyingToken) : base()
        {
            _response = response;
            _token = underlyingToken;
        }

        /// <inheritdoc/>
        public override T Value => _token.GetBody<T>();

        /// <summary>
        /// Returns the raw attestation token returned from the Microsoft Azure Attestation service.
        /// </summary>
        public AttestationToken Token => _token;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;
    }
}
