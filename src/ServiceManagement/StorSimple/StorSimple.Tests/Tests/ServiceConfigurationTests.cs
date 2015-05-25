using System.Collections.Generic;
using Microsoft.Azure;
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