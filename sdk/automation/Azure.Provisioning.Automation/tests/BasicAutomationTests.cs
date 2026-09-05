// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Automation.Tests;

public class BasicAutomationTests
{
    internal static Trycep CreateAutomationAccountTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AutomationAccountBasic
                Infrastructure infra = new();

                AutomationAccount account =
                    new(nameof(account), AutomationAccount.ResourceVersions.V2024_10_23)
                    {
                        Tags = { ["environment"] = "test" },
                        Sku = new AutomationSku
                        {
                            Name = AutomationSkuName.Basic,
                        },
                        Description = "Test automation account",
                        IsPublicNetworkAccessAllowed = true,
                    };
                infra.Add(account);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateAutomationAccount()
    {
        await using Trycep test = CreateAutomationAccountTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource account 'Microsoft.Automation/automationAccounts@2024-10-23' = {
              name: take('account${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                sku: {
                  name: 'Basic'
                }
                description: 'Test automation account'
                publicNetworkAccess: true
              }
            }
            """);
    }
}
