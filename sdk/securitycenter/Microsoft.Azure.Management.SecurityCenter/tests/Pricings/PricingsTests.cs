// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class PricingsTests : TestBase
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

        #region Pricings Tests

        [Fact]
        public async Task Pricings_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricings = await securityCenterClient.Pricings.ListAsync();
                ValidatePricings(pricings);
            }
        }

        [Fact]
        public void Pricings_GetSubscriptionPricing()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricing = securityCenterClient.Pricings.Get("VirtualMachines");
                ValidatePricing(pricing);
            }
        }

        [Fact]
        public async Task Pricings_UpdateSubscriptionPricing()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricing = await securityCenterClient.Pricings.UpdateAsync("VirtualMachines", "Standard");
                ValidatePricing(pricing);
            }
        }

        #endregion

        #region Validations

        private void ValidatePricings(PricingList pricings)
        {
            Assert.NotEmpty(pricings.Value);

            pricings.Value.ForEach(ValidatePricing);
        }

        private void ValidatePricing(Pricing pricing)
        {
            Assert.NotNull(pricing);
        }

        #endregion
    }
}
