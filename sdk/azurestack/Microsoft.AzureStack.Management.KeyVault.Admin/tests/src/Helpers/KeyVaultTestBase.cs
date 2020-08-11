// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.KeyVault.Admin;
using Xunit;

namespace KeyVault.Tests
{

    public class KeyVaultTestBase : AzureStackTestBase<KeyVaultAdminClient>
    {
        public KeyVaultTestBase()
        {
            // Empty
        }

        protected override void ValidateClient(KeyVaultAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.Quotas);
        }
    }
}
