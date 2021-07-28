// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure
{
    internal class NullableValueResponse<T> : NullableResponse<T>
        where T: class
    {
        private readonly Response _response;

        public NullableValueResponse(Response response, T value)
        {
            _response = response;
            Value = value;
            HasValue = value is not null;
        }

        public override T Value { get; }

        public override bool HasValue { get; }

        public override Response GetRawResponse() => _response;
    }
}
