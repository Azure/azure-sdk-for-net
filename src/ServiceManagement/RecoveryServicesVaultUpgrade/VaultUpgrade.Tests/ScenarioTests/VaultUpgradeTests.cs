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

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade.Models;
using Xunit;

namespace VaultUpgrade.Tests
{
    public class VaultUpgradeTests : VaultUpgradeTestsBase
    {
        [Fact]
        public void VaultUpgrade_CheckPrereqsTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetRecoveryServicesVaultUpgradeClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;

                var resourcePath = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}/{4}",
                    client.Credentials.SubscriptionId,
                    "TargetRg",
                    "Microsoft.RecoveryServicesBVTD2",
                    "Vaults",
                    VaultUpgradeTestsBase.MyVaultName);

                ResourceUpgradeInput input = new ResourceUpgradeInput()
                {
                    NewResourcePath = resourcePath
                };

                var response = client.RecoveryServicesVaultUpgrade.CheckPrerequisitesForRecoveryServicesVaultUpgrade(input, requestHeaders);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void VaultUpgrade_UpgradeResourceTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetRecoveryServicesVaultUpgradeClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;

                var resourcePath = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}/{4}",
                     client.Credentials.SubscriptionId,
                     "TargetRg",
                     "Microsoft.RecoveryServicesBVTD2",
                     "Vaults",
                     VaultUpgradeTestsBase.MyVaultName);

                ResourceUpgradeInput input = new ResourceUpgradeInput()
                {
                    NewResourcePath = resourcePath
                };

                var response = client.RecoveryServicesVaultUpgrade.UpgradeResource(input, requestHeaders);

                Assert.NotNull(response);
                Assert.Equal(response.Status.ToString(), "InProgress");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void VaultUpgrade_TrackResourceUpgradationTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetRecoveryServicesVaultUpgradeClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;

                var response = client.RecoveryServicesVaultUpgrade.TrackResourceUpgrade(requestHeaders);

                Assert.NotNull(response);
                Assert.Equal(response.OperationStatus, "Completed");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
