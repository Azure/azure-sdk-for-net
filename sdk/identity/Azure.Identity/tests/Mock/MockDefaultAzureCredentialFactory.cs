// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity.Tests.Mock
{
    internal class MockDefaultAzureCredentialFactory : DefaultAzureCredentialFactory
    {
        public MockDefaultAzureCredentialFactory(CredentialPipeline pipeline) : base(pipeline) {}

        public Action<TokenCredential> OnCreateEnvironmentCredential { get; set; }
        public Action<TokenCredential> OnCreateAzureCliCredential { get; set; }
        public Action<string, TokenCredential> OnCreateManagedIdentityCredential { get; set; }
        public Action<string, string, TokenCredential> OnCreateSharedTokenCacheCredential { get; set; }
        public Action<string, TokenCredential> OnCreateInteractiveBrowserCredential { get; set; }
        public Action<string, TokenCredential> OnCreateVisualStudioCredential { get; set; }
        public Action<string, TokenCredential> OnCreateVisualStudioCodeCredential { get; set; }

        public override TokenCredential CreateEnvironmentCredential()
        {
            TokenCredential cred = new MockTokenCredential();

            OnCreateEnvironmentCredential?.Invoke(cred);

            return cred;
        }

        public override TokenCredential CreateManagedIdentityCredential(string clientId)
        {
            TokenCredential cred = new MockTokenCredential();

            OnCreateManagedIdentityCredential?.Invoke(clientId, cred);

            return cred;
        }

        public override TokenCredential CreateSharedTokenCacheCredential(string tenantId, string username)
        {
            TokenCredential cred = new MockTokenCredential();

            OnCreateSharedTokenCacheCredential?.Invoke(tenantId, username, cred);

            return cred;
        }

        public override TokenCredential CreateAzureCliCredential()
        {
            TokenCredential cred = new MockTokenCredential();

            OnCreateAzureCliCredential?.Invoke(cred);

            return cred;
        }

        public override TokenCredential CreateInteractiveBrowserCredential(string tenantId)
        {
            TokenCredential cred = new MockTokenCredential();

            OnCreateInteractiveBrowserCredential?.Invoke(tenantId, cred);

            return cred;
        }

        public override TokenCredential CreateVisualStudioCredential(string tenantId)
        {
            TokenCredential cred = new MockTokenCredential();

            OnCreateVisualStudioCredential?.Invoke(tenantId, cred);

            return cred;
        }

        public override TokenCredential CreateVisualStudioCodeCredential(string tenantId)
        {
            TokenCredential cred = new MockTokenCredential();

            OnCreateVisualStudioCodeCredential?.Invoke(tenantId, cred);

            return cred;
        }
    }
}
