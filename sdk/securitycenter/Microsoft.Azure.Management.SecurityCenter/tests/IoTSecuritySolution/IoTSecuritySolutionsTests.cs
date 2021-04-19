// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class IotSecuritySolutionTests : TestBase
    {
        #region Test setup

        private static readonly string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static readonly string ResourceGroupName = "IOT-ResourceGroup-CUS";
        private static readonly string IotHubName = "SDK-IotHub-CUS";
        private static readonly string SolutionName = "securitySolution";
        private static readonly string SolutionNameToDelete = "securitySolutionToDelete";
        private static readonly string WorkspaceName = "SDK-IotHub-LA-CUS";
        private static readonly string AscLocation = "centralus";
        private static TestEnvironment TestEnvironment { get; set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = AscLocation;

            return securityCenterClient;
        }

        #endregion

        #region Tests

        [Fact]
        public void IotSecuritySolution_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSecuritySolution.Get(ResourceGroupName, SolutionName);
                ret.Validate();
            }
        }

        [Fact]
        public void IotSecuritySolution_CreateOrUpdate()
        {
            string IotHubResourceId =
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Devices/IotHubs/{IotHubName}";

            string WorkspaceResourceId =
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{WorkspaceName}";

            var udrp = new UserDefinedResourcesProperties("where type != \"microsoft.devices/iothubs\" | where name contains \"v2\"", new[] { SubscriptionId });

            var iotSecuritySolutionData = new IoTSecuritySolutionModel()
            {
                Workspace = WorkspaceResourceId,
                DisplayName = $"{SolutionName}-{WorkspaceName}",
                IotHubs = new[] { IotHubResourceId },
                Location = AscLocation,
                UserDefinedResources = udrp,
            };

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSecuritySolution.CreateOrUpdate(ResourceGroupName, SolutionName, iotSecuritySolutionData);
                ret.Validate();
            }
        }

        [Fact]
        public void IotSecuritySolution_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var lst = securityCenterClient.IotSecuritySolution.ListByResourceGroup(ResourceGroupName);
                securityCenterClient.IotSecuritySolution.Delete(ResourceGroupName, SolutionNameToDelete);
                Assert.Throws<CloudException>(() =>
                {
                    securityCenterClient.IotSecuritySolution.Get(ResourceGroupName, SolutionNameToDelete);
                });
            }
        }

        [Fact]
        public void IotSecuritySolution_Update()
        {
            var udrp = new UserDefinedResourcesProperties("where type != \"microsoft.devices/iothubs\" | where name contains \"v2\"", new[] { SubscriptionId });
            var rcp = new RecommendationConfigurationProperties("IoT_OpenPorts", "Disabled");
            UpdateIotSecuritySolutionData updateIotSecuritySolutionData = new UpdateIotSecuritySolutionData(null, udrp, new[] { rcp });
            updateIotSecuritySolutionData.Validate();

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSecuritySolution.Update(ResourceGroupName, SolutionName, updateIotSecuritySolutionData);
                ret.Validate();
            }
        }

        [Fact]
        public void IotSecuritySolution_ListByResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSecuritySolution.ListByResourceGroup(ResourceGroupName);
                Validate(ret);
            }
        }

        [Fact]
        public void IotSecuritySolution_ListBySubscription()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSecuritySolution.ListBySubscription();
                Assert.True(ret.IsAny());

                // Currently generated code ignores swagger directive "x-nullable: true" and checks for null UserDefinedResourcesProperties.Query
                // Swagger issue is tracked at: https://github.com/Azure/autorest/issues/3300
                // TODO: uncomment following line when "Setting x-nullable on string field" issue has been fixed.
                // Validate(ret);
            }
        }
        #endregion

        #region Validations
        private static void Validate(IPage<IoTSecuritySolutionModel> ret)
        {
            Assert.True(ret.IsAny());
            foreach (var item in ret)
            {
                item.Validate();
            }
        }
        #endregion
    }
}