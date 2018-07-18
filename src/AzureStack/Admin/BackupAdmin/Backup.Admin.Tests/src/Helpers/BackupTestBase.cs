// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Backup.Admin;
using Xunit;

namespace Backup.Tests
{

    public class BackupTestBase : AzureStackTestBase<BackupAdminClient>
    {
        public BackupTestBase()
        {
            // Empty
        }

        public const string ResourceGroupName = "System.local";

        protected string ExtractName(string name) {
            if(name.Contains("/"))
            {
                var idx = name.LastIndexOf('/');
                name = name.Substring(idx + 1);
            }
            return name;
        }

        protected override void ValidateClient(BackupAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.Backups);
            Assert.NotNull(client.SubscriptionId);
        }
    }
}
