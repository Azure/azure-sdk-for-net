// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    public class PaasWindowsPoolFixture : PoolFixture
    {
        public PaasWindowsPoolFixture(BatchClient batchClient) : base(TestUtilities.GetMyName() + "-pooltest", batchClient) { }

        public async Task<BatchPool> CreatePoolAsync()
        {
            BatchPool thePool = await client.GetPoolAsync(PoolId);

            BatchPool currentPool = await FindPoolIfExistsAsync();

            if (currentPool == null)
            {
                // gotta create a new pool
                var password = TestUtilities.GenerateRandomPassword();
                BatchPoolCreateContent batchPoolCreateOptions = new BatchPoolCreateContent(
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
                    StartTask = new BatchStartTask("cmd /c hostname")
                    {
                        EnvironmentSettings = {
                            new EnvironmentSetting("key")
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
