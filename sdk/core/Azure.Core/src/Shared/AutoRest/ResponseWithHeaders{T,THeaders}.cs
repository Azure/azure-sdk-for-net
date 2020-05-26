// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core
{
    internal class ResponseWithHeaders<T, THeaders> : Response<T>
    {
        private readonly Response _rawResponse;

        public ResponseWithHeaders(T value, THeaders headers, Response rawResponse)
        {
            _rawResponse = rawResponse;
            Value = value;
            Headers = headers;
        }

        public override Response GetRawResponse() => _rawResponse;

        public override T Value { get; }

        public THeaders Headers { get; }

        public static implicit operator Response(ResponseWithHeaders<T, THeaders> self) => self.GetRawResponse();
    }
}
