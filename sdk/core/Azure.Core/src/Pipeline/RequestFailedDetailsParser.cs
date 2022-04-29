// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    public abstract class RequestFailedDetailsParser
    {
        /// <summary>
        /// Parses the error details from the provided <see cref="Response"/>.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns><c>true</c> if successful, otherwise <c>false</c>.</returns>
        public abstract bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data);
    }
}
