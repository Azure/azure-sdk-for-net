// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

public class CloudMachineWorkspace : WorkspaceClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override TokenCredential Credential { get; } = new ChainedTokenCredential(
        new AzureCliCredential(),
        new AzureDeveloperCliCredential()
    );

    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>")]
    public CloudMachineWorkspace(DefaultAzureCredential? credential = default, IConfiguration? configuration = default)
    {
        if (credential != default)
        {
            Credential = credential;
        }

        string? cmid;
        if (configuration == default)
        {
            cmid = Azd.ReadOrCreateCmid();
        }
        else
        {
            cmid = configuration["CloudMachine:ID"];
            if (cmid == null)
            throw new Exception("CloudMachine:ID configuration value missing");
        }

        Id = cmid!;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientConfiguration? GetConfiguration(string clientId, string? instanceId = default)
    {
        switch (clientId)
        {
            case "Azure.Security.KeyVault.Secrets.SecretClient":
                return new ClientConfiguration($"https://{this.Id}.vault.azure.net/");
            case "Azure.Messaging.ServiceBus.ServiceBusClient":
                return new ClientConfiguration($"{this.Id}.servicebus.windows.net");
            case "Azure.Messaging.ServiceBus.ServiceBusSender":
                if (instanceId == default) instanceId = "cm_default_topic_sender";
                return new ClientConfiguration(instanceId);
            case "Azure.Storage.Blobs.BlobContainerClient":
                if (instanceId == default) instanceId = "default";
                return new ClientConfiguration($"https://{this.Id}.blob.core.windows.net/{instanceId}");
            case "Azure.AI.OpenAI.AzureOpenAIClient":
                string endpoint = $"https://{this.Id}.openai.azure.com";
                string? key = null; // Environment.GetEnvironmentVariable("openai_cm_key");
                if (key != null)
                    return new ClientConfiguration(endpoint, key);
                else
                    return new ClientConfiguration(endpoint);
            case "OpenAI.Chat.ChatClient":
                return new ClientConfiguration(this.Id);
            default:
                throw new Exception($"unknown client {clientId}");
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => base.Equals(obj);
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;
}
