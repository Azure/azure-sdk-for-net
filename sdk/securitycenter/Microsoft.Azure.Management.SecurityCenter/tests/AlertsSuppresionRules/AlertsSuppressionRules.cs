// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class AlertsSuppressionRulesTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static string AlertsSuppressionRuleName = "SdkTestAlertDismissRule";

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

        #region AlertsSuppressionRules Tests

        [Fact]
        public async Task AlertsSuppressionRules_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var alertsSuppressionRules = await securityCenterClient.AlertsSuppressionRules.ListAsync();
                var obj = JsonConvert.SerializeObject(alertsSuppressionRules);

                ValidateAlertsSuppressionRules(alertsSuppressionRules);
            }
        }

        [Fact]
        public async Task AlertsSuppressionRules_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alertsSuppressionRule = await securityCenterClient.AlertsSuppressionRules.GetAsync(AlertsSuppressionRuleName);
                ValidateAlertsSuppressionRule(alertsSuppressionRule);
            }
        }



        [Fact]
        public async Task AlertsSuppressionRules_CreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alertsSuppressionRuleToCreateOrUpdate = new AlertsSuppressionRule()
                {
                    AlertType = "TestType",
                    ExpirationDateUtc = DateTime.UtcNow + TimeSpan.FromDays(365),
                    State = RuleState.Enabled,
                    Reason = "Other",
                    Comment = "free text",
                    SuppressionAlertsScope = new SuppressionAlertsScope()
                    {
                        AllOf = new List<ScopeElement>()
                            {
                                new ScopeElement()
                                {
                                    Field = "entities.ip.address",
                                    AdditionalProperties = new Dictionary<string, object>()
                                    {
                                        {
                                            "in", new[] { "127.0.0.1", "192.168.0.1" }
                                        }
                                    }
                                },
                                new ScopeElement()
                                {
                                    Field = "entities.process.commandline",
                                    AdditionalProperties = new Dictionary<string, object>()
                                    {
                                        {
                                            "contains", "powershell.exe"
                                        }
                                    }
                                }
                            }
                    }
                };
                // TODO elgrady - change operationId to CreateOrUpdate instead of Update
                var alertsSuppressionRule = await securityCenterClient.AlertsSuppressionRules.UpdateAsync(AlertsSuppressionRuleName, alertsSuppressionRuleToCreateOrUpdate);
                ValidateAlertsSuppressionRule(alertsSuppressionRule);
            }
        }

        #endregion

        #region Validations

        private void ValidateAlertsSuppressionRules(IPage<AlertsSuppressionRule> alertsSuppressionRules)
        {
            Assert.True(alertsSuppressionRules.IsAny());

            alertsSuppressionRules.ForEach(ValidateAlertsSuppressionRule);
        }

        private void ValidateAlertsSuppressionRule(AlertsSuppressionRule alertsSuppressionRule)
        {
            Assert.NotNull(alertsSuppressionRule);
        }

        #endregion
    }
}
