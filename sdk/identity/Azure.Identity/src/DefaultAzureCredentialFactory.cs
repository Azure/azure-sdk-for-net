// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity
{
    internal class DefaultAzureCredentialFactory
    {
        public DefaultAzureCredentialFactory(CredentialPipeline pipeline)
        {
            Pipeline = pipeline;
        }

        public virtual CredentialPipeline Pipeline { get; }

        public virtual IExtendedTokenCredential CreateEnvironmentCredential()
        {
            return new EnvironmentCredential(Pipeline);
        }

        public virtual IExtendedTokenCredential CreateManagedIdentityCredential(string clientId)
        {
            return new ManagedIdentityCredential(clientId, Pipeline);
        }

        public virtual IExtendedTokenCredential CreateSharedTokenCacheCredential(string username)
        {
            return new SharedTokenCacheCredential(username, Pipeline);
        }

        public virtual IExtendedTokenCredential CreateInteractiveBrowserCredential()
        {
            return new InteractiveBrowserCredential(null, Constants.DeveloperSignOnClientId, Pipeline);
        }
    }
}
