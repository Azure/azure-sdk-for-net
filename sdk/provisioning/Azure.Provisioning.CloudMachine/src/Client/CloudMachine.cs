// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

public partial class CloudMachineClient : WorkspaceClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override TokenCredential Credential { get; } = new ChainedTokenCredential(
        new AzureCliCredential(),
        new AzureDeveloperCliCredential()
    );

    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>")]
    public CloudMachineClient(DefaultAzureCredential? credential = default, IConfiguration? configuration = default)
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

    // this ctor is for mocking
    protected CloudMachineClient() => Id = "CM";

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override WorkspaceClientConnection? GetConnection(string clientId)
    {
        switch (clientId)
        {
            case "Azure.Security.KeyVault.Secrets.SecretClient":
                return new WorkspaceClientConnection($"https://{this.Id}.vault.azure.net/");
            case "Azure.Messaging.ServiceBus.ServiceBusClient":
                return new WorkspaceClientConnection($"{this.Id}.servicebus.windows.net");
            case "Azure.Messaging.ServiceBus.ServiceBusSender":
                return new WorkspaceClientConnection($"cm_default_topic_sender");
            case "Azure.Storage.Blobs.BlobContainerClient":
                return new WorkspaceClientConnection($"https://{this.Id}.blob.core.windows.net/default");
            case "Azure.AI.OpenAI.AzureOpenAIClient":
                string endpoint = $"https://{this.Id}.openai.azure.com";
                string key = Environment.GetEnvironmentVariable("openai_cm_key");
                if (key != null)
                    return new WorkspaceClientConnection(endpoint, key);
                else
                    return new WorkspaceClientConnection(endpoint);
            default:
                throw new Exception("unknown client");
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => base.Equals(obj);
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;
}
