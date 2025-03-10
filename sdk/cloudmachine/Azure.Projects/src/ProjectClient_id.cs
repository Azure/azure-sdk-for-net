// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System;
using System.ComponentModel;

namespace Azure.Projects;

public partial class ProjectClient
{
    /// <summary>
    /// Reads the project ID from the appsettings.json file. If the file does not exist, it creates a new one with a generated project ID.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string ReadOrCreateProjectId()
    {
        string appsettings = Path.Combine(".", "appsettings.json");

        string cmid;
        if (!File.Exists(appsettings))
        {
            cmid = GenerateProjectId();

            using FileStream file = File.OpenWrite(appsettings);
            Utf8JsonWriter writer = new(file);
            writer.WriteStartObject();
            writer.WritePropertyName("AzureProject"u8);
            writer.WriteStartObject();
            writer.WriteString("ID"u8, cmid);
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();
            file.Close();
            return cmid;
        }

        using FileStream json = new FileStream(appsettings, FileMode.Open, FileAccess.Read, FileShare.Read);
        JsonDocumentOptions jsonDocumentOptions = new()
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip,
        };
        using JsonDocument jd = JsonDocument.Parse(json, jsonDocumentOptions);
        JsonElement je = jd.RootElement;
        // attempt to read CM configuration from existing configuration file
        if (je.TryGetProperty("AzureProject"u8, out JsonElement cm))
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
        {   // add CM configuration to existing file
            json.Seek(0, SeekOrigin.Begin);
            JsonNode root = JsonNode.Parse(json);
            json.Close();
            if (root is null || root is not JsonObject obj)
                throw new InvalidOperationException("Existing appsettings.json is not a valid JSON object");

            var cmProperties = new JsonObject();
            cmid = GenerateProjectId();
            cmProperties.Add("ID", cmid);
            obj.Add("AzureProject", cmProperties);

            using FileStream file = new FileStream(appsettings, FileMode.Open, FileAccess.Write, FileShare.None);
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

        return cmid;
    }

    private static string GenerateProjectId()
    {
        var guid = Guid.NewGuid();
        var guidString = guid.ToString("N");
        var cnId = "cm" + guidString.Substring(0, 15); // we can increase it to 20, but the template name cannot be that long
        return cnId;
    }
}
