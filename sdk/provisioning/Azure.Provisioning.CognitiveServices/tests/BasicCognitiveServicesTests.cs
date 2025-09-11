// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CognitiveServices.Tests;

public class BasicCognitiveServicesTests
{
    internal static Trycep CreateTranslationTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:CognitiveServicesBasic
                Infrastructure infra = new();

                CognitiveServicesAccount account =
                    new(nameof(account))
                    {
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                        Kind = "TextTranslation",
                        Sku = new CognitiveServicesSku { Name = "S1" },
                        Properties = new CognitiveServicesAccountProperties
                        {
                            PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Disabled,
                            NetworkAcls = new CognitiveServicesNetworkRuleSet
                            {
                                DefaultAction = CognitiveServicesNetworkRuleAction.Deny
                            },
                            DisableLocalAuth = true
                        }
                    };
                infra.Add(account);
                #endregion

                return infra;
            });
    }
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cognitiveservices/cognitive-services-translate/main.bicep")]
    public async Task CreateTranslation()
    {
        await using Trycep test = CreateTranslationTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource account 'Microsoft.CognitiveServices/accounts@2024-10-01' = {
              name: take('account-${uniqueString(resourceGroup().id)}', 64)
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              kind: 'TextTranslation'
              properties: {
                networkAcls: {
                  defaultAction: 'Deny'
                }
                publicNetworkAccess: 'Disabled'
                disableLocalAuth: true
              }
              sku: {
                name: 'S1'
              }
            }
            """);
    }
}
