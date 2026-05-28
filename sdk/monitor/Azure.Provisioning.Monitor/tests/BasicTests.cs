// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Monitor.Tests;

public class BasicMonitorTests
{
    internal static Trycep CreateServiceHealthAlertTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:MonitorServiceHealthAlert
                Infrastructure infra = new();

                ProvisioningParameter alertName =
                    new(nameof(alertName), typeof(string))
                    {
                        Description = "Specify the name of the alert."
                    };
                infra.Add(alertName);

                ProvisioningParameter emailAddress =
                    new(nameof(emailAddress), typeof(string))
                    {
                        Value = "email@example.com",
                        Description = "Specify the email address where the alerts are sent to."
                    };
                infra.Add(emailAddress);

                ProvisioningParameter emailName =
                    new(nameof(emailName), typeof(string))
                    {
                        Value = "Example",
                        Description = "Specify the email address name where the alerts are sent to."
                    };
                infra.Add(emailName);

                ActionGroup emailActionGroup =
                    new(nameof(emailActionGroup), ActionGroup.ResourceVersions.V2023_01_01)
                    {
                        Location = new AzureLocation("global"),
                        GroupShortName = "string",
                        IsEnabled = true,
                        EmailReceivers =
                        {
                            new MonitorEmailReceiver
                            {
                                Name = emailName,
                                EmailAddress = emailAddress,
                                UseCommonAlertSchema = true
                            }
                        }
                    };
                infra.Add(emailActionGroup);

                ActivityLogAlert alert =
                    new(nameof(alert), ActivityLogAlert.ResourceVersions.V2020_10_01)
                    {
                        Name = alertName,
                        Location = new AzureLocation("global"),
                        IsEnabled = true,
                        Scopes =
                        {
                            BicepFunction.GetSubscription().Id
                        },
                        ConditionAllOf =
                        {
                            new ActivityLogAlertAnyOfOrLeafCondition
                            {
                                Field = "category",
                                EqualsValue = "ResourceHealth"
                            }
                        },
                        ActionsActionGroups =
                        {
                            new ActivityLogAlertActionGroup
                            {
                                ActionGroupId = emailActionGroup.Id
                            }
                        }
                    };
                infra.Add(alert);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.insights/insights-alertrules-servicehealth/main.bicep")]
    public async Task CreateServiceHealthAlert()
    {
        await using Trycep test = CreateServiceHealthAlertTest();
        test.Compare(
            """
            @description('Specify the name of the alert.')
            param alertName string

            @description('Specify the email address where the alerts are sent to.')
            param emailAddress string = 'email@example.com'

            @description('Specify the email address name where the alerts are sent to.')
            param emailName string = 'Example'

            resource emailActionGroup 'Microsoft.Insights/actionGroups@2023-01-01' = {
              name: take('emailactiongroup${uniqueString(resourceGroup().id)}', 24)
              location: 'global'
              properties: {
                emailReceivers: [
                  {
                    name: emailName
                    emailAddress: emailAddress
                    useCommonAlertSchema: true
                  }
                ]
                groupShortName: 'string'
                enabled: true
              }
            }

            resource alert 'Microsoft.Insights/activityLogAlerts@2020-10-01' = {
              name: alertName
              location: 'global'
              properties: {
                actions: {
                  actionGroups: [
                    {
                      actionGroupId: emailActionGroup.id
                    }
                  ]
                }
                condition: {
                  allOf: [
                    {
                      field: 'category'
                      equals: 'ResourceHealth'
                    }
                  ]
                }
                enabled: true
                scopes: [
                  subscription().id
                ]
              }
            }
            """);
    }
}