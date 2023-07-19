// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
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
    public class ExternalSecuritySolutionsTests : TestBase
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

        #region ExternalSecuritySolutions

        [Fact]
        public void ExternalSecuritySolutions_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                // Missing test recording
                Assert.Throws<KeyNotFoundException>(() =>
                {
                    var securityCenterClient = GetSecurityCenterClient(context);
                    var externalSecuritySolutions = securityCenterClient.ExternalSecuritySolutions.List();
                    ValidateExternalSecuritySolutions(externalSecuritySolutions);
                });
                
            }
        }

        [Fact]
        public void ExternalSecuritySolutions_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                // Missing test recording
                Assert.Throws<KeyNotFoundException>(() =>
                {
                    var externalSecuritySolution = securityCenterClient.ExternalSecuritySolutions.Get(
                        "defaultresourcegroup-eus", "aad_defaultworkspace-487bb485-b5b0-471e-9c0d-10717612f869-eus");
                    ValidateExternalSecuritySolution(externalSecuritySolution);
                });

            }
        }

        [Fact]
        public void ExternalSecuritySolutions_ListByHomeRegion()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                // Missing test recording
                Assert.Throws<KeyNotFoundException>(() =>
                {
                    var securityCenterClient = GetSecurityCenterClient(context);
                    var externalSecuritySolutions = securityCenterClient.ExternalSecuritySolutions.ListByHomeRegion();
                    ValidateExternalSecuritySolutions(externalSecuritySolutions);
                });
            }
        }

        #endregion

        #region Validations

        private void ValidateExternalSecuritySolutions(IPage<ExternalSecuritySolution> externalSecuritySolutionPage)
        {
            Assert.False(externalSecuritySolutionPage.IsAny());

            //externalSecuritySolutionPage.ForEach(ValidateExternalSecuritySolution);
        }

        private void ValidateExternalSecuritySolution(ExternalSecuritySolution externalSecuritySolution)
        {
            Assert.NotNull(externalSecuritySolution);
        }

        #endregion
    }
}
