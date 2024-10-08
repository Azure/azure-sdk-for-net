// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

public partial class CloudMachineClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TokenCredential Credential { get; } = new ChainedTokenCredential(
        new AzureDeveloperCliCredential()
    );

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>")]
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

    protected CloudMachineClient()
    {
        Id = "CM";
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientCache ClientCache { get; } = new ClientCache();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CloudMachineProperties Properties => new CloudMachineProperties(this);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct CloudMachineProperties
    {
        private readonly CloudMachineClient _cm;

        internal CloudMachineProperties(CloudMachineClient cm) => _cm = cm;
        public Uri DefaultContainerUri => new Uri($"https://{_cm.Id}.blob.core.windows.net/default");
        public Uri BlobServiceUri => new Uri($"https://{_cm.Id}.blob.core.windows.net/");
        public Uri KeyVaultUri => new Uri($"https://{_cm.Id}.vault.azure.net/");

        public string ServiceBusNamespace => $"{_cm.Id}.servicebus.windows.net";
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => base.Equals(obj);
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;
}
