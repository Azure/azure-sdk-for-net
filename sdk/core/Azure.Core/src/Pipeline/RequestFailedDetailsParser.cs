// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// Controls how error response content should be parsed.
    /// </summary>
    public abstract class RequestFailedDetailsParser
    {
        /// <summary>
        /// Parses the error details from the provided <see cref="Response"/>.
        /// </summary>
        /// <remarks>
        /// In various scenarios, parsers may be called for successful responses. Implementations should not populate <paramref name="error"/> or <paramref name="data"/> with sensitive information, as these values may be logged as part of the exception.
        /// </remarks>
        /// <param name="response">The <see cref="Response"/> to parse. The <see cref="Response.ContentStream"/> will already be buffered.</param>
        /// <param name="error">The <see cref="ResponseError"/> describing the parsed error details.</param>
        /// <param name="data">Data to be applied to the <see cref="Exception.Data"/> property.</param>
        /// <returns><c>true</c> if successful, otherwise <c>false</c>.</returns>
        public abstract bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data);
    }
}
