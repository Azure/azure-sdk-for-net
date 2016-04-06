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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Test;
using System.Net;
using System.Linq;
using Xunit;
using Microsoft.Azure;


namespace SiteRecovery.Tests
{
    public class UpdateTests : SiteRecoveryTestsBase
    {
        
        public void UpdateVMwareAzureV2PolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var policiesResponse = client.Policies.List(RequestHeaders);
                var vmWarePolicy = policiesResponse.Policies.First(
                    policy => policy.Properties.ProviderSpecificDetails.InstanceType == "VMwareAzureV2");
                Assert.NotNull(vmWarePolicy);

                var response = client.Policies.Update(
                    new UpdatePolicyInput
                    {
                        Properties = new UpdatePolicyProperties
                        {
                            ReplicationProviderSettings = new InMageAzureV2PolicyInput
                            {
                                AppConsistentFrequencyInMinutes = 30,
                                CrashConsistentFrequencyInMinutes = 30,
                                MultiVmSyncStatus = "Disable",
                                RecoveryPointHistory = 10,
                                RecoveryPointThresholdInMinutes = 15
                            }
                        }
                    },
                    vmWarePolicy.Name,
                    RequestHeaders);
                Assert.NotNull(response);

                var updateResponse = response as UpdatePolicyOperationResponse;
                Assert.NotNull(updateResponse);

                Assert.NotNull(updateResponse);
                Assert.Equal(updateResponse.Status, OperationStatus.Succeeded);
            }
        }
    }
}
