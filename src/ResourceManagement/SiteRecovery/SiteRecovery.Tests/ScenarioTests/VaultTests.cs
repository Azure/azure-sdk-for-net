//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.WindowsAzure;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.RecoveryServices.Models;
using System.Threading;

namespace SiteRecovery.Tests
{
    public class VaultTests : SiteRecoveryTestsBase
    {
        [Fact]
        public void GetVaultCredentialTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var clientSR = GetSiteRecoveryClient(CustomHttpHandler);
                var response = client.VaultExtendedInfo.GetExtendedInfo(RequestHeaders);

                Assert.NotNull(response.ResourceExtendedInformation);
            }
        }

        [Fact]
        public void OtherVaultTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetRecoveryServicesClient(CustomHttpHandler);
                var clientSR = GetSiteRecoveryClient(CustomHttpHandler);
                var response = client.Vaults.CreateAsync(
                    clientSR.ResourceGroupName, "testVault1234", new VaultCreateArgs(), new CancellationToken());

                Assert.NotNull(response);
            }
        }

        [Fact]
        public void OtherVaultTests2()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetRecoveryServicesClient(CustomHttpHandler);
                var clientSR = GetSiteRecoveryClient(CustomHttpHandler);
                var response = client.ResourceGroup.ListAsync(new CancellationToken());

                Assert.NotNull(response);
            }
        }

    }
}
