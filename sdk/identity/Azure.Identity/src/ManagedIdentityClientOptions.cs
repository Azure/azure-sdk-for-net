// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    internal class ManagedIdentityClientOptions
    {
        public TokenCredentialOptions Options { get; set; }

        public string ClientId { get; set; } = EnvironmentVariables.GetNonEmptyStringOrNull(EnvironmentVariables.ClientId);

        public bool PreserveTransport { get; set; }

        public CredentialPipeline Pipeline { get; set; }
    }
}
