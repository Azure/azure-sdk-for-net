// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
    public class SecurityTasksTests : TestBase
    {
        #region Test setup

        public static TestEnvironment TestEnvironment { get; private set; }

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

            securityCenterClient.AscLocation = "centralus";

            return securityCenterClient;
        }

        #endregion

        #region Tasks

        [Fact]
        public void SecurityTaskRecommendations_List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendations = securityCenterClient.Tasks.List();
                ValidateTasks(recommendations);
            }
        }

        [Fact]
        public void SecurityTaskRecommendations_GetResourceGroupLevelTask()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendation = securityCenterClient.Tasks.GetResourceGroupLevelTask("myService1", "dcfb6365-799e-5ed4-f344-d86a0a4c2992");
                ValidateTask(recommendation);
            }
        }

        [Fact]
        public void SecurityTaskRecommendations_GetSubscriptionLevelTask()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendation = securityCenterClient.Tasks.GetSubscriptionLevelTask("08357a1e-c534-756f-cbb9-7b45e73f3137");
                ValidateTask(recommendation);
            }
        }

        [Fact]
        public void SecurityTaskRecommendations_ListByHomeRegion()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendations = securityCenterClient.Tasks.ListByHomeRegion();
                ValidateTasks(recommendations);
            }
        }

        [Fact]
        public void SecurityTaskRecommendations_ListByResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendations = securityCenterClient.Tasks.ListByResourceGroup("myService1");
                ValidateTasks(recommendations);
            }
        }

        [Fact]
        public void SecurityTaskRecommendations_UpdateResourceGroupLevelTask()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.Tasks.UpdateResourceGroupLevelTaskState("myService1", "dcfb6365-799e-5ed4-f344-d86a0a4c2992", "Dismiss");
            }
        }

        [Fact]
        public void SecurityTaskRecommendations_UpdateSubscriptionLevelTask()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.Tasks.UpdateSubscriptionLevelTaskState("08357a1e-c534-756f-cbb9-7b45e73f3137", "Dismiss");
            }
        }

        private void ValidateTasks(IPage<SecurityTask> recommendationsPage)
        {
            Assert.True(recommendationsPage.IsAny());

            recommendationsPage.ForEach(ValidateTask);
        }

        private void ValidateTask(SecurityTask recommendation)
        {
            Assert.NotNull(recommendation);

            Assert.True(recommendation.CreationTimeUtc.HasValue);
            Assert.True(recommendation.CreationTimeUtc.Value.ToUniversalTime() < DateTime.UtcNow);
        }

        #endregion
    }
}
