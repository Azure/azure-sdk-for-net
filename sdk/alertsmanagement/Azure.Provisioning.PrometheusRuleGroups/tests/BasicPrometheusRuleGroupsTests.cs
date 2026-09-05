// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.PrometheusRuleGroups.Tests;

public class BasicPrometheusRuleGroupsTests
{
    internal static Trycep CreatePrometheusRuleGroupTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:PrometheusRuleGroupsBasic
                Infrastructure infra = new();

                PrometheusRuleGroup ruleGroup =
                    new(nameof(ruleGroup), PrometheusRuleGroup.ResourceVersions.V2023_03_01)
                    {
                        Location = new AzureLocation("eastus"),
                        Description = "Sample recording rules",
                        Scopes =
                        {
                            new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example-rg/providers/Microsoft.Monitor/accounts/example-workspace"),
                        },
                        Rules =
                        {
                            new PrometheusRule
                            {
                                Record = "job:http_requests:rate5m",
                                Expression = "sum(rate(http_requests_total[5m])) by (job)",
                            },
                        },
                    };
                infra.Add(ruleGroup);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreatePrometheusRuleGroup()
    {
        await using Trycep test = CreatePrometheusRuleGroupTest();
        test.Compare(
            """
            resource ruleGroup 'Microsoft.AlertsManagement/prometheusRuleGroups@2023-03-01' = {
              name: take('ruleGroup-${uniqueString(resourceGroup().id)}', 24)
              location: 'eastus'
              properties: {
                description: 'Sample recording rules'
                scopes: [
                  '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example-rg/providers/Microsoft.Monitor/accounts/example-workspace'
                ]
                rules: [
                  {
                    record: 'job:http_requests:rate5m'
                    expression: 'sum(rate(http_requests_total[5m])) by (job)'
                  }
                ]
              }
            }
            """);
    }
}
