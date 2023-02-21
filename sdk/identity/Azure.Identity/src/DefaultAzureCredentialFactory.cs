// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Azure.Core;

namespace Azure.Identity
{
    internal class DefaultAzureCredentialFactory
    {
        private static readonly TokenCredential[] s_defaultCredentialChain = new DefaultAzureCredentialFactory(new DefaultAzureCredentialOptions()).CreateCredentialChain();
        private bool _useDefaultCredentialChain;

        public DefaultAzureCredentialFactory(DefaultAzureCredentialOptions options)
            : this(options, CredentialPipeline.GetInstance(options))
        { }

        protected DefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, CredentialPipeline pipeline)
        {
            Pipeline = pipeline;

            _useDefaultCredentialChain = options == null;

            Options = options?.Clone<DefaultAzureCredentialOptions>() ?? new DefaultAzureCredentialOptions();
        }

        public DefaultAzureCredentialOptions Options { get; }
        public CredentialPipeline Pipeline { get; }

        public TokenCredential[] CreateCredentialChain()
        {
            if (_useDefaultCredentialChain)
            {
                return s_defaultCredentialChain;
            }

            List<TokenCredential> chain = new(9);

            if (!Options.ExcludeEnvironmentCredential)
            {
                chain.Add(CreateEnvironmentCredential());
            }

            if (!Options.ExcludeManagedIdentityCredential)
            {
                chain.Add(CreateManagedIdentityCredential());
            }

            if (!Options.ExcludeAzureDeveloperCliCredential)
            {
                chain.Add(CreateAzureDeveloperCliCredential());
            }

            if (!Options.ExcludeSharedTokenCacheCredential)
            {
                chain.Add(CreateSharedTokenCacheCredential());
            }

            if (!Options.ExcludeVisualStudioCredential)
            {
                chain.Add(CreateVisualStudioCredential());
            }

            if (!Options.ExcludeVisualStudioCodeCredential)
            {
                chain.Add(CreateVisualStudioCodeCredential());
            }

            if (!Options.ExcludeAzureCliCredential)
            {
                chain.Add(CreateAzureCliCredential());
            }

            if (!Options.ExcludeAzurePowerShellCredential)
            {
                chain.Add(CreateAzurePowerShellCredential());
            }

            if (!Options.ExcludeInteractiveBrowserCredential)
            {
                chain.Add(CreateInteractiveBrowserCredential());
            }

            if (chain.Count == 0)
            {
                throw new ArgumentException("At least one credential type must be included in the authentication flow.", "options");
            }

            return chain.ToArray();
        }

        public virtual TokenCredential CreateEnvironmentCredential()
        {
            var options = Options.Clone<EnvironmentCredentialOptions>();

            return new EnvironmentCredential(Pipeline, options);
        }

        public virtual TokenCredential CreateManagedIdentityCredential()
        {
            return new ManagedIdentityCredential(new ManagedIdentityClient(
                new ManagedIdentityClientOptions
                {
                    ResourceIdentifier = Options.ManagedIdentityResourceId,
                    ClientId = Options.ManagedIdentityClientId,
                    Pipeline = Pipeline,
                    Options = Options,
                    InitialImdsConnectionTimeout = TimeSpan.FromSeconds(1)
                })
            );
        }

        public virtual TokenCredential CreateSharedTokenCacheCredential()
        {
            var options = Options.Clone<SharedTokenCacheCredentialOptions>();

            options.TenantId = Options.SharedTokenCacheTenantId;

            options.Username = Options.SharedTokenCacheUsername;

            return new SharedTokenCacheCredential(Options.SharedTokenCacheTenantId, Options.SharedTokenCacheUsername, options, Pipeline);
        }

        public virtual TokenCredential CreateInteractiveBrowserCredential()
        {
            var options = Options.Clone<InteractiveBrowserCredentialOptions>();

            options.TokenCachePersistenceOptions = new TokenCachePersistenceOptions();

            options.TenantId = Options.InteractiveBrowserTenantId;

            return new InteractiveBrowserCredential(
                Options.InteractiveBrowserTenantId,
                Options.InteractiveBrowserCredentialClientId ?? Constants.DeveloperSignOnClientId,
                options,
                Pipeline);
        }

        public virtual TokenCredential CreateAzureDeveloperCliCredential()
        {
            var options = Options.Clone<AzureDeveloperCliCredentialOptions>();

            options.TenantId = Options.TenantId;

            options.AzdCliProcessTimeout = Options.DeveloperCredentialTimeout;

            return new AzureDeveloperCliCredential(Pipeline, default, options);
        }

        public virtual TokenCredential CreateAzureCliCredential()
        {
            var options = Options.Clone<AzureCliCredentialOptions>();

            options.TenantId = Options.TenantId;

            options.CliProcessTimeout = Options.DeveloperCredentialTimeout;

            return new AzureCliCredential(Pipeline, default, options);
        }

        public virtual TokenCredential CreateVisualStudioCredential()
        {
            var options = Options.Clone<VisualStudioCredentialOptions>();

            options.TenantId = Options.VisualStudioTenantId;

            options.VisualStudioProcessTimeout = Options.DeveloperCredentialTimeout;

            return new VisualStudioCredential(Options.VisualStudioTenantId, Pipeline, default, default, options);
        }

        public virtual TokenCredential CreateVisualStudioCodeCredential()
        {
            var options = Options.Clone<VisualStudioCodeCredentialOptions>();

            options.TenantId = Options.VisualStudioCodeTenantId;

            return new VisualStudioCodeCredential(options, Pipeline, default, default, default);
        }

        public virtual TokenCredential CreateAzurePowerShellCredential()
        {
            var options = Options.Clone<AzurePowerShellCredentialOptions>();

            options.TenantId = Options.TenantId;

            options.PowerShellProcessTimeout = Options.DeveloperCredentialTimeout;

            return new AzurePowerShellCredential(options, Pipeline, default);
        }
    }
}
