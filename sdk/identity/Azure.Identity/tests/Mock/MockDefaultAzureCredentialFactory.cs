// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity.Tests.Mock
{
    internal class MockDefaultAzureCredentialFactory : DefaultAzureCredentialFactory
    {
        public MockDefaultAzureCredentialFactory(CredentialPipeline pipeline) : base(pipeline)
        {
        }

        public Action<IExtendedTokenCredential> OnCreateEnvironmentCredential { get; set; }
        public Action<string, IExtendedTokenCredential> OnCreateManagedIdentityCredential { get; set; }
        public Action<string, IExtendedTokenCredential> OnCreateSharedTokenCacheCredential { get; set; }
        public Action<IExtendedTokenCredential> OnCreateInteractiveBrowserCredential { get; set; }

        public override IExtendedTokenCredential CreateEnvironmentCredential()
        {
            IExtendedTokenCredential cred = new MockExtendedTokenCredential();

            OnCreateEnvironmentCredential?.Invoke(cred);

            return cred;
        }

        public override IExtendedTokenCredential CreateManagedIdentityCredential(string clientId)
        {
            IExtendedTokenCredential cred = new MockExtendedTokenCredential();

            OnCreateManagedIdentityCredential?.Invoke(clientId, cred);

            return cred;
        }

        public override IExtendedTokenCredential CreateSharedTokenCacheCredential(string username)
        {
            IExtendedTokenCredential cred = new MockExtendedTokenCredential();

            OnCreateSharedTokenCacheCredential?.Invoke(username, cred);

            return cred;
        }

        public override IExtendedTokenCredential CreateInteractiveBrowserCredential()
        {
            IExtendedTokenCredential cred = new MockExtendedTokenCredential();

            OnCreateInteractiveBrowserCredential?.Invoke(cred);

            return cred;
        }
    }

}
