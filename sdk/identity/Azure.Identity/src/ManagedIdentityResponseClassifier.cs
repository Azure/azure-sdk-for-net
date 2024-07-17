// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    internal class ManagedIdentityResponseClassifier : ResponseClassifier
    {
        public override bool IsRetriableResponse(HttpMessage message)
        {
            return message.Response.Status switch
            {
                404 => true,
                410 => true,
                502 => false,
                _ => base.IsRetriableResponse(message)
            };
        }
    }
}
