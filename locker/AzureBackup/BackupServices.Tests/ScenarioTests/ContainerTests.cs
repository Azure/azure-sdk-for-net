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
using System.Configuration;
using BackupServices.Tests.Helpers;

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

        [Fact]
        public void RegisterContainersReturnsValidResponseTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupServicesManagementClient client = GetServiceClient<BackupServicesManagementClient>();
                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                var inputRequest = new RegisterContainerRequestInput();
                inputRequest.ContainerType = "IaasVMContainer";
                inputRequest.ContainerUniqueNameList = new List<string>();
                inputRequest.ContainerUniqueNameList.Add(containerName);

                var response = client.Container.Register(inputRequest, GetCustomRequestHeaders());

                // Response Validation
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
                Assert.NotNull(response);
            }
        }

        [Fact]
        public void UnRegisterContainersReturnsValidResponseTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupServicesManagementClient client = GetServiceClient<BackupServicesManagementClient>();
                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                var inputRequest = new UnregisterContainerRequestInput();
                inputRequest.ContainerType = "IaasVMContainer";
                inputRequest.ContainerUniqueName = containerName;

                var response = client.Container.Unregister(inputRequest, GetCustomRequestHeaders());

                // Response Validation
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
                Assert.NotNull(response);
            }
        }
    }
}
