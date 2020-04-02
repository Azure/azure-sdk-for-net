// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    internal class DefaultAzureCredentialFactory
    {
        public DefaultAzureCredentialFactory(CredentialPipeline pipeline)
        {
            Pipeline = pipeline;
        }

        public virtual CredentialPipeline Pipeline { get; }

        public virtual TokenCredential CreateEnvironmentCredential()
        {
            return new EnvironmentCredential(Pipeline);
        }

        public virtual TokenCredential CreateManagedIdentityCredential(string clientId)
        {
            return new ManagedIdentityCredential(clientId, Pipeline);
        }

        public virtual TokenCredential CreateSharedTokenCacheCredential(string tenantId, string username)
        {
            return new SharedTokenCacheCredential(tenantId, username, Pipeline);
        }

        public virtual TokenCredential CreateInteractiveBrowserCredential(string tenantId)
        {
            return new InteractiveBrowserCredential(tenantId, Constants.DeveloperSignOnClientId, Pipeline);
        }

        public virtual TokenCredential CreateAzureCliCredential()
        {
            return new AzureCliCredential(Pipeline, new AzureCliCredentialClient());
        }
    }
}
