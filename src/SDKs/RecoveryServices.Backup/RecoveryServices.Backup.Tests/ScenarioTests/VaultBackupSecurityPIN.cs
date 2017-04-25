// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class VaultBackupSecurityPin: TestBase, IDisposable
    {
        private const string SecurityPinTestVault = "TestVaultGetBackupSecurityPin";

        [Fact]
        public void GetBackupSecurityPin()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            using (var testHelper = new TestHelper() { VaultName = SecurityPinTestVault})
            {
                testHelper.Initialize(context);
                TokenInformation tokenInformation = testHelper.GetBackupSecurityPin();
                Assert.NotNull(tokenInformation);
                Assert.NotEmpty(tokenInformation.SecurityPIN);
                Assert.True(tokenInformation.ExpiryTimeInUtcTicks > DateTime.UtcNow.Ticks);
            }
        }

        public void Dispose()
        {
        }
    }
}
