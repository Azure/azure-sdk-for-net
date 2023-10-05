// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    public class PaasWindowsPoolFixture : PoolFixture
    {
        public PaasWindowsPoolFixture(BatchClient batchClient) : base(TestUtilities.GetMyName() + "-pooltest", batchClient) => Pool = CreatePoolAsync();

        private async Task<BatchPool> CreatePoolAsync()
        {
            BatchPool currentPool = await FindPoolIfExistsAsync();

            if (currentPool == null)
            {
                // gotta create a new pool
                var password = TestUtilities.GenerateRandomPassword();
                BatchPoolCreateOptions batchPoolCreateOptions = new BatchPoolCreateOptions(
                    PoolId,
                    VMSize)
                {
                    CloudServiceConfiguration = new CloudServiceConfiguration(OSFamily),
                    UserAccounts = {
                        new UserAccount(AdminUserAccountName, password)
                        {
                            ElevationLevel = ElevationLevel.Admin,
                        },
                        new UserAccount(NonAdminUserAccountName, password)
                        {
                            ElevationLevel = ElevationLevel.NonAdmin,
                        },
                    },
                    StartTask = new StartTask("cmd /c hostname")
                    {
                        EnvironmentSettings = {
                            new EnvironmentSetting("key", "value")
                        },
                        UserIdentity = new UserIdentity()
                        {
                            AutoUser = new AutoUserSpecification()
                            {
                                Scope = AutoUserScope.Pool,
                                ElevationLevel = ElevationLevel.NonAdmin,
                            },
                        },
                    },
                    TargetDedicatedNodes = 1,
                };
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                if (response == null)
                { }
            }

            return await WaitForPoolAllocation(client, PoolId);
        }
    }
}
