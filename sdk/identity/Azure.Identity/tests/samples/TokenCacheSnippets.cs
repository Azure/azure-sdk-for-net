// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity.Samples
{
    public class TokenCacheSnippets
    {
        public void Identity_TokenCache_PersistentDefault()
        {
            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = new PersistentTokenCache() });


        }

        public void Identity_TokenCache_SharedCacheInstance()
        {
            throw new NotImplementedException();
        }

        public void Identity_TokenCache_CustomCachePersistence()
        {
            throw new NotImplementedException();
        }

    }
}
