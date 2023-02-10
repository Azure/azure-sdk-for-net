// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
#pragma warning disable SA1649 // File name should match first type name
    internal sealed class NoValueResponse<T> : NullableResponse<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly Response _response;

        public NoValueResponse(Response response)
        {
            _response = response ?? throw new ArgumentNullException(nameof(response));
        }

        /// <inheritdoc />
        public override bool HasValue => false;

        public override T Value
        {
            get
            {
                throw new InvalidOperationException(GetStatusMessage());
            }
        }

        public override Response GetRawResponse() => _response;

        public override string ToString()
        {
            return GetStatusMessage();
        }

        internal string GetStatusMessage() => $"Status: {GetRawResponse().Status}, Service returned no content";
    }
}
