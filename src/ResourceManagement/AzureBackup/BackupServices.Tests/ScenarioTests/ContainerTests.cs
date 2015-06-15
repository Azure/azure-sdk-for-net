using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackupServices.Tests
{
    public class ContainerTests : BackupServicesTestsBase
    {
        [Fact]
        public void ListContainersReturnsValidResponseTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupServicesManagementClient client = GetServiceClient<BackupServicesManagementClient>();

                ListContainerResponse response = client.Container.List(string.Empty, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.True(response.ResultCount > 0, "Should return at least one container");
                Assert.True(response.Objects.Count > 0, "Should return at least one container");
            }
        }
    }
}
