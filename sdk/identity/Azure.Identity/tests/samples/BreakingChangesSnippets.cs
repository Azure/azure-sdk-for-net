// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity.Tests.samples
{
    public class BreakingChangesSnippets
    {
        public void SetExcludeSharedTokenCacheCredentialToFalse()
        {
            #region Snippet:Identity_BreakingChanges_SetExcludeSharedTokenCacheCredentialToFalse
            var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
            {
                ExcludeSharedTokenCacheCredential = false
            });
            #endregion
        }
    }
}
