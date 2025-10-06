// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests.Fixtures
{
    using System.Collections.Generic;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Xunit;

    public class PaasWindowsPoolFixture : PoolFixture
    {
        public PaasWindowsPoolFixture()
            : base(TestUtilities.GetMyName() + "-pooltest")
        {
            Pool = CreatePool();
        }

        protected CloudPool CreatePool()
        {
            CloudPool currentPool = FindPoolIfExists();

            if (currentPool == null)
            {
                // gotta create a new pool
                var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(client);

                VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                    ubuntuImageDetails.ImageReference,
                    nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

                currentPool = client.PoolOperations.CreatePool(
                    PoolId,
                    VMSize,
                    virtualMachineConfiguration,
                    targetDedicatedComputeNodes: 1);
                var password = TestUtilities.GenerateRandomPassword();
                currentPool.UserAccounts = new List<UserAccount>()
                    {
                        new UserAccount(AdminUserAccountName, password, ElevationLevel.Admin),
                        new UserAccount(NonAdminUserAccountName, password, ElevationLevel.NonAdmin),
                    };

                StartTask st = new StartTask("cmd /c hostname");

                // used for tests of StartTask(info)
                st.EnvironmentSettings = new List<EnvironmentSetting>
                {
                    new EnvironmentSetting("key", "value")
                };
                st.UserIdentity = new UserIdentity(
                    autoUserSpecification: new AutoUserSpecification(
                        scope: AutoUserScope.Pool,
                        elevationLevel: ElevationLevel.NonAdmin));
                currentPool.StartTask = st;

                currentPool.Commit();
            }

            return WaitForPoolAllocation(client, PoolId);
        }
    }

    /// <summary>
    /// This class is used by XUnit
    /// </summary>
    [CollectionDefinition("SharedPoolCollection")]
    public class SharedPoolCollection : ICollectionFixture<PaasWindowsPoolFixture>
    {

    }
}
