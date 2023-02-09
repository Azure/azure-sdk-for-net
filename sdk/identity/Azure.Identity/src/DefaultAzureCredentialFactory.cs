﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            var options = new EnvironmentCredentialOptions
            {
                AuthorityHost = Options.AuthorityHost,
                DisableInstanceDiscovery = Options.DisableInstanceDiscovery,
            };

            ConfigureAdditionallyAllowedTenants(options);

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
            var options = new SharedTokenCacheCredentialOptions
            {
                AuthorityHost = Options.AuthorityHost,
                DisableInstanceDiscovery = Options.DisableInstanceDiscovery,
                TenantId = Options.SharedTokenCacheTenantId,
                Username = Options.SharedTokenCacheUsername
            };

            ConfigureAdditionallyAllowedTenants(options);

            return new SharedTokenCacheCredential(Options.SharedTokenCacheTenantId, Options.SharedTokenCacheUsername, options, Pipeline);
        }

        public virtual TokenCredential CreateInteractiveBrowserCredential()
        {
            var options = new InteractiveBrowserCredentialOptions
            {
                TokenCachePersistenceOptions = new TokenCachePersistenceOptions(),
                AuthorityHost = Options.AuthorityHost,
                DisableInstanceDiscovery = Options.DisableInstanceDiscovery,
                TenantId = Options.InteractiveBrowserTenantId
            };

            ConfigureAdditionallyAllowedTenants(options);

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

            ConfigureAdditionallyAllowedTenants(options);

            return new AzureDeveloperCliCredential(Pipeline, default, options);
        }

        private void ConfigureAdditionallyAllowedTenants(TokenCredentialOptions options)
        {
            foreach (var additionalTenant in Options.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenantsCore.Add(additionalTenant);
            }
        }

        public virtual TokenCredential CreateAzureCliCredential()
        {
            var options = new AzureCliCredentialOptions
            {
                TenantId = Options.TenantId,
                CliProcessTimeout = Options.DeveloperCredentialTimeout
            };

            ConfigureAdditionallyAllowedTenants(options);

            return new AzureCliCredential(Pipeline, default, options);
        }

        public virtual TokenCredential CreateVisualStudioCredential()
        {
            var options = new VisualStudioCredentialOptions
            {
                TenantId = Options.VisualStudioTenantId,
                VisualStudioProcessTimeout = Options.DeveloperCredentialTimeout
            };

            ConfigureAdditionallyAllowedTenants(options);

            return new VisualStudioCredential(Options.VisualStudioTenantId, Pipeline, default, default, options);
        }

        public virtual TokenCredential CreateVisualStudioCodeCredential()
        {
            var options = new VisualStudioCodeCredentialOptions
            {
                TenantId = Options.VisualStudioCodeTenantId,
            };

            ConfigureAdditionallyAllowedTenants(options);

            return new VisualStudioCodeCredential(options, Pipeline, default, default, default);
        }

        public virtual TokenCredential CreateAzurePowerShellCredential()
        {
            var options = new AzurePowerShellCredentialOptions
            {
                TenantId = Options.VisualStudioCodeTenantId,
                PowerShellProcessTimeout = Options.DeveloperCredentialTimeout
            };

            ConfigureAdditionallyAllowedTenants(options);

            return new AzurePowerShellCredential(options, Pipeline, default);
        }
    }
}
