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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Test;
using Microsoft.Azure.Management.Sql;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    public class Sql2LocationCapabilitiesTests : TestBase
    {
        /// <summary>
        /// Test to ensure that the Location Capabilites API is working correctly
        /// </summary>
        [Fact]
        public void LocationCapabilitiesTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);

                string regionName = "North Europe";

                var capabilities = sqlClient.Capabilities.Get(regionName);
                TestUtilities.ValidateOperationResponse(capabilities);

                // Make sure the right region is returned
                Assert.True(NormalizedRegionName(capabilities.Capabilities.Name) == NormalizedRegionName(regionName));

                // Ensure at least one server version is returned
                var supportedVersions = capabilities.Capabilities.SupportedServerVersions;
                Assert.True(supportedVersions.Count > 0, string.Format("Location : '{0}' does not have any available server versions.", regionName));

                // Validate all the supported versions
                foreach (var version in capabilities.Capabilities.SupportedServerVersions)
                {
                    Assert.True(!string.IsNullOrEmpty(version.Name));
                    Assert.True(!string.IsNullOrEmpty(version.Status));

                    // Ensure that at least one edition is available for the server version
                    Assert.True(version.SupportedEditions.Count > 0, string.Format("Server version: '{0}' does not have any available editions", version.Name));

                    // Validate the available editions
                    foreach (var edition in version.SupportedEditions)
                    {
                        Assert.True(!string.IsNullOrEmpty(edition.Name));
                        Assert.True(!string.IsNullOrEmpty(edition.Status));

                        // Ensure that the edition has at least one SLO available
                        Assert.True(edition.SupportedServiceObjectives.Count > 0, string.Format("Edition: '{0}.{1}' does not have any available SLOs", version.Name, edition.Name));

                        // Validate the avialable max sizes.
                        foreach (var slo in edition.SupportedServiceObjectives)
                        {
                            Assert.True(!string.IsNullOrEmpty(slo.Name));
                            Assert.True(!string.IsNullOrEmpty(slo.Status));
                            Assert.True(Guid.Empty != slo.Id);

                            // Ensure that the SLO has at least 1 max size available.
                            Assert.True(slo.SupportedMaxSizes.Count > 0, string.Format("SLO: '{0}.{1},{2}' does not have any available max sizes", version.Name, edition.Name, slo.Name));

                            foreach(var maxSize in slo.SupportedMaxSizes)
                            {
                                Assert.True(maxSize.Limit > 0);
                                Assert.True(!string.IsNullOrEmpty(maxSize.Unit));
                                Assert.True(!string.IsNullOrEmpty(maxSize.Status));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Given a string normalizes it by removing all spaces and setting all characters to lowercase
        /// </summary>
        /// <param name="name">The name to normalize</param>
        /// <returns>The result of normalization</returns>
        public string NormalizedRegionName(string name)
        {
            return string.Join(string.Empty, name.ToLower().Where((c) => !char.IsWhiteSpace(c)));
        }
    }
}
