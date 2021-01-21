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
    public class AssessmentsTests : TestBase
    {
        #region Test setup
        private static readonly string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static readonly string ResourceGroupName = "subAssessments_sdk_tests";
        // A maximum of 3 owners should be designated for your subscription
        private static readonly string AssessmentName = "6f90a6d6-d4d6-0794-0ec1-98fa77878c2e";
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
        public void Assessments_List_Subscription_Scope()
        {
            string scope = $"subscriptions/{SubscriptionId}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.Assessments.List(scope);
                Validate(ret);
            }
        }


        [Fact]
        public void Assessments_List_ResourceGroup_Scope()
        {
            string scope = $"subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.Assessments.List(scope);
                Validate(ret);
            }
        }


        [Fact]
        public void Assessments_List_ResourceGroup_Scope_ResourceDetails()
        {
            string scope = $"subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.Assessments.List(scope);
                ValidateResourceDetails(ret);
            }
        }

        [Fact]
        public void Assessments_Get()
        {
            string scope = $"/subscriptions/{SubscriptionId}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.Assessments.Get(scope, AssessmentName);
                Assert.NotNull(ret);
            }
        }

        [Fact]
        public void Assessments_CreateOrUpdate_ResourceGroup_Scope()
        {
            string resourceId = $"/subscriptions/{SubscriptionId}/resourceGroups/myService1/providers/Microsoft.OperationalInsights/workspaces/TestServiceWS";
            string assessmentName = "9b0c3939-c9db-4ffc-ad4b-4673ff25cdd8"; // randomly generated guid

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var securityAssessment = new SecurityAssessment()
                {
                    ResourceDetails = new AzureResourceDetails()
                    {
                    },
                    Status = new AssessmentStatus()
                    {
                        Code = AssessmentStatusCode.Healthy,
                        Description = "NA",
                        Cause = "NA"
                    }
                };

                var assessmentMetadata = new SecurityAssessmentMetadata()
                {
                    DisplayName = "Customer managed metadata",
                    Description = "Customer managed description",
                    AssessmentType = AssessmentType.CustomerManaged,
                    Severity = Severity.Low
                };
                
                // Assessment metadata must be created prior to creating assessments
                securityCenterClient.AssessmentsMetadata.CreateInSubscription(assessmentName, assessmentMetadata);

                var ret = securityCenterClient.Assessments.CreateOrUpdate(resourceId, assessmentName, securityAssessment);

                ValidateResourceDetails(ret);
            }
        }
        #endregion

        #region Validations
        private static void Validate(IPage<SecurityAssessment> ret)
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
        private static void ValidateResourceDetails(IPage<SecurityAssessment> ret)
        {
            foreach (var item in ret)
            {
                ValidateResourceDetails(item);
            }
        }

        /// <summary>
        /// For each of the supported 'ResourceDetails' types, validates that the 'ResourceDetails' is at least one of them:
        /// assignable means not null: serialization \ deserialization was successful
        /// </summary>
        /// <param name="item"></param>
        private static void ValidateResourceDetails(SecurityAssessment item)
        {
            Assert.NotNull(item);
            ValidateResourceDetails(item.ResourceDetails);
        }

        /// <summary>
        /// Helper method that validates any type of resource details passed
        /// </summary>
        /// <param name="resourceDetails"></param>
        protected static void ValidateResourceDetails(ResourceDetails resourceDetails)
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
