// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppConfiguration.Tests;

public class BasicAppConfigurationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.appconfiguration/app-configuration-store-ff/main.bicep")]
    public async Task CreateAppConfigAndFeatureFlag()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location =
                    new(nameof(location), typeof(string))
                    {
                        Value = BicepFunction.GetResourceGroup().Location,
                        Description = "Config Store location."
                    };

                BicepParameter featureFlagKey =
                    new(nameof(featureFlagKey), typeof(string))
                    {
                        Value = "FeatureFlagSample",
                        Description = "Specifies the key of the feature flag."
                    };

                AppConfigurationStore configStore =
                    new(nameof(configStore), AppConfigurationStore.ResourceVersions.V2022_05_01)
                    {
                        Location = location,
                        SkuName = "Standard",
                    };

                BicepVariable flag =
                    new(nameof(flag), typeof(object))
                    {
                        Value =
                            new BicepDictionary<object>
                            {
                                { "id", featureFlagKey },
                                { "description", "A simple feature flag." },
                                { "enabled", true }
                            }
                    };

                AppConfigurationKeyValue featureFlag =
                    new(nameof(featureFlag), AppConfigurationKeyValue.ResourceVersions.V2022_05_01)
                    {
                        Parent = configStore,
                        Name = BicepFunction.Interpolate($".appconfig.featureflag~2F{featureFlagKey}"),
                        ContentType = "application/vnd.microsoft.appconfig.ff+json;charset=utf-8",
                        Value = BicepFunction.AsString(flag)
                    };
            })
        .Compare(
            """
            @description('Config Store location.')
            param location string = resourceGroup().location

            @description('Specifies the key of the feature flag.')
            param featureFlagKey string = 'FeatureFlagSample'

            resource configStore 'Microsoft.AppConfiguration/configurationStores@2022-05-01' = {
                name: take('configStore-${uniqueString(resourceGroup().id)}', 50)
                location: location
                sku: {
                    name: 'Standard'
                }
            }

            var flag = {
                id: featureFlagKey
                description: 'A simple feature flag.'
                enabled: true
            }

            resource featureFlag 'Microsoft.AppConfiguration/configurationStores/keyValues@2022-05-01' = {
                name: '.appconfig.featureflag~2FFeatureFlagSample'
                properties: {
                    contentType: 'application/vnd.microsoft.appconfig.ff+json;charset=utf-8'
                    value: string(flag)
                }
                parent: configStore
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
