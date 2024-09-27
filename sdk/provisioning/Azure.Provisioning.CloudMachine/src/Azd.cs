// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Provisioning;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Expressions;
using System.Text.Json.Nodes;
using System.Text.Json;
using System;

namespace Azure.CloudMachine;

internal static class Azd
{
    private const string MainBicepName = "main";
    private const string ResourceGroupVersion = "2024-03-01";

    internal static void Init(string infraDirectory, CloudMachineInfrastructure cmi)
    {
        Directory.CreateDirectory(infraDirectory);

        cmi.Build().Save(infraDirectory);
        var cmid = ReadOrCreateCmid();

        // main.bicep
        var location = new ProvisioningParameter("location", typeof(string));
        var principalId = new ProvisioningParameter("principalId", typeof(string));

        ResourceGroup rg = new(nameof(rg), ResourceGroupVersion)
        {
            Name = cmid,
            Location = location
        };

        Infrastructure mainBicep = new("main")
        {
            TargetScope = "subscription"
        };
        ModuleImport import = new("cm", $"cm.bicep")
        {
            Name = "cm",
            Scope = new IdentifierExpression(rg.ResourceName)
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

    internal static string ReadOrCreateCmid()
    {
        string appsettings = Path.Combine(".", "appsettings.json");

        string? cmid;
        if (!File.Exists(appsettings))
        {
            cmid = GenerateCloudMachineId();

            using FileStream file = File.OpenWrite(appsettings);
            Utf8JsonWriter writer = new Utf8JsonWriter(file);
            writer.WriteStartObject();
            writer.WritePropertyName("CloudMachine"u8);
            writer.WriteStartObject();
            writer.WriteString("ID"u8, cmid);
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();
            return cmid;
        }

        using FileStream json = File.OpenRead(appsettings);
        using JsonDocument jd = JsonDocument.Parse(json);
        JsonElement je = jd.RootElement;
        // attempt to read CM configuration from existing configuration file
        if (je.TryGetProperty("CloudMachine"u8, out JsonElement cm))
        {
            if (!cm.TryGetProperty("ID"u8, out JsonElement id))
            {
                throw new NotImplementedException();
            }
            cmid = id.GetString();
            if (cmid == null)
                throw new NotImplementedException();
            return cmid;
        }
        else
        { // add CM configuration to existing file
            JsonNode? root = JsonValue.Parse(appsettings);
            if (root is null)
                throw new NotImplementedException();

            if (root is not JsonObject obj)
                throw new NotImplementedException();

            var cmProperties = new JsonObject();
            cmid = GenerateCloudMachineId();
            cmProperties.Add("ID", cmid);
            obj.Add("CloudMachine", cmProperties);
        }

        return cmid;

        static string GenerateCloudMachineId()
        {
            var guid = Guid.NewGuid();
            var guidString = guid.ToString("N");
            var cnId = "cm" + guidString.Substring(0, 15); // we can increase it to 20, but the template name cannot be that long
            return cnId;
        }
    }
}
