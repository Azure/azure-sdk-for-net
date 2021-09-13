// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// </summary>
    public class AzureError
    {
        /// <summary>
        ///
        /// </summary>
        public AzureError()
        {
            Data = new Dictionary<object, object?>();
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Gets an additional data returned with the error response.
        /// </summary>
        public IDictionary<object, object?> Data { get; }
    }
}
