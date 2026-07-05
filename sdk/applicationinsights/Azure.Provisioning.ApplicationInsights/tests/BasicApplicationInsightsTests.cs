// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Provisioning.ApplicationInsights.Tests;

public class BasicApplicationInsightsTests
{
    internal static Trycep CreateComponentTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ApplicationInsightsBasic
                Infrastructure infra = new();

                ApplicationInsightsComponent appInsights =
                    new(nameof(appInsights))
                    {
                        Kind = "web",
                        ApplicationType = ApplicationInsightsApplicationType.Web,
                        RequestSource = ComponentRequestSource.Rest
                    };
                infra.Add(appInsights);

                infra.Add(new ProvisioningOutput("appInsightsName", typeof(string)) { Value = appInsights.Name });
                infra.Add(new ProvisioningOutput("appInsightsKey", typeof(string)) { Value = appInsights.InstrumentationKey });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.web/function-app-create-dynamic/main.bicep")]
    public async Task CreateComponent()
    {
        await using Trycep test = CreateComponentTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
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
            """);
    }
}
