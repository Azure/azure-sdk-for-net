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
        public void Pricings_List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricings = securityCenterClient.Pricings.List();
                ValidatePricings(pricings);
            }
        }

        [Fact]
        public void Pricings_CreateOrUpdateResourceGroupPricing()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricing = securityCenterClient.Pricings.CreateOrUpdateResourceGroupPricing("myService1", "myService1", "Standard");
                ValidatePricing(pricing);
            }
        }

        [Fact]
        public void Pricings_GetResourceGroupPricing()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricing = securityCenterClient.Pricings.GetResourceGroupPricing("myService1", "myService1");
                ValidatePricing(pricing);
            }
        }

        [Fact]
        public void Pricings_GetSubscriptionPricing()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricing = securityCenterClient.Pricings.GetSubscriptionPricing("default");
                ValidatePricing(pricing);
            }
        }

        [Fact]
        public void Pricings_ListByResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricing = securityCenterClient.Pricings.ListByResourceGroup("myService1");
                ValidatePricings(pricing);
            }
        }

        [Fact]
        public void Pricings_UpdateSubscriptionPricing()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricing = securityCenterClient.Pricings.UpdateSubscriptionPricing("default", "Standard");
                ValidatePricing(pricing);
            }
        }

        #endregion

        #region Validations

        private void ValidatePricings(IPage<Pricing> pricingPage)
        {
            Assert.True(pricingPage.IsAny());

            pricingPage.ForEach(ValidatePricing);
        }

        private void ValidatePricing(Pricing pricing)
        {
            Assert.NotNull(pricing);
        }

        #endregion
    }
}
