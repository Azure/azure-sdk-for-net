// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
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
                var pricing = await securityCenterClient.Pricings.UpdateAsync("VirtualMachines", new Pricing("Standard"));
                ValidatePricing(pricing);
            }
        }

        [Fact]
        public void Pricings_GetSubscriptionPricingWithExtensions()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var pricing = securityCenterClient.Pricings.Get("CloudPosture");
                ValidateExtensions(pricing);
            }
        }

        [Fact]
        public async Task Pricings_UpdateSubscriptionPricingExtension()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var extensions = new List<Extension>()
                {
                    new Extension("AgentlessVmScanning", "True"),
                    new Extension("AgentlessDiscoveryForKubernetes", "False")
                };
                var pricing = await securityCenterClient.Pricings.UpdateAsync("CloudPosture", new Pricing("Standard", extensions: extensions));
                ValidateExtensionsUpdate(pricing, extensions);
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

        private void ValidateExtensions(Pricing pricing)
        {
            Assert.NotNull(pricing);
            Assert.NotNull(pricing.Extensions);
            Assert.NotEmpty(pricing.Extensions);
        }

        private void ValidateExtensionsUpdate(Pricing pricing, List<Extension> desiredExtensions)
        {
            Assert.NotNull(pricing);
            Assert.NotNull(pricing.Extensions);
            Assert.NotEmpty(pricing.Extensions);
            var flatenDesired = desiredExtensions.ToDictionary(extension => extension.Name, extension => extension);
            var validExtensionsCount = pricing.Extensions.Where(extension => flatenDesired.ContainsKey(extension.Name) && flatenDesired[extension.Name].IsEnabled.Equals(extension.IsEnabled)).Count();
            Assert.Equal(desiredExtensions.Count, validExtensionsCount);
        }


        #endregion
    }
}
