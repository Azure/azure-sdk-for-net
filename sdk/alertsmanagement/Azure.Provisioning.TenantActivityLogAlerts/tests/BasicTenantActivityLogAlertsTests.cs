// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.TenantActivityLogAlerts.Tests;

public class BasicTenantActivityLogAlertsTests
{
    internal static Trycep CreateTenantActivityLogAlertTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:TenantActivityLogAlertsBasic
                Infrastructure infra = new();

                TenantActivityLogAlert alert =
                    new(nameof(alert), TenantActivityLogAlert.ResourceVersions.V2023_04_01_PREVIEW)
                    {
                        Location = new AzureLocation("global"),
                        Scopes = { "/providers/Microsoft.Management/managementGroups/example-group" },
                        ConditionAllOf =
                        {
                            new TenantActivityLogAlertAnyOfOrLeafCondition
                            {
                                Field = "category",
                                EqualTo = "Administrative",
                            },
                        },
                        ActionsActionGroups =
                        {
                            new TenantActivityLogAlertActionGroup
                            {
                                ActionGroupId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example-rg/providers/Microsoft.Insights/actionGroups/example-action-group"),
                            },
                        },
                        IsEnabled = true,
                        Description = "Sample tenant activity log alert",
                    };
                infra.Add(alert);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateTenantActivityLogAlert()
    {
        await using Trycep test = CreateTenantActivityLogAlertTest();
        test.Compare(
            """
            resource alert 'Microsoft.AlertsManagement/tenantActivityLogAlerts@2023-04-01-preview' = {
              name: take('alert-${uniqueString(resourceGroup().id)}', 24)
              properties: {
                scopes: [
                  '/providers/Microsoft.Management/managementGroups/example-group'
                ]
                condition: {
                  allOf: [
                    {
                      field: 'category'
                      equals: 'Administrative'
                    }
                  ]
                }
                actions: {
                  actionGroups: [
                    {
                      actionGroupId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example-rg/providers/Microsoft.Insights/actionGroups/example-action-group'
                    }
                  ]
                }
                enabled: true
                description: 'Sample tenant activity log alert'
              }
              location: 'global'
            }
            """);
    }
}
