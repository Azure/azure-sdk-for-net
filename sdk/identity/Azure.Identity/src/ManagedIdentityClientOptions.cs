﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    internal class ManagedIdentityClientOptions
    {
        public TokenCredentialOptions Options { get; set; }

        public ManagedIdentityId ManagedIdentityId { get; set; } = ManagedIdentityId.SystemAssigned;

        public bool PreserveTransport { get; set; }

        public TimeSpan? InitialImdsConnectionTimeout { get; set; }

        public CredentialPipeline Pipeline { get; set; }

        public bool ExcludeTokenExchangeManagedIdentitySource { get; set; }

        // TODO: revert before GA
        public bool EnableManagedIdentityLegacyBehavior { get; set; } = Environment.GetEnvironmentVariable("AZURE_IDENTITY_ENABLE_LEGACY_IMDS_BEHAVIOR") != null;

        public bool IsForceRefreshEnabled { get; set; }
    }
}
