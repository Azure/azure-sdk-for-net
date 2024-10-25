// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Identity;
using Azure.Provisioning.CloudMachine;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

public class CloudMachineWorkspace : ClientWorkspace
{
    private TokenCredential Credential { get; } = new ChainedTokenCredential(
        new AzureCliCredential(),
        new AzureDeveloperCliCredential()
    );

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>")]
    public CloudMachineWorkspace(TokenCredential? credential = default, IConfiguration? configuration = default)
    {
        if (credential != default)
        {
            Credential = credential;
        }

        string? cmid;
        if (configuration == default)
        {
            cmid = AzdHelpers.ReadOrCreateCmid();
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
    public override ClientConnectionOptions GetConnectionOptions(Type clientType, string? instanceId = default)
    {
        string clientId = clientType.FullName;
        switch (clientId)
        {
            case "Azure.Security.KeyVault.Secrets.SecretClient":
                return new ClientConnectionOptions(new($"https://{this.Id}.vault.azure.net/"), Credential);
            case "Azure.Messaging.ServiceBus.ServiceBusClient":
                return new ClientConnectionOptions(new($"https://{this.Id}.servicebus.windows.net"), Credential);
            case "Azure.Messaging.ServiceBus.ServiceBusSender":
                if (instanceId == default) instanceId = CloudMachineInfrastructure.SB_PRIVATE_TOPIC;
                return new ClientConnectionOptions(instanceId);
            case "Azure.Storage.Blobs.BlobContainerClient":
                if (instanceId == default) instanceId = "default";
                return new ClientConnectionOptions(new($"https://{this.Id}.blob.core.windows.net/{instanceId}"), Credential);
            case "Azure.AI.OpenAI.AzureOpenAIClient":
                return new ClientConnectionOptions(new($"https://{this.Id}.openai.azure.com"), Credential);
            case "OpenAI.Chat.ChatClient":
                return new ClientConnectionOptions(Id);
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
