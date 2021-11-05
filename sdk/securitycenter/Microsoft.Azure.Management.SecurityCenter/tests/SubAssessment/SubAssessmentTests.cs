// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using System.Net;
using Xunit;

namespace SecurityCenter.Tests
{
    public class SubAssessmentTests : TestBase
    {
        #region Test setup
        private static readonly string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static readonly string ResourceGroupName = "subAssessments_sdk_tests";
        private static readonly string ContainerRegistryName = "sdkRef";
        // Vulnerabilities in Azure Container Registry images should be remediated (powered by Qualys)
        private static readonly string AssessmentName = "dbd0cb49-b563-45e7-9724-889e799fa648";
        // auto-generated
        private static readonly string SubAssessmentName = "d1164a35-41e9-43aa-bbc7-bfb3ae093cea";
        private static readonly string AscLocation = "centralus";
        private static TestEnvironment TestEnvironment { get; set; }
        #endregion

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

        #region Tests
        [Fact]
        public void SubAssessments_ListAll()
        {
            string scope = $"subscriptions/{SubscriptionId}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.SubAssessments.ListAll(scope);
                Validate(ret);
            }
        }

        [Fact]
        public void SubAssessments_List()
        {
            string scope = $"subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{ContainerRegistryName}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.SubAssessments.List(scope, AssessmentName);
                Validate(ret);
            }
        }


        [Fact]
        public void SubAssessments_List_ResourceDetails()
        {
            string scope = $"subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{ContainerRegistryName}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.SubAssessments.List(scope, AssessmentName);
                ValidateResourceDetails(ret);
            }
        }

        [Fact]
        public void SubAssessments_Get()
        {
            string scope = $"subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{ContainerRegistryName}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.SubAssessments.Get(scope, AssessmentName, SubAssessmentName);
                Assert.NotNull(ret);
            }
        }
        #endregion

        #region Validations
        private static void Validate(IPage<SecuritySubAssessment> ret)
        {
            Assert.True(ret.IsAny(), "Got empty list");
            foreach (var item in ret)
            {
                Assert.NotNull(item);
            }
        }

        /// <summary>
        /// For each of the supported 'ResourceDetails' types, validates that the 'ResourceDetails' is at least one of them:
        /// assignable means not null: serialization \ deserialization was successful
        /// </summary>
        /// <param name="ret"></param>
        private static void ValidateResourceDetails(IPage<SecuritySubAssessment> ret)
        {
            foreach (var item in ret)
            {
                Assert.NotNull(item);
                ValidateResourceDetails(item.ResourceDetails);
            }
        }

        /// <summary>
        /// Helper method that validates any type of resource details passed
        /// </summary>
        /// <param name="resourceDetails"></param>
        private static void ValidateResourceDetails(ResourceDetails resourceDetails)
        {
            Assert.NotNull(resourceDetails);

            switch (resourceDetails)
            {
                case AzureResourceDetails azureResourceDetails:
                    Assert.NotNull(azureResourceDetails);
                    Assert.NotNull(azureResourceDetails.Id);
                    break;
                case OnPremiseSqlResourceDetails onPremiseSqlResourceDetails:
                    Assert.NotNull(onPremiseSqlResourceDetails);
                    Assert.NotNull(onPremiseSqlResourceDetails.MachineName);
                    Assert.NotNull(onPremiseSqlResourceDetails.SourceComputerId);
                    Assert.NotNull(onPremiseSqlResourceDetails.Vmuuid);
                    Assert.NotNull(onPremiseSqlResourceDetails.WorkspaceId);
                    Assert.NotNull(onPremiseSqlResourceDetails.DatabaseName);
                    Assert.NotNull(onPremiseSqlResourceDetails.ServerName);
                    break;
                case OnPremiseResourceDetails onPremiseResourceDetails:
                    Assert.NotNull(onPremiseResourceDetails);
                    Assert.NotNull(onPremiseResourceDetails.MachineName);
                    Assert.NotNull(onPremiseResourceDetails.SourceComputerId);
                    Assert.NotNull(onPremiseResourceDetails.Vmuuid);
                    Assert.NotNull(onPremiseResourceDetails.WorkspaceId);
                    break;
                default:
                    throw new Exception("Unsupported resource details");
            }
        }

        #endregion
        }
}
