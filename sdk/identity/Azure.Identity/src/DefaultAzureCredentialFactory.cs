// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    internal class DefaultAzureCredentialFactory
    {
        public DefaultAzureCredentialFactory(TokenCredentialOptions options)
            : this(CredentialPipeline.GetInstance(options)) { }

        protected DefaultAzureCredentialFactory(CredentialPipeline pipeline)
        {
            Pipeline = pipeline;
        }

        public CredentialPipeline Pipeline { get; }

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
            return new SharedTokenCacheCredential(tenantId, username, null, Pipeline);
        }

        public virtual TokenCredential CreateInteractiveBrowserCredential(string tenantId)
        {
            return new InteractiveBrowserCredential(tenantId, Constants.DeveloperSignOnClientId, new InteractiveBrowserCredentialOptions { TokenCache = new PersistentTokenCache() }, Pipeline);
        }

        public virtual TokenCredential CreateAzureCliCredential()
        {
            return new AzureCliCredential(Pipeline, default);
        }

        public virtual TokenCredential CreateVisualStudioCredential(string tenantId)
        {
            return new VisualStudioCredential(tenantId, Pipeline, default, default);
        }

        public virtual TokenCredential CreateVisualStudioCodeCredential(string tenantId)
        {
            return new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = tenantId }, Pipeline, default, default, default);
        }
    }
}
