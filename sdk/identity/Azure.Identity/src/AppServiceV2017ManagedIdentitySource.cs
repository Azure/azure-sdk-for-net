// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class AppServiceV2017ManagedIdentitySource : AppServiceManagedIdentitySource
    {
        // MSI Constants. Docs for MSI are available here https://docs.microsoft.com/azure/app-service/overview-managed-identity
        protected override string AppServiceMsiApiVersion => "2017-09-01";

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
        {
            (Uri endpointUri, string msiSecret) = AppServiceManagedIdentitySource.ValidateEnvVars();
            if (endpointUri == null || msiSecret == null)
            {
                return null;
            }
            return new AppServiceV2017ManagedIdentitySource(options.Pipeline, endpointUri, msiSecret, options.ClientId);
        }

        private AppServiceV2017ManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string secret,
            string clientId) : base(pipeline, endpoint, secret, clientId)
        { }
    }
}
