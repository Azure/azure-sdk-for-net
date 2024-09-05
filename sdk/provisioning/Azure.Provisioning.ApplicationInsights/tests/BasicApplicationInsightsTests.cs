// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ApplicationInsights.Tests;

public class BasicApplicationInsightsTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.web/function-app-create-dynamic/main.bicep")]
    public async Task CreateComponent()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "Service location.";

                ApplicationInsightsComponent appInsights =
                    new(nameof(appInsights))
                    {
                        Location = location,
                        Kind = "web",
                        ApplicationType = ApplicationInsightsApplicationType.Web,
                        RequestSource = ComponentRequestSource.Rest
                    };

                BicepOutput.Create<string>("appInsightsName", appInsights.Name);
                BicepOutput.Create<string>("appInsightsKey", appInsights.InstrumentationKey);
            })
        .Compare(
            """
            @description('Service location.')
            param location string = resourceGroup().location

            resource appInsights 'Microsoft.Insights/components@2020-02-02' = {
                name: take('appInsights-${uniqueString(resourceGroup().id)}', 260)
                kind: 'web'
                location: location
                properties: {
                    Application_Type: 'web'
                    Request_Source: 'rest'
                }
            }

            output appInsightsName string = appInsights.name

            output appInsightsKey string = appInsights.properties.InstrumentationKey
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
