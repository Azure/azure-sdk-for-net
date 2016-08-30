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

using Microsoft.Azure;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;

namespace RecoveryServices.Tests
{
    public class VaultUsageTests : RecoveryServicesTestsBase
    {
        string resourceGroupName = "RsvTestRG";
        string resourceName = "rsv6";

        [Fact]
        public void RetrieveVaultUsage()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var rsmClient = GetRecoveryServicesClient(CustomHttpHandler);
                VaultUsageListResponse response = rsmClient.VaultUsage.List(resourceGroupName, resourceName, RequestHeaders);
                
                Assert.NotNull(response.Value);
                Assert.NotEqual(response.Value.Count, 0);
                foreach (var usage in response.Value)
                {
                    Assert.NotNull(usage.Name.Value);
                    Assert.NotNull(usage.Name.LocalizedValue);
                    Assert.NotNull(usage.Unit);
                    Assert.NotNull(usage.CurrentValue);
                    Assert.NotNull(usage.Limit);
                }
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
