// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    internal class ManagedIdentityClientOptions
    {
        public TokenCredentialOptions Options { get; set; }

        public string ClientId { get; set; }

        public bool PreserveTransport { get; set; }

        public TimeSpan? InitialImdsConnectionTimeout { get; set; }

        public CredentialPipeline Pipeline { get; set; }
    }
}
