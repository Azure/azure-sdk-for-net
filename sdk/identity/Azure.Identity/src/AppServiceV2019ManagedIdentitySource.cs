// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    internal class AppServiceV2019ManagedIdentitySource : AppServiceManagedIdentitySource
    {
        protected override string AppServiceMsiApiVersion => "2019-08-01";
        protected override string SecretHeaderName => "X-IDENTITY-HEADER";
        protected override string ClientIdHeaderName => "client_id";

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
        {
            var msiSecret = EnvironmentVariables.IdentityHeader;
            return TryValidateEnvVars(EnvironmentVariables.IdentityEndpoint, msiSecret, out Uri endpointUri)
                ? new AppServiceV2019ManagedIdentitySource(options.Pipeline, endpointUri, msiSecret, options)
                : null;
        }

        private AppServiceV2019ManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string secret,
            ManagedIdentityClientOptions options) : base(pipeline, endpoint, secret, options)
        {
        }
    }
}
