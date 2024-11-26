// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

/// <summary>
/// The cloud machine workspace.
/// </summary>
public class CloudMachineWorkspace : ClientWorkspace
{
    private TokenCredential Credential { get; }
    private Dictionary<string, object> Connections { get; }

    /// <summary>
    /// The cloud machine ID.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineWorkspace"/> class.
    /// </summary>
    /// <param name="credential"></param>
    /// <param name="configuration"></param>
    /// <param name="connections"></param>
    /// <exception cref="Exception"></exception>
    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>")]
    public CloudMachineWorkspace(TokenCredential credential = default, IConfiguration configuration = default, Dictionary<string, object> connections = default)
    {
        if (credential != default)
        {
            Credential = credential;
        }
        else
        {
            // This environment variable is set by the CloudMachine App Service feature during provisioning.
            Credential = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID") switch
            {
                string clientId when !string.IsNullOrEmpty(clientId) => new ManagedIdentityCredential(clientId),
                _ => new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential())
            };
        }

        if (connections != default)
        {
            Connections = connections;
        }
        else
        {
            Connections = new();
        }

        Id = configuration switch
        {
            null => ReadOrCreateCmid(),
            _ => configuration["CloudMachine:ID"] ?? throw new Exception("CloudMachine:ID configuration value missing")
        };
    }

    /// <summary>
    /// Retrieves the connection options for a specified client type and instance ID.
    /// </summary>
    /// <param name="clientType"></param>
    /// <param name="instanceId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientConnectionOptions GetConnectionOptions(Type clientType, string instanceId)
    {
        string clientId = clientType.FullName;
        if (instanceId != null && instanceId.StartsWith("$"))
            clientId = $"{clientType.FullName}{instanceId}";

        return clientId switch
        {
            "Azure.Security.KeyVault.Secrets.SecretClient" => new ClientConnectionOptions(new($"https://{Id}.vault.azure.net/"), Credential),
            "Azure.Messaging.ServiceBus.ServiceBusClient" => new ClientConnectionOptions(new($"https://{Id}.servicebus.windows.net"), Credential),
            "Azure.Messaging.ServiceBus.ServiceBusSender" => new ClientConnectionOptions(instanceId ?? "cm_servicebus_default_topic"),
            "Azure.Messaging.ServiceBus.ServiceBusProcessor" => new ClientConnectionOptions("cm_servicebus_default_topic/cm_servicebus_subscription_default"),
            "Azure.Messaging.ServiceBus.ServiceBusProcessor$private" => new ClientConnectionOptions("cm_servicebus_topic_private/cm_servicebus_subscription_private"),
            "Azure.Storage.Blobs.BlobContainerClient" => new ClientConnectionOptions(new($"https://{Id}.blob.core.windows.net/{instanceId ?? "default"}"), Credential),
            _ => GetExtensionConnection(clientId)
        };

        ClientConnectionOptions GetExtensionConnection(string clientId)
        {
            if (Connections.TryGetValue(clientId, out object connection))
            {
                if (connection is Uri uri)
                {
                    return new ClientConnectionOptions(uri, Credential);
                }
                if (connection is string str)
                {
                    return new ClientConnectionOptions(str);
                }
                throw new NotImplementedException();
            }
            throw new Exception($"unknown client {clientId}");
        };
    }

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => base.Equals(obj);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;

    // TODO: Decide if this should live here.
    internal static string ReadOrCreateCmid()
    {
        string appsettings = Path.Combine(".", "appsettings.json");

        string cmid;
        if (!File.Exists(appsettings))
        {
            cmid = GenerateCloudMachineId();

            using FileStream file = File.OpenWrite(appsettings);
            Utf8JsonWriter writer = new(file);
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
        {   // add CM configuration to existing file
            json.Seek(0, SeekOrigin.Begin);
            JsonNode root = JsonNode.Parse(json);
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
