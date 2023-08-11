// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Threading.Tasks;
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
        public async Task SecurityTaskRecommendations_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendations = await securityCenterClient.Tasks.ListAsync();
                ValidateTasks(recommendations);
            }
        }

        [Fact]
        public async Task SecurityTaskRecommendations_GetResourceGroupLevelTask()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendation = await securityCenterClient.Tasks.GetResourceGroupLevelTaskAsync("myService1", "f709e910-f52f-2cf8-81af-d5679b7f4d75");
                ValidateTask(recommendation);
            }
        }

        [Fact]
        public async Task SecurityTaskRecommendations_GetSubscriptionLevelTask()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendation = await securityCenterClient.Tasks.GetSubscriptionLevelTaskAsync("0456e493-0a77-4dea-b3e5-d0c7daee4ee9");
                ValidateTask(recommendation);
            }
        }

        [Fact]
        public async Task SecurityTaskRecommendations_ListByHomeRegion()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendations = await securityCenterClient.Tasks.ListByHomeRegionAsync();
                ValidateTasks(recommendations);
            }
        }

        [Fact]
        public async Task SecurityTaskRecommendations_ListByResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var recommendations = await securityCenterClient.Tasks.ListByResourceGroupAsync("myService1");
                ValidateTasks(recommendations);
            }
        }

        [Fact]
        public async Task SecurityTaskRecommendations_UpdateResourceGroupLevelTask()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                await securityCenterClient.Tasks.UpdateResourceGroupLevelTaskStateAsync("myService1", "f709e910-f52f-2cf8-81af-d5679b7f4d75", TaskUpdateActionType.Dismiss);
            }
        }

        [Fact]
        public async Task SecurityTaskRecommendations_UpdateSubscriptionLevelTask()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                await securityCenterClient.Tasks.UpdateSubscriptionLevelTaskStateAsync("0456e493-0a77-4dea-b3e5-d0c7daee4ee9", TaskUpdateActionType.Dismiss);
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
