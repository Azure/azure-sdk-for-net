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

        public void AddExplicitAdditionallyAllowedTenants()
        {
            #region Snippet:Identity_BreakingChanges_AddExplicitAdditionallyAllowedTenants
            var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
            {
                AdditionallyAllowedTenants = { "<tenant_id_1>", "<tenant_id_2>" }
            });
            #endregion
        }

        public void AddAllAdditionallyAllowedTenants()
        {
            #region Snippet:Identity_BreakingChanges_AddAllAdditionallyAllowedTenants
            var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
            {
                AdditionallyAllowedTenants = { "*" }
            });
            #endregion
        }
    }
}
