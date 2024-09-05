// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CognitiveServices.Tests;

public class BasicCognitiveServicesTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cognitiveservices/cognitive-services-translate/main.bicep")]
    public async Task CreateTranslation()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location =
                    new(nameof(location), typeof(string))
                    {
                        Value = BicepFunction.GetResourceGroup().Location
                    };

                CognitiveServicesAccount account =
                    new(nameof(account))
                    {
                        Location = location,
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
            })
        .Compare(
            """
            param location string = resourceGroup().location

            resource account 'Microsoft.CognitiveServices/accounts@2022-12-01' = {
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
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
