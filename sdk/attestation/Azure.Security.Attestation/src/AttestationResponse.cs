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
    /// Represents a response from an Attestation Service API.
    /// </summary>
    public class AttestationResponse<T> : Response<T>
        where T : class
    {
        private readonly AttestationToken _token;
        private readonly Response _response;
        private readonly T _body;
        private readonly bool _useTokenBody;

        /// <summary>
        /// Represents a response from the Microsoft Azure Attestation service whose value is the body of the token.
        /// </summary>
        /// <param name="response">The underlying response object corresponding to the original request,</param>
        /// <param name="underlyingToken">The attestation token returned from the attestation service.</param>
        internal AttestationResponse(Response response, AttestationToken underlyingToken) : base()
        {
            _response = response;
            _token = underlyingToken;
            _useTokenBody = true;
        }

        /// <summary>
        /// Represents a response from the Microsoft Azure Attestation service.
        /// </summary>
        /// <param name="response">The underlying response object corresponding to the original request,</param>
        /// <param name="underlyingToken">The attestation token returned from the attestation service.</param>
        /// <param name="body">The value of the body of the token to be returned to the customer. A null value is
        /// returned to the caller as-is; it is not read back from the attestation token.</param>
        internal AttestationResponse(Response response, AttestationToken underlyingToken, T body) : base()
        {
            _response = response;
            _token = underlyingToken;
            _body = body;
        }

        /// <summary>
        /// Returns the body of the response. This normally corresponds to the structure returned by the attestation
        /// service.
        /// </summary>
        public override T Value => _useTokenBody ? _token.GetBody<T>() : _body;

        /// <summary>
        /// Returns the raw attestation token returned from the Microsoft Azure Attestation service.
        /// </summary>
        public AttestationToken Token => _token;

        /// <summary>
        /// Returns the underlying <see cref="Response"/> returned from the remote service.
        /// </summary>
        /// <returns>The response returned from the remote service. <see cref="Response"/></returns>
        public override Response GetRawResponse() => _response;
    }
}
