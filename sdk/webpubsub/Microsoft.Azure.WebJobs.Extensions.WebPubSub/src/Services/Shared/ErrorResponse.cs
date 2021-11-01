// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core
{
    internal class ErrorResponse<T> : Response<T>
    {
        private readonly Response _response;
        private readonly RequestFailedException _exception;

        public ErrorResponse(Response response, RequestFailedException exception)
        {
            _response = response;
            _exception = exception;
        }

        public override T Value { get => throw _exception; }

        public override Response GetRawResponse() => _response;
    }
}
