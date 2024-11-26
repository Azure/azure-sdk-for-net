// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System;

namespace Azure.CloudMachine;

internal static class AppConfigHelpers
{
    public static string GenerateCloudMachineId()
    {
        var guid = Guid.NewGuid();
        var guidString = guid.ToString("N");
        var cnId = "cm" + guidString.Substring(0, 15); // we can increase it to 20, but the template name cannot be that long
        return cnId;
    }

    internal static string ReadOrCreateCmid()
    {
        string appsettingsPath = Path.Combine(".", "appsettings.json");

        if (TryReadCmId(appsettingsPath, out string? cmid)) return cmid!;

        cmid = GenerateCloudMachineId();

        if (!File.Exists(appsettingsPath))
        {
            CreateAppConfig(appsettingsPath, cmid);
        }
        else
        {
            AddCloudMachineId(appsettingsPath, cmid);
        }

        return cmid;
    }

    private static void CreateAppConfig(string appsettingsPath, string? cmid)
    {
        FileStream file = File.OpenWrite(appsettingsPath);
        Utf8JsonWriter writer = new(file);
        writer.WriteStartObject();
        writer.WritePropertyName("CloudMachine"u8);
        writer.WriteStartObject();
        writer.WriteString("ID"u8, cmid);
        writer.WriteEndObject();
        writer.WriteEndObject();
        writer.Flush();
    }

    private static bool TryReadCmId(string appsettings, out string? cmid)
    {
        using FileStream json = File.OpenRead(appsettings);
        using JsonDocument jd = JsonDocument.Parse(json);
        JsonElement je = jd.RootElement;
        if (je.TryGetProperty("CloudMachine"u8, out JsonElement cm))
        {
            if (!cm.TryGetProperty("ID"u8, out JsonElement id))
            {
                throw new NotImplementedException();
            }
            cmid = id.GetString();
            if (cmid == null)  throw new InvalidOperationException($"CloudMachine:ID in {appsettings} is invalid");
            return true;
        }
        else
        {
            cmid = null;
            return false;
        }
    }

    private static void AddCloudMachineId(string appsettings, string cmid)
    {
        FileStream json = File.OpenRead(appsettings);

        JsonNode? root = JsonNode.Parse(json);
        json.Close();
        if (root is null || root is not JsonObject obj)
            throw new InvalidOperationException("Existing appsettings.json is not a valid JSON object");

        var cmProperties = new JsonObject();
        cmid = GenerateCloudMachineId();
        cmProperties.Add("ID", cmid);
        obj.Add("CloudMachine", cmProperties);

        using FileStream file = File.OpenWrite(appsettings);
        JsonWriterOptions writerOptions = new()
        {
            Indented = true,
        };
        Utf8JsonWriter writer = new(file, writerOptions);
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
        };
        root.WriteTo(writer, options);
        writer.Flush();
    }
}
