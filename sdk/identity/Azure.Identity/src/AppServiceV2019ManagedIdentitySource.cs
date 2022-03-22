// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class AppServiceV2019ManagedIdentitySource : AppServiceManagedIdentitySource
    {
        protected override string AppServiceMsiApiVersion => "2019-08-01";

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
        {
            (Uri endpointUri, string msiSecret) = AppServiceManagedIdentitySource.ValidateEnvVars();
            if (endpointUri == null || msiSecret == null)
            {
                return null;
            }
            return new AppServiceV2019ManagedIdentitySource(options.Pipeline, endpointUri, msiSecret, options.ClientId);
        }

        protected AppServiceV2019ManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string secret,
            string clientId) : base(pipeline, endpoint, secret, clientId)
        { }
    }
}
