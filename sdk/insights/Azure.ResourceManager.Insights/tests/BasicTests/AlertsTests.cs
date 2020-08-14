// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Insights.Models;
using Insights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    public class AlertsTests : InsightsManagementClientBase
    {
        private static readonly string RuleName = "r1";
        private static readonly string IncidentName = "i1";

        public AlertsTests(bool isAsync) : base(isAsync) { }

        [Test]
        public void GetIncidentTest()
        {
            var expectedIncident = GetIncidents().First();
            var serializedObject = expectedIncident.ToJson();

            var insightsClient = GetInsightsManagementClient(serializedObject);

            var actualIncident = insightsClient.AlertRuleIncidents.Get(
                resourceGroupName: RgName,
                ruleName: RuleName,
                incidentName: IncidentName);

            AreEqual(expectedIncident, actualIncident);
        }

        private static List<Incident> GetIncidents()
        {
            return new List<Incident>
            {
                new Incident(
                    activatedTime: DateTime.UtcNow,
                    isActive: false,
                    name: IncidentName,
                    resolvedTime: DateTime.UtcNow,
                    ruleName: RuleName
                )
            };
        }
    }
}
