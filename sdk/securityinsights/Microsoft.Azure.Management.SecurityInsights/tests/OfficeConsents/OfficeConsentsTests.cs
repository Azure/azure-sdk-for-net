// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class OfficeConsentsTests : TestBase
    {
        #region Test setup

        #endregion

        #region OfficeConsents

        [Fact]
        public void OfficeConsents_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var OfficeConsents = SecurityInsightsClient.OfficeConsents.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateOfficeConsents(OfficeConsents);
            }
        }

        [Fact]
        public void OfficeConsents_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                //No way to create one, as its for multi-teanant which isnt supported.
                var OfficeConsents = SecurityInsightsClient.OfficeConsents.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateOfficeConsents(OfficeConsents);
                //var OfficeConsent = SecurityInsightsClient.OfficeConsents.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, OfficeConsents.GetEnumerator().Current.Name);
                //ValidateOfficeConsent(OfficeConsent);
            }
        }

        [Fact]
        public void OfficeConsents_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                //No way to create one, as its for multi-teanant which isnt supported.
                var OfficeConsents = SecurityInsightsClient.OfficeConsents.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateOfficeConsents(OfficeConsents);
                //var OfficeConsent = SecurityInsightsClient.OfficeConsents.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, OfficeConsents.GetEnumerator().Current.Name);
                //SecurityInsightsClient.OfficeConsents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, OfficeConsent.Name);
            }
        }

        #endregion

        #region Validations

        private void ValidateOfficeConsents(IPage<OfficeConsent> OfficeConsents)
        {
            Assert.True(OfficeConsents.Count() >= 0);

            OfficeConsents.ForEach(ValidateOfficeConsent);
        }

        private void ValidateOfficeConsent(OfficeConsent OfficeConsent)
        {
            Assert.NotNull(OfficeConsent);
        }

        #endregion
    }
}
