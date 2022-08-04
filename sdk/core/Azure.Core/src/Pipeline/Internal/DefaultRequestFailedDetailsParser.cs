// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// The default <see cref="RequestFailedDetailsParser"/>.
    /// </summary>
    internal class DefaultRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data) =>
            RequestFailedException.TryExtractErrorContent(response, out error, out data);
    }
}
