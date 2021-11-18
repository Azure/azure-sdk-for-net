// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    internal class ClientAssertionCredentialOptions : TokenCredentialOptions
    {
        internal CredentialPipeline Pipeline { get; set; }

        internal MsalConfidentialClient MsalClient { get; set; }
    }
}
