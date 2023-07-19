// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class ManagedIdentityRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
        {
            data = new Dictionary<string, string>();
            error = null;
            try
            {
                // The response content is buffered at this point.
                string content = response.Content.ToString();

                // Optimistic check for JSON object we expect
                if (content == null || !content.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                var message = ManagedIdentitySource.GetMessageFromResponse(response, false, CancellationToken.None).EnsureCompleted();
                error = new ResponseError(null, message);
                return true;
            }
            catch
            {
                error = new ResponseError(null, ManagedIdentitySource.UnexpectedResponse);
                return true;
            }
        }
    }
}
