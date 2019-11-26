// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Commerce.Admin;
using Microsoft.AzureStack.Management.Commerce.Admin.Models;
using System;
using Xunit;

namespace Commerce.Tests.src
{
    public class UpdateEncryptionTests : CommerceTestBase
    {
        [Fact]
        public void TestUpdateEncruption() {
            RunTest((client) => {
                client.UpdateEncryption();
            });
        }
    }
}
