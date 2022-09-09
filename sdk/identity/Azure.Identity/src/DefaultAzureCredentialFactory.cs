// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    internal class DefaultAzureCredentialFactory
    {
        public DefaultAzureCredentialFactory(TokenCredentialOptions options)
            : this(CredentialPipeline.GetInstance(options))
        { }

        protected DefaultAzureCredentialFactory(CredentialPipeline pipeline)
        {
            Pipeline = pipeline;
        }

        public CredentialPipeline Pipeline { get; }

        public virtual TokenCredential CreateEnvironmentCredential()
        {
            return new EnvironmentCredential(Pipeline);
        }

        public virtual TokenCredential CreateManagedIdentityCredential(DefaultAzureCredentialOptions options)
        {
            return new ManagedIdentityCredential(new ManagedIdentityClient(
                new ManagedIdentityClientOptions
                {
                    ResourceIdentifier = options.ManagedIdentityResourceId,
                    ClientId = options.ManagedIdentityClientId,
                    Pipeline = Pipeline,
                    Options = options,
                    InitialImdsConnectionTimeout = TimeSpan.FromSeconds(1)
                })
            );
        }

        public virtual TokenCredential CreateSharedTokenCacheCredential(string tenantId, string username)
        {
            return new SharedTokenCacheCredential(tenantId, username, null, Pipeline);
        }

        public virtual TokenCredential CreateInteractiveBrowserCredential(string tenantId, string clientId)
        {
            return new InteractiveBrowserCredential(
                tenantId,
                clientId ?? Constants.DeveloperSignOnClientId,
                new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = new TokenCachePersistenceOptions() },
                Pipeline);
        }

        public virtual TokenCredential CreateAzureCliCredential(TimeSpan? cliProcessTimeout)
        {
            return new AzureCliCredential(Pipeline, default, new AzureCliCredentialOptions() { CliProcessTimeout = cliProcessTimeout});
        }

        public virtual TokenCredential CreateVisualStudioCredential(string tenantId, TimeSpan? visualStudioProcessTimeout)
        {
            return new VisualStudioCredential(tenantId, Pipeline, default, default, new VisualStudioCredentialOptions() { VisualStudioProcessTimeout = visualStudioProcessTimeout });
        }

        public virtual TokenCredential CreateVisualStudioCodeCredential(string tenantId)
        {
            return new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = tenantId }, Pipeline, default, default, default);
        }

        public virtual TokenCredential CreateAzurePowerShellCredential(TimeSpan? powerShellProcessTimeout)
        {
            return new AzurePowerShellCredential(new AzurePowerShellCredentialOptions() { PowerShellProcessTimeout = powerShellProcessTimeout }, Pipeline, default);
        }
    }
}
