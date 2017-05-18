// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests.Fixtures
{
    using System.Collections.Generic;
    using BatchTestCommon;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Xunit;

    public class PaasWindowsPoolFixture : PoolFixture
    {
        public PaasWindowsPoolFixture()
            : base(TestUtilities.GetMyName() + "-pooltest")
        {
            this.Pool = this.CreatePool();
        }

        protected CloudPool CreatePool()
        {
            CloudPool currentPool = this.FindPoolIfExists();

            if (currentPool == null)
            {
                // gotta create a new pool
                CloudServiceConfiguration passConfiguration = new CloudServiceConfiguration(OSFamily);

                currentPool = this.client.PoolOperations.CreatePool(
                    this.PoolId,
                    VMSize,
                    passConfiguration,
                    targetDedicated: 1);
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
                currentPool.StartTask = st;

                currentPool.Commit();
            }

            return WaitForPoolAllocation(this.client, this.PoolId);
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
