// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure
{
#pragma warning disable SA1649 // File name should match first type name
    internal sealed class NoValueResponse<T> : NullableResponse<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        public NoValueResponse(Response response) : base(default, response)
        {
            Argument.AssertNotNull(response, nameof(response));
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

        public override string ToString()
        {
            return GetStatusMessage();
        }

        internal string GetStatusMessage() => $"Status: {GetRawResponse().Status}, Service returned no content";
    }
}
