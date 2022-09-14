// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Moq;

namespace Azure.Identity.Tests.Mock
{
    internal class MockDefaultAzureCredentialFactory : DefaultAzureCredentialFactory
    {
        public MockDefaultAzureCredentialFactory(CredentialPipeline pipeline) : base(pipeline) { }

        public Action<Mock<EnvironmentCredential>> OnCreateEnvironmentCredential { get; set; }
        private Mock<EnvironmentCredential> mockEnvironmentCredential = new();
        public Action<TimeSpan?, Mock<AzureCliCredential>> OnCreateAzureCliCredential { get; set; }
        private Mock<AzureCliCredential> mockAzureCliCredential = new();
        public Action<DefaultAzureCredentialOptions, Mock<ManagedIdentityCredential>> OnCreateManagedIdentityCredential { get; set; }
        private Mock<ManagedIdentityCredential> mockManagedIdentityCredential = new();
        public Action<string, string, Mock<SharedTokenCacheCredential>> OnCreateSharedTokenCacheCredential { get; set; }
        private Mock<SharedTokenCacheCredential> mockSharedTokenCacheCredential = new();
        public Action<string, string, Mock<InteractiveBrowserCredential>> OnCreateInteractiveBrowserCredential { get; set; }
        private Mock<InteractiveBrowserCredential> mockInteractiveBrowserCredential = new();
        public Action<string, TimeSpan?, Mock<VisualStudioCredential>> OnCreateVisualStudioCredential { get; set; }
        private Mock<VisualStudioCredential> mockVisualStudioCredential = new();
        public Action<string, Mock<VisualStudioCodeCredential>> OnCreateVisualStudioCodeCredential { get; set; }
        private Mock<VisualStudioCodeCredential> mockVisualStudioCodeCredential = new();
        public Action<TimeSpan?, Mock<AzurePowerShellCredential>> OnCreateAzurePowerShellCredential { get; set; }
        private Mock<AzurePowerShellCredential> mockAzurePowershellCredential = new();

        public override TokenCredential CreateEnvironmentCredential()
        {
            OnCreateEnvironmentCredential?.Invoke(mockEnvironmentCredential);
            return mockEnvironmentCredential.Object;
        }

        public override TokenCredential CreateManagedIdentityCredential(DefaultAzureCredentialOptions options)
        {
            OnCreateManagedIdentityCredential?.Invoke(options, mockManagedIdentityCredential);
            return mockManagedIdentityCredential.Object;
        }

        public override TokenCredential CreateSharedTokenCacheCredential(string tenantId, string username)
        {
            OnCreateSharedTokenCacheCredential?.Invoke(tenantId, username, mockSharedTokenCacheCredential);
            return mockSharedTokenCacheCredential.Object;
        }

        public override TokenCredential CreateAzureCliCredential(TimeSpan? cliProcessTimeout)
        {
            OnCreateAzureCliCredential?.Invoke(cliProcessTimeout, mockAzureCliCredential);
            return mockAzureCliCredential.Object;
        }

        public override TokenCredential CreateAzurePowerShellCredential(TimeSpan? powershellProcesTimeout)
        {
            OnCreateAzurePowerShellCredential?.Invoke(powershellProcesTimeout, mockAzurePowershellCredential);
            return mockAzurePowershellCredential.Object;
        }

        public override TokenCredential CreateInteractiveBrowserCredential(string tenantId, string clientId)
        {
            OnCreateInteractiveBrowserCredential?.Invoke(tenantId, clientId, mockInteractiveBrowserCredential);
            return mockInteractiveBrowserCredential.Object;
        }

        public override TokenCredential CreateVisualStudioCredential(string tenantId, TimeSpan? visualStudioProcessTimeout)
        {
            OnCreateVisualStudioCredential?.Invoke(tenantId, visualStudioProcessTimeout, mockVisualStudioCredential);
            return mockVisualStudioCredential.Object;
        }

        public override TokenCredential CreateVisualStudioCodeCredential(string tenantId)
        {
            OnCreateVisualStudioCodeCredential?.Invoke(tenantId, mockVisualStudioCodeCredential);
            return mockVisualStudioCodeCredential.Object;
        }
    }
}
