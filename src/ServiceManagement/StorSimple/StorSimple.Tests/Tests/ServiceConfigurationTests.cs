// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.Azure.Test;
using Xunit;
using System;

namespace StorSimple.Tests.Tests
{
    public class ServiceConfigurationTests : StorSimpleTestBase
    {
        [Fact]
        public void CanAddACRTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();

                var serviceConfig = new ServiceConfiguration()
                {
                    AcrChangeList = new AcrChangeList()
                    {
                        Added = new []
                        {
                            new AccessControlRecord()
                            {
                                GlobalId = null,
                                InitiatorName = TestUtilities.GenerateName("InitiatorName"),
                                InstanceId = null,
                                Name = TestUtilities.GenerateName("AcrName"),
                                VolumeCount = 0
                            },
                        },
                        Deleted = new List<string>(),
                        Updated = new List<AccessControlRecord>()
                    },
                    CredentialChangeList = new SacChangeList(),
                };

                CustomRequestHeaders hdrs = new CustomRequestHeaders();
                hdrs.ClientRequestId = Guid.NewGuid().ToString();
                hdrs.Language = "en-us";

                var taskStatus = client.ServiceConfig.Create(serviceConfig, hdrs);

                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);
            }
        }

        [Fact]
        public void CanGetServiceConfigTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();
                var serviceConfigList = client.ServiceConfig.Get(GetCustomRequestHeaders());

                Assert.True(serviceConfigList != null);
                //Assert.True(serviceConfigList.AcrChangeList.);
            }
        }
    }
}