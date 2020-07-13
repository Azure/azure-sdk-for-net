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
            return new EnvironmentCredential(new TokenCredentialOptions { Pipeline = Pipeline });
        }

        public virtual TokenCredential CreateManagedIdentityCredential(string clientId)
        {
            return new ManagedIdentityCredential(new ManagedIdentityCredentialOptions { ClientId = clientId, Pipeline = Pipeline });
        }

        public virtual TokenCredential CreateSharedTokenCacheCredential(string tenantId, string username)
        {
            return new SharedTokenCacheCredential(new SharedTokenCacheCredentialOptions { TenantId = tenantId, Username = username, Pipeline = Pipeline });
        }

        public virtual TokenCredential CreateInteractiveBrowserCredential(string tenantId)
        {
            return new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TenantId = tenantId, Pipeline = Pipeline, EnablePersistentCache = true });
        }

        public virtual TokenCredential CreateAzureCliCredential()
        {
            return new AzureCliCredential(Pipeline, default);
        }

        public virtual TokenCredential CreateVisualStudioCredential(string tenantId)
        {
            return new VisualStudioCredential(new VisualStudioCredentialOptions { TenantId = tenantId, Pipeline = Pipeline });
        }

        public virtual TokenCredential CreateVisualStudioCodeCredential(string tenantId)
        {
            return new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = tenantId, Pipeline = Pipeline });
        }
    }
}
