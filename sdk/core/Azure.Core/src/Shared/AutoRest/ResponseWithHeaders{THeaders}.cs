// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core
{
    internal class ResponseWithHeaders<THeaders>
    {
        private readonly Response _rawResponse;

        public ResponseWithHeaders(THeaders headers, Response rawResponse)
        {
            _rawResponse = rawResponse;
            Headers = headers;
        }

        public Response GetRawResponse() => _rawResponse;

        public THeaders Headers { get; }

        public static implicit operator Response(ResponseWithHeaders<THeaders> self) => self.GetRawResponse();
    }
}
