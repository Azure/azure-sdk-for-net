// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchClientIntegrationTests.Fixtures
{
    using System.Collections.Generic;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch;
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
