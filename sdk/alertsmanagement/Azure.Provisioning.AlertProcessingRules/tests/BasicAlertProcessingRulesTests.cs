// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AlertProcessingRules.Tests;

public class BasicAlertProcessingRulesTests
{
    internal static Trycep CreateAlertProcessingRuleTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AlertProcessingRulesBasic
                Infrastructure infra = new();

                AlertProcessingRule rule =
                    new(nameof(rule), AlertProcessingRule.ResourceVersions.V2021_08_08)
                    {
                        Location = new AzureLocation("global"),
                        Properties = new AlertProcessingRuleProperties
                        {
                            Scopes = { BicepFunction.GetSubscription().Id },
                            Conditions =
                            {
                                new AlertProcessingRuleCondition
                                {
                                    Field = AlertProcessingRuleField.TargetResourceType,
                                    Operator = AlertProcessingRuleOperator.EqualsValue,
                                    Values = { "microsoft.recoveryservices/vaults" },
                                },
                            },
                            Actions =
                            {
                                new AlertProcessingRuleAddGroupsAction
                                {
                                    ActionGroupIds =
                                    {
                                        new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example-rg/providers/Microsoft.Insights/actionGroups/backupAlertsActionGroup"),
                                    },
                                },
                            },
                            Description = "Sample alert processing rule",
                            IsEnabled = true,
                        },
                    };
                infra.Add(rule);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.recoveryservices/recovery-services-create-alert-processing-rule/main.bicep")]
    public async Task CreateBackupAlertProcessingRule()
    {
        await using Trycep test = CreateAlertProcessingRuleTest();
        test.Compare(
            """
            resource rule 'Microsoft.AlertsManagement/actionRules@2021-08-08' = {
              name: take('rule${uniqueString(resourceGroup().id)}', 24)
              location: 'global'
              properties: {
                scopes: [
                  subscription().id
                ]
                conditions: [
                  {
                    field: 'TargetResourceType'
                    operator: 'Equals'
                    values: [
                      'microsoft.recoveryservices/vaults'
                    ]
                  }
                ]
                actions: [
                  {
                    actionType: 'AddActionGroups'
                    actionGroupIds: [
                      '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example-rg/providers/Microsoft.Insights/actionGroups/backupAlertsActionGroup'
                    ]
                  }
                ]
                description: 'Sample alert processing rule'
                enabled: true
              }
            }
            """);
    }
}
