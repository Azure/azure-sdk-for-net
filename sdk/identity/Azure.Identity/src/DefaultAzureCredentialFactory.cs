// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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

            Options = options?.ShallowClone() ?? new DefaultAzureCredentialOptions();

            Options.AdditionallyAllowedTenantsCore = Options.AdditionallyAllowedTenants.ToList();
        }

        public DefaultAzureCredentialOptions Options { get; }
        public CredentialPipeline Pipeline { get; }

        public TokenCredential[] CreateCredentialChain()
        {
            if (_useDefaultCredentialChain)
            {
                return s_defaultCredentialChain;
            }

            int i = 0;
            TokenCredential[] chain = new TokenCredential[9];

            if (!Options.ExcludeEnvironmentCredential)
            {
                chain[i++] = CreateEnvironmentCredential();
            }

            if (!Options.ExcludeManagedIdentityCredential)
            {
                chain[i++] = CreateManagedIdentityCredential();
            }

            if (!Options.ExcludeAzureDeveloperCliCredential)
            {
                chain[i++] = CreateAzureDeveloperCliCredential();
            }

            if (!Options.ExcludeSharedTokenCacheCredential)
            {
                chain[i++] = CreateSharedTokenCacheCredential();
            }

            if (!Options.ExcludeVisualStudioCredential)
            {
                chain[i++] = CreateVisualStudioCredential();
            }

            if (!Options.ExcludeVisualStudioCodeCredential)
            {
                chain[i++] = CreateVisualStudioCodeCredential();
            }

            if (!Options.ExcludeAzureCliCredential)
            {
                chain[i++] = CreateAzureCliCredential();
            }

            if (!Options.ExcludeAzurePowerShellCredential)
            {
                chain[i++] = CreateAzurePowerShellCredential();
            }

            if (!Options.ExcludeInteractiveBrowserCredential)
            {
                chain[i++] = CreateInteractiveBrowserCredential();
            }

            if (i == 0)
            {
                throw new ArgumentException("At least one credential type must be included in the authentication flow.", "options");
            }

            return chain;
        }

        public virtual TokenCredential CreateEnvironmentCredential()
        {
            return new EnvironmentCredential(Pipeline, Options);
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
            return new SharedTokenCacheCredential(Options.SharedTokenCacheTenantId, Options.SharedTokenCacheUsername, Options, Pipeline);
        }

        public virtual TokenCredential CreateInteractiveBrowserCredential()
        {
            var options = new InteractiveBrowserCredentialOptions
            {
                TokenCachePersistenceOptions = new TokenCachePersistenceOptions(),
                AuthorityHost = Options.AuthorityHost,
                TenantId = Options.InteractiveBrowserTenantId
            };

            foreach (var addlTenant in Options.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenants.Add(addlTenant);
            }

            return new InteractiveBrowserCredential(
                Options.InteractiveBrowserTenantId,
                Options.InteractiveBrowserCredentialClientId ?? Constants.DeveloperSignOnClientId,
                options,
                Pipeline);
        }

        public virtual TokenCredential CreateAzureDeveloperCliCredential()
        {
            var options = new AzureDeveloperCliCredentialOptions
            {
                TenantId = Options.TenantId,
                AzdCliProcessTimeout = Options.DeveloperCredentialTimeout
            };

            foreach (var additionalTenant in Options.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenants.Add(additionalTenant);
            }

            return new AzureDeveloperCliCredential(Pipeline, default, options);
        }

        public virtual TokenCredential CreateAzureCliCredential()
        {
            var options = new AzureCliCredentialOptions
            {
                TenantId = Options.TenantId,
                CliProcessTimeout = Options.DeveloperCredentialTimeout
            };

            foreach (var addlTenant in Options.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenants.Add(addlTenant);
            }

            return new AzureCliCredential(Pipeline, default, options);
        }

        public virtual TokenCredential CreateVisualStudioCredential()
        {
            var options = new VisualStudioCredentialOptions
            {
                TenantId = Options.VisualStudioTenantId,
                VisualStudioProcessTimeout = Options.DeveloperCredentialTimeout
            };

            foreach (var addlTenant in Options.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenants.Add(addlTenant);
            }

            return new VisualStudioCredential(Options.VisualStudioTenantId, Pipeline, default, default, options);
        }

        public virtual TokenCredential CreateVisualStudioCodeCredential()
        {
            var options = new VisualStudioCodeCredentialOptions
            {
                TenantId = Options.VisualStudioCodeTenantId,
            };

            foreach (var addlTenant in Options.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenants.Add(addlTenant);
            }

            return new VisualStudioCodeCredential(options, Pipeline, default, default, default);
        }

        public virtual TokenCredential CreateAzurePowerShellCredential()
        {
            var options = new AzurePowerShellCredentialOptions
            {
                TenantId = Options.VisualStudioCodeTenantId,
                PowerShellProcessTimeout = Options.DeveloperCredentialTimeout
            };

            foreach (var addlTenant in Options.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenants.Add(addlTenant);
            }

            return new AzurePowerShellCredential(options, Pipeline, default);
        }
    }
}
