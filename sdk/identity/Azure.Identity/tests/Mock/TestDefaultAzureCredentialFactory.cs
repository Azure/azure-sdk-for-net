// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;

namespace Azure.Identity.Tests.Mock
{
    internal class TestDefaultAzureCredentialFactory : DefaultAzureCredentialFactory
    {
        private readonly IFileSystemService _fileSystem;
        private readonly IProcessService _processService;
        private readonly IVisualStudioCodeAdapter _vscAdapter;

        public TestDefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, IFileSystemService fileSystem, IProcessService processService, IVisualStudioCodeAdapter vscAdapter)
            : base(options)
        {
            _fileSystem = fileSystem;
            _processService = processService;
            _vscAdapter = vscAdapter;
        }

        public override TokenCredential CreateEnvironmentCredential()
            => new EnvironmentCredential(Pipeline, Options);

        public override TokenCredential CreateManagedIdentityCredential()
            => new ManagedIdentityCredential(Options.ManagedIdentityClientId, Pipeline, Options);

        public override TokenCredential CreateSharedTokenCacheCredential()
            => new SharedTokenCacheCredential(Options.SharedTokenCacheTenantId, Options.SharedTokenCacheUsername, Options, Pipeline);

        public override TokenCredential CreateInteractiveBrowserCredential()
            => new InteractiveBrowserCredential(Options.InteractiveBrowserTenantId, Options.InteractiveBrowserCredentialClientId ?? Constants.DeveloperSignOnClientId, new InteractiveBrowserCredentialOptions() { AdditionallyAllowedTenantsCore = Options.AdditionallyAllowedTenantsCore, AuthorityHost = Options.AuthorityHost }, Pipeline);

        public override TokenCredential CreateAzureCliCredential()
        {
            var options = new AzureCliCredentialOptions
            {
                TenantId = Options.TenantId,
                AdditionallyAllowedTenantsCore = Options.AdditionallyAllowedTenants.ToList(),
				CliProcessTimeout = Options.DeveloperCredentialTimeout
            };

            return new AzureCliCredential(Pipeline, _processService, options);
        }

        public override TokenCredential CreateAzureDeveloperCliCredential()
        {
            var options = new AzureDeveloperCliCredentialOptions
            {
                TenantId = Options.TenantId,
                AdditionallyAllowedTenantsCore = Options.AdditionallyAllowedTenants.ToList(),
				AzdCliProcessTimeout = Options.DeveloperCredentialTimeout
            };

            return new AzureDeveloperCliCredential(Pipeline, _processService, options);
        }

        public override TokenCredential CreateVisualStudioCredential()
        {
            var options = new VisualStudioCredentialOptions
            {
                TenantId = Options.VisualStudioTenantId,
                AdditionallyAllowedTenantsCore = Options.AdditionallyAllowedTenants.ToList(),
				VisualStudioProcessTimeout = Options.DeveloperCredentialTimeout
            };

            return new VisualStudioCredential(Options.VisualStudioTenantId, Pipeline, _fileSystem, _processService, options);
        }

        public override TokenCredential CreateVisualStudioCodeCredential()
        {
            var options = new VisualStudioCodeCredentialOptions
            {
                TenantId = Options.VisualStudioCodeTenantId,
                AdditionallyAllowedTenantsCore = Options.AdditionallyAllowedTenants.ToList()
            };

            return new VisualStudioCodeCredential(options, Pipeline, default, _fileSystem, _vscAdapter);
        }

        public override TokenCredential CreateAzurePowerShellCredential()
        {
            var options = new AzurePowerShellCredentialOptions
            {
                TenantId = Options.VisualStudioCodeTenantId,
                AdditionallyAllowedTenantsCore = Options.AdditionallyAllowedTenants.ToList(),
				PowerShellProcessTimeout = Options.DeveloperCredentialTimeout
            };

            return new AzurePowerShellCredential(options, Pipeline, _processService);
        }
    }
}
