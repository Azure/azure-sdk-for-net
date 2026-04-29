// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Logic.Tests;

public class BasicLogicTests
{
    internal static Trycep CreateIntegrationAccountTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:LogicIntegrationAccountBasic
                Infrastructure infra = new();

                IntegrationAccount account =
                    new(nameof(account))
                    {
                        SkuName = IntegrationAccountSkuName.Standard,
                    };
                infra.Add(account);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.logic/integrationaccounts?pivots=deployment-language-bicep")]
    public async Task CreateIntegrationAccount()
    {
        await using Trycep test = CreateIntegrationAccountTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource account 'Microsoft.Logic/integrationAccounts@2019-05-01' = {
              name: take('account${uniqueString(resourceGroup().id)}', 24)
              location: location
              sku: {
                name: 'Standard'
              }
            }
            """);
    }
}
