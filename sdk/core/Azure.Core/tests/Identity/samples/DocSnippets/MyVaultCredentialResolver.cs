// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;

namespace Azure.Core.Tests.Identity.Samples.DocSnippets
{
    #region Snippet:Azure_Core_Samples_AzureClient_CustomCredentialResolver
    public sealed class MyVaultCredentialResolver : CredentialResolver
    {
        public override bool TryResolve(
            IConfigurationSection credentialSection,
            out AuthenticationTokenProvider provider)
        {
            if (credentialSection?["CredentialSource"] is not "MyVaultCredential")
            {
                provider = null;
                return false;
            }

            provider = new MyVaultTokenCredential(credentialSection["VaultUri"]);
            return true;
        }
    }
    #endregion
}
