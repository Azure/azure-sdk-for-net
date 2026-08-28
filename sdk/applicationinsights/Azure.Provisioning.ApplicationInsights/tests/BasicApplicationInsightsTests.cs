// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
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

    internal static Trycep CreateLinkedStorageAccountsTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ApplicationInsightsComponent appInsights =
                    new(nameof(appInsights))
                    {
                        Kind = "web",
                        ApplicationType = ApplicationInsightsApplicationType.Web
                    };
                infra.Add(appInsights);

                ComponentLinkedStorageAccounts linkedStorage =
                    new(nameof(linkedStorage))
                    {
                        Name = "ServiceProfiler",
                        Parent = appInsights,
                        LinkedStorageAccount = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/storage"
                    };
                infra.Add(linkedStorage);

                return infra;
            });
    }

    internal static Trycep CreateWorkbookRevisionTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ApplicationInsightsWorkbook workbook = ApplicationInsightsWorkbook.FromExisting(nameof(workbook));
                workbook.Name = "00000000-0000-0000-0000-000000000000";
                infra.Add(workbook);

                ApplicationInsightsWorkbookRevision revision =
                    new(nameof(revision))
                    {
                        Name = "revision-1",
                        Parent = workbook,
                        DisplayName = "Workbook revision",
                        SerializedData = "{}",
                        Category = "workbook"
                    };
                infra.Add(revision);

                return infra;
            });
    }

    internal static Trycep CreateWorkbookTemplateTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ApplicationInsightsWorkbookTemplate workbookTemplate =
                    new(nameof(workbookTemplate))
                    {
                        TemplateData = new ObjectExpression(),
                        Galleries = new BicepList<WorkbookTemplateGallery>(),
                        LocalizedGalleries = new BicepDictionary<BicepList<WorkbookTemplateLocalizedGallery>>
                        {
                            ["en-US"] = new BicepList<WorkbookTemplateLocalizedGallery>
                            {
                                new WorkbookTemplateLocalizedGallery()
                            }
                        }
                    };
                infra.Add(workbookTemplate);

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
              location: location
              kind: 'web'
              properties: {
                Application_Type: 'web'
                Request_Source: 'rest'
              }
            }

            output appInsightsName string = appInsights.name

            output appInsightsKey string = appInsights.properties.InstrumentationKey
            """);
    }

    [Test]
    public async Task CreateLinkedStorageAccounts()
    {
        await using Trycep test = CreateLinkedStorageAccountsTest();
        test.Compare(
            string.Join(
                "\n",
                new[]
                {
                    "@description('The location for the resource(s) to be deployed.')",
                    "param location string = resourceGroup().location",
                    "",
                    "resource appInsights 'Microsoft.Insights/components@2020-02-02' = {",
                    "  name: take('appInsights-${uniqueString(resourceGroup().id)}', 260)",
                    "  location: location",
                    "  kind: 'web'",
                    "  properties: {",
                    "    Application_Type: 'web'",
                    "  }",
                    "}",
                    "",
                    "resource linkedStorage 'Microsoft.Insights/components/linkedStorageAccounts@2020-03-01-preview' = {",
                    "  name: 'ServiceProfiler'",
                    "  properties: {",
                    "    linkedStorageAccount: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/storage'",
                    "  }",
                    "  parent: appInsights",
                    "}"
                }));
    }

    [Test]
    public async Task CreateWorkbookRevision()
    {
        await using Trycep test = CreateWorkbookRevisionTest();
        test.Compare(
            string.Join(
                "\n",
                new[]
                {
                    "@description('The location for the resource(s) to be deployed.')",
                    "param location string = resourceGroup().location",
                    "",
                    "resource workbook 'Microsoft.Insights/workbooks@2023-06-01' existing = {",
                    "  name: '00000000-0000-0000-0000-000000000000'",
                    "}",
                    "",
                    "resource revision 'Microsoft.Insights/workbooks/revisions@2023-06-01' = {",
                    "  name: 'revision-1'",
                    "  location: location",
                    "  properties: {",
                    "    displayName: 'Workbook revision'",
                    "    serializedData: '{}'",
                    "    category: 'workbook'",
                    "  }",
                    "  parent: workbook",
                    "}"
                }));
    }

    [Test]
    public async Task CreateWorkbookTemplate()
    {
        await using Trycep test = CreateWorkbookTemplateTest();
        test.Compare(
            string.Join(
                "\n",
                new[]
                {
                    "@description('The location for the resource(s) to be deployed.')",
                    "param location string = resourceGroup().location",
                    "",
                    "resource workbookTemplate 'Microsoft.Insights/workbooktemplates@2020-11-20' = {",
                    "  name: take('workbooktemplate${uniqueString(resourceGroup().id)}', 24)",
                    "  location: location",
                    "  properties: {",
                    "    templateData: { }",
                    "    galleries: []",
                    "    localized: {",
                    "      'en-US': [",
                    "        { }",
                    "      ]",
                    "    }",
                    "  }",
                    "}"
                }));
    }
}
