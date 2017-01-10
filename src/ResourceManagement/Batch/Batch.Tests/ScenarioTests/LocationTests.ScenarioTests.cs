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

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Batch.Tests.ScenarioTests
{
    public class LocationTests : BatchScenarioTestBase
    {
        [Fact]
        public async Task GetLocationQuotasAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                BatchLocationQuota quotas = await this.BatchManagementClient.Location.GetQuotasAsync(this.Location);

                Assert.NotNull(quotas.AccountQuota);
                Assert.True(quotas.AccountQuota.Value > 0);
            }
        }
    }
}
