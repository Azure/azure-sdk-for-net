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
    public class SettingsTests : TestBase
    {
        #region Test setup

        #endregion

        #region Settings

        [Fact]
        public void Settings_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var Settings = SecurityInsightsClient.ProductSettings.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateSettings(Settings);
            }
        }

        [Fact]
        public void Settings_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var SettingId = "Ueba";
                var UebaDataSources = new List<string>();
                UebaDataSources.Add("AuditLogs");
                var SettingsProperties = new Ueba()
                { 
                   DataSources = UebaDataSources,
                   Etag = "*"
                };

                var Setting = SecurityInsightsClient.ProductSettings.Update(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SettingId, SettingsProperties);
                ValidateSetting(Setting);
                SecurityInsightsClient.ProductSettings.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SettingId);
            }
        }

        [Fact]
        public void Settings_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var SettingId = "Ueba";
                var UebaDataSources = new List<string>();
                UebaDataSources.Add("AuditLogs");
                var SettingsProperties = new Ueba()
                {
                    DataSources = UebaDataSources,
                    Etag = "*"
                };

                SecurityInsightsClient.ProductSettings.Update(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SettingId, SettingsProperties);
                var Setting = SecurityInsightsClient.ProductSettings.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SettingId);
                ValidateSetting(Setting);
                SecurityInsightsClient.ProductSettings.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SettingId);

            }
        }

        [Fact]
        public void Settings_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var SettingId = "Ueba";
                var UebaDataSources = new List<string>();
                UebaDataSources.Add("AuditLogs");
                var SettingsProperties = new Ueba()
                {
                    DataSources = UebaDataSources,
                    Etag = "*"
                };

                SecurityInsightsClient.ProductSettings.Update(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SettingId, SettingsProperties);
                SecurityInsightsClient.ProductSettings.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SettingId);
            }
        }

        #endregion

        #region Validations

        private void ValidateSettings(SettingList SettingList)
        {
            Assert.True(SettingList.Value.IsAny());

            SettingList.Value.ForEach(ValidateSetting);
        }

        private void ValidateSetting(Settings Setting)
        {
            Assert.NotNull(Setting);
        }

        #endregion
    }
}
