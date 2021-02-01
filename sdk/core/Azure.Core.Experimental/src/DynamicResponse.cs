// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// Represents a result of Azure operation with a <see cref="DynamicJson"/> response.
    /// </summary>
    public class DynamicResponse : Response<DynamicJson>
    {
        private Response Response { get; }

        /// <inheritdoc />>
        public override DynamicJson Value { get; }

        /// <inheritdoc />
        public override Response GetRawResponse() => Response;

        /// <summary>
        /// Represents a result of Azure operation with a <see cref="DynamicJson"/> response.
        /// </summary>
        /// <param name="response">The response returned by the service.</param>
        /// <param name="value">The value returned by the service.</param>
        public DynamicResponse(Response response, DynamicJson value)
        {
            Response = response;
            Value = value;
        }
    }
}
