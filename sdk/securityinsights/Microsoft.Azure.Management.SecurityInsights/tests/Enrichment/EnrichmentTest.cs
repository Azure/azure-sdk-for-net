// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class EnrichmentTests : TestBase
    {
        #region Test setup

        public static string IPAddress = "8.8.8.8";
        public static string Domain = "google.com";

        #endregion

        #region Enrichment

        [Fact]
        public void Enrichment_IPGeoData()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var Enrichment = SecurityInsightsClient.IPGeodata.Get(TestHelper.ResourceGroup, IPAddress);
                ValidateIPGeoData(Enrichment);
            }
        }

        [Fact]
        public void Enrichment_DomainWhois()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var Enrichment = SecurityInsightsClient.DomainWhois.Get(TestHelper.ResourceGroup, Domain);
                ValidateDomainWhois(Enrichment);
            }
        }

        #endregion

        #region Validations

        private void ValidateIPGeoData(EnrichmentIpGeodata Enrichment)
        {
            Assert.NotNull(Enrichment);
        }

        private void ValidateDomainWhois(EnrichmentDomainWhois Enrichment)
        {
            Assert.NotNull(Enrichment);
        }

        #endregion
    }
}
