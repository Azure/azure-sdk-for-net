// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
            using (MockContext context = StartMockContextAndInitializeClients(this.GetType()))
            {
                BatchLocationQuota quotas = await this.BatchManagementClient.Location.GetQuotasAsync(this.Location);

                Assert.NotNull(quotas.AccountQuota);
                Assert.True(quotas.AccountQuota.Value > 0);
            }
        }
    }
}
