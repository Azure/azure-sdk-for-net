// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

public partial class CloudMachineClient : CloudMachineWorkspace
{
    protected CloudMachineClient()
    { }
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    public CloudMachineClient(TokenCredential credential = default, IConfiguration configuration = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        : base(credential, configuration)
    {
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

    public MessagingServices Messaging { get; }
    public StorageServices Storage { get; }
}
