// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity.Tests.Mock
{
    internal class TestDefaultAzureCredentialFactory : DefaultAzureCredentialFactory
    {
        private readonly IFileSystemService _fileSystem;
        private readonly IProcessService _processService;
        private readonly IVisualStudioCodeAdapter _vscAdapter;

        public TestDefaultAzureCredentialFactory(TokenCredentialOptions options, IFileSystemService fileSystem, IProcessService processService, IVisualStudioCodeAdapter vscAdapter)
            : base(options)
        {
            _fileSystem = fileSystem;
            _processService = processService;
            _vscAdapter = vscAdapter;
        }

        public override TokenCredential CreateEnvironmentCredential()
            => new EnvironmentCredential(Pipeline);

        public override TokenCredential CreateManagedIdentityCredential(DefaultAzureCredentialOptions options)
            => new ManagedIdentityCredential(new ManagedIdentityClient(Pipeline, options.ManagedIdentityClientId));

        public override TokenCredential CreateSharedTokenCacheCredential(string tenantId, string username)
            => new SharedTokenCacheCredential(tenantId, username, null, Pipeline);

        public override TokenCredential CreateInteractiveBrowserCredential(string tenantId, string clientId)
            => new InteractiveBrowserCredential(tenantId, clientId ?? Constants.DeveloperSignOnClientId, new InteractiveBrowserCredentialOptions(), Pipeline);

        public override TokenCredential CreateAzureCliCredential(TimeSpan? cliProcessTimeout)
            => new AzureCliCredential(Pipeline, _processService, new AzureCliCredentialOptions() { CliProcessTimeout = cliProcessTimeout});

        public override TokenCredential CreateVisualStudioCredential(string tenantId, TimeSpan? visualStudioProcessTimeout)
            => new VisualStudioCredential(tenantId, Pipeline, _fileSystem, _processService, new VisualStudioCredentialOptions() { VisualStudioProcessTimeout = visualStudioProcessTimeout});

        public override TokenCredential CreateVisualStudioCodeCredential(string tenantId)
            => new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = tenantId }, Pipeline, default, _fileSystem, _vscAdapter);

        public override TokenCredential CreateAzurePowerShellCredential(TimeSpan? powershellProcessTimeout)
            => new AzurePowerShellCredential(new AzurePowerShellCredentialOptions() { PowerShellProcessTimeout = powershellProcessTimeout}, Pipeline, _processService);
    }
}
