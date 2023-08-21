// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    public class SecurityConnectorsTests : TestBase
    {
        #region Test setup

        private static readonly string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static readonly string ResourceGroupName = "SecurityConnectorsTests";
        private static readonly string SecurityConnectorName = "SdkTestSecurityConnector";

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
            securityCenterClient.SubscriptionId = SubscriptionId;

            return securityCenterClient;
        }

        #endregion

        #region Security Connectors Tests

        [Fact]
        public async Task SecurityConnectors_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var securityConnectors = await securityCenterClient.SecurityConnectors.ListAsync();
                ValidateSecurityConnectors(securityConnectors);
            }
        }

        [Fact]
        public async Task SecurityConnectors_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var securityConnector = await securityCenterClient.SecurityConnectors.GetAsync(ResourceGroupName, SecurityConnectorName);
                ValidateSecurityConnector(securityConnector);
            }
        }

        #endregion

        #region Validations

        private void ValidateSecurityConnectors(IPage<SecurityConnector> securityConnectors)
        {
            Assert.True(securityConnectors.IsAny());

            securityConnectors.ForEach(ValidateSecurityConnector);
        }

        private void ValidateSecurityConnector(SecurityConnector securityConnector)
        {
            Assert.NotNull(securityConnector);
        }

        #endregion
    }
}
