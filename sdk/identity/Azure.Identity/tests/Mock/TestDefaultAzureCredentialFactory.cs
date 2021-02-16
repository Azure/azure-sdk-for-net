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

        public Func<ManagedIdentitySource> ManagedIdentitySourceFactory { get; set; }

        public override TokenCredential CreateEnvironmentCredential()
            => new EnvironmentCredential(Pipeline);

        public override TokenCredential CreateManagedIdentityCredential(string clientId)
            => new ManagedIdentityCredential(CreateManagedIdentityClient(clientId));

        public override TokenCredential CreateSharedTokenCacheCredential(string tenantId, string username)
            => new SharedTokenCacheCredential(tenantId, username, default, Pipeline);

        public override TokenCredential CreateInteractiveBrowserCredential(string tenantId)
            => new InteractiveBrowserCredential(tenantId, Constants.DeveloperSignOnClientId, new InteractiveBrowserCredentialOptions(), Pipeline);

        public override TokenCredential CreateAzureCliCredential()
            => new AzureCliCredential(Pipeline, _processService);

        public override TokenCredential CreateVisualStudioCredential(string tenantId)
            => new VisualStudioCredential(tenantId, Pipeline, _fileSystem, _processService);

        public override TokenCredential CreateVisualStudioCodeCredential(string tenantId)
            => new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = tenantId }, Pipeline, default, _fileSystem, _vscAdapter);

        private ManagedIdentityClient CreateManagedIdentityClient(string clientId)
            => ManagedIdentitySourceFactory != default
                ? new MockManagedIdentityClient(Pipeline, clientId) { ManagedIdentitySourceFactory = ManagedIdentitySourceFactory }
                : new ManagedIdentityClient(Pipeline, clientId);
    }
}
