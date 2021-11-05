// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Sql;
using Azure.ResourceManager.Sql.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class CapabilitiesScenarioTests : SqlManagementClientBase
    {
        public CapabilitiesScenarioTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TestGetCapabilitiesAsync()
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            string suiteName = this.GetType().Name;

            SqlManagementClient sqlClient = GetSqlManagementClient();

            LocationCapabilities capabilities = await sqlClient.Capabilities.ListByLocationAsync(DefaultLocation);

            Assert.NotNull(capabilities);

            foreach (ServerVersionCapability s in capabilities.SupportedServerVersions)
            {
                Assert.NotNull(s.Name);
                foreach (EditionCapability e in s.SupportedEditions)
                {
                    Assert.NotNull(e.Name);
                    foreach (ServiceObjectiveCapability o in e.SupportedServiceLevelObjectives)
                    {
                        Assert.NotNull(o.Name);
                        Assert.NotNull(o.PerformanceLevel);
                        foreach (MaxSizeRangeCapability m in o.SupportedMaxSizes)
                        {
                            Assert.NotNull(m.MinValue);
                            Assert.NotNull(m.MaxValue);
                        }
                    }
                }
            }
        }
    }
}
