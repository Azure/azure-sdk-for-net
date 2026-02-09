// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Moq;

namespace Azure.Identity.Tests.Mock
{
    internal class MockDefaultAzureCredentialFactory : DefaultAzureCredentialFactory
    {
        public MockDefaultAzureCredentialFactory(DefaultAzureCredentialOptions options) : base(options) { }
        public MockDefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, CredentialPipeline pipeline) : base(options, pipeline) { }

        public Action<Mock<EnvironmentCredential>> OnCreateEnvironmentCredential { get; set; }
        private Mock<EnvironmentCredential> mockEnvironmentCredential = new();
        public Action<Mock<AzureCliCredential>> OnCreateAzureCliCredential { get; set; }
        private Mock<AzureCliCredential> mockAzureCliCredential = new();
        public Action<Mock<WorkloadIdentityCredential>> OnCreateWorkloadIdentityCredential { get; set; }
        private Mock<WorkloadIdentityCredential> mockWorkloadIdentityCredential = new();
        public Action<Mock<ManagedIdentityCredential>> OnCreateManagedIdentityCredential { get; set; }
        private Mock<ManagedIdentityCredential> mockManagedIdentityCredential = new();
        public Action<Mock<AzureDeveloperCliCredential>> OnCreateAzureDeveloperCliCredential { get; set; }
        private Mock<AzureDeveloperCliCredential> mockAzureDeveloperCliCredential = new();
        public Action<Mock<SharedTokenCacheCredential>> OnCreateSharedTokenCacheCredential { get; set; }
        private Mock<SharedTokenCacheCredential> mockSharedTokenCacheCredential = new();
        public Action<Mock<InteractiveBrowserCredential>> OnCreateInteractiveBrowserCredential { get; set; }
        private Mock<InteractiveBrowserCredential> mockInteractiveBrowserCredential = new();
        public Action<Mock<VisualStudioCredential>> OnCreateVisualStudioCredential { get; set; }
        private Mock<VisualStudioCredential> mockVisualStudioCredential = new();
        public Action<Mock<VisualStudioCodeCredential>> OnCreateVisualStudioCodeCredential { get; set; }
        private Mock<VisualStudioCodeCredential> mockVisualStudioCodeCredential = new();
        public Action<Mock<AzurePowerShellCredential>> OnCreateAzurePowerShellCredential { get; set; }
        private Mock<AzurePowerShellCredential> mockAzurePowershellCredential = new();

        public override TokenCredential CreateEnvironmentCredential()
        {
            OnCreateEnvironmentCredential?.Invoke(mockEnvironmentCredential);
            return mockEnvironmentCredential.Object;
        }

        public override TokenCredential CreateWorkloadIdentityCredential()
        {
            OnCreateWorkloadIdentityCredential?.Invoke(mockWorkloadIdentityCredential);
            return mockWorkloadIdentityCredential.Object;
        }

        public override TokenCredential CreateManagedIdentityCredential(bool isProbeEnabled = true)
        {
            OnCreateManagedIdentityCredential?.Invoke(mockManagedIdentityCredential);
            return mockManagedIdentityCredential.Object;
        }

        public override TokenCredential CreateSharedTokenCacheCredential()
        {
            OnCreateSharedTokenCacheCredential?.Invoke(mockSharedTokenCacheCredential);
            return mockSharedTokenCacheCredential.Object;
        }

        public override TokenCredential CreateAzureDeveloperCliCredential()
        {
            OnCreateAzureDeveloperCliCredential?.Invoke(mockAzureDeveloperCliCredential);
            return mockAzureDeveloperCliCredential.Object;
        }

        public override TokenCredential CreateAzureCliCredential()
        {
            OnCreateAzureCliCredential?.Invoke(mockAzureCliCredential);
            return mockAzureCliCredential.Object;
        }

        public override TokenCredential CreateAzurePowerShellCredential()
        {
            OnCreateAzurePowerShellCredential?.Invoke(mockAzurePowershellCredential);
            return mockAzurePowershellCredential.Object;
        }

        public override TokenCredential CreateInteractiveBrowserCredential()
        {
            OnCreateInteractiveBrowserCredential?.Invoke(mockInteractiveBrowserCredential);
            return mockInteractiveBrowserCredential.Object;
        }

        public override TokenCredential CreateVisualStudioCredential()
        {
            OnCreateVisualStudioCredential?.Invoke(mockVisualStudioCredential);
            return mockVisualStudioCredential.Object;
        }

        public override TokenCredential CreateVisualStudioCodeCredential()
        {
            OnCreateVisualStudioCodeCredential?.Invoke(mockVisualStudioCodeCredential);
            return mockVisualStudioCodeCredential.Object;
        }
    }
}
