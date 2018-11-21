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
    public class DiscoveredSecuritySolutionsTests : TestBase
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

        #region DiscoveredSecuritySolutions

        [Fact]
        public void DiscoveredSecuritySolutions_List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var discoveredSecuritySolutions = securityCenterClient.DiscoveredSecuritySolutions.List();
                ValidateDiscoveredSecuritySolutions(discoveredSecuritySolutions);
            }
        }

        [Fact]
        public void DiscoveredSecuritySolutions_Get()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var discoveredSecuritySolution = securityCenterClient.DiscoveredSecuritySolutions.Get("myService1", "ContosoWAF2");
                ValidateDiscoveredSecuritySolution(discoveredSecuritySolution);
            }
        }

        [Fact]
        public void DiscoveredSecuritySolutions_ListByHomeRegion()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var discoveredSecuritySolutions = securityCenterClient.DiscoveredSecuritySolutions.ListByHomeRegion();
                ValidateDiscoveredSecuritySolutions(discoveredSecuritySolutions);
            }
        }

        #endregion

        #region Validations

        private void ValidateDiscoveredSecuritySolutions(IPage<DiscoveredSecuritySolution> discoveredSecuritySolutionPage)
        {
            Assert.True(discoveredSecuritySolutionPage.IsAny());

            discoveredSecuritySolutionPage.ForEach(ValidateDiscoveredSecuritySolution);
        }

        private void ValidateDiscoveredSecuritySolution(DiscoveredSecuritySolution discoveredSecuritySolution)
        {
            Assert.NotNull(discoveredSecuritySolution);
        }

        #endregion
    }
}
