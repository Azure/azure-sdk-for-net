// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Projects;

/// <summary>
/// Azure Developer CLI helpers.
/// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
public static class Azd
#pragma warning restore AZC0012 // Avoid single word type names
{
    private const string MainBicepName = "main";
    private const string ResourceGroupVersion = "2024-03-01";

    public static void Init(ProjectInfrastructure infra, string? infraDirectory = default)
    {
        if (infraDirectory == default)
            infraDirectory = Path.Combine(".", "infra");

        Directory.CreateDirectory(infraDirectory);

        infra.Build().Save(infraDirectory);
        var cmId = infra.ProjectId;

        // main.bicep
        var location = new ProvisioningParameter("location", typeof(string));
        var principalId = new ProvisioningParameter("principalId", typeof(string));

        ResourceGroup rg = new(nameof(rg), ResourceGroupVersion)
        {
            Name = cmId,
            Location = location
        };

        Infrastructure mainBicep = new("main")
        {
            TargetScope = DeploymentScope.Subscription
        };
        ModuleImport import = new("project", $"project.bicep")
        {
            Name = "cm",
            Scope = new IdentifierExpression(rg.BicepIdentifier)
        };
        import.Parameters.Add(nameof(location), location);
        import.Parameters.Add(nameof(principalId), principalId);

        mainBicep.Add(rg);
        mainBicep.Add(import);
        mainBicep.Add(location);
        mainBicep.Add(principalId);
        mainBicep.Build().Save(infraDirectory);

        WriteMainParametersFile(infraDirectory);
    }

    public static void InitDeployment(ProjectInfrastructure infra, string? webProjectName)
    {
        var webCsproj = webProjectName switch
        {
            null => ".",
            _ => webProjectName.EndsWith(".csproj") ? webProjectName : $"{webProjectName}.csproj"
        };
        var webProjDirectory = webCsproj switch
        {
            "." => null,
            _ => Directory
                    .GetFiles(Directory.GetCurrentDirectory(), "*" + webCsproj, SearchOption.AllDirectories)
                    .SingleOrDefault()
        };
        if (webProjDirectory != null)
        {
            webProjDirectory = Path.GetDirectoryName(webProjDirectory)?.Replace(Directory.GetCurrentDirectory(), ".");
        }
        WriteAzureYamlFile(webProjDirectory ?? "./", infra.ProjectId);
    }

    private static void WriteMainParametersFile(string infraDirectory)
    {
        File.WriteAllText(Path.Combine(infraDirectory, $"{MainBicepName}.parameters.json"),
        """
        {
          "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#",
          "contentVersion": "1.0.0.0",
          "parameters": {
            "environmentName": {
              "value": "${AZURE_ENV_NAME}"
            },
            "location" : {
              "value" : "${AZURE_LOCATION}"
            },
            "principalId": {
              "value": "${AZURE_PRINCIPAL_ID}"
            }
          }
        }
        """);
    }

    private static void WriteAzureYamlFile(string webProjDirectory, string cmId, string? hostType = "appservice")
    {
        if (webProjDirectory == ".")
        {
            webProjDirectory = "./";
        }

        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "azure.yaml"),
        $"""
name: {cmId}
resourceGroup: {cmId}
services:
  {cmId}:
    project: {webProjDirectory} # path to your web project
    language: csharp # one of the supported languages
    host: {hostType} # one of the supported Azure services
""");
    }
}
