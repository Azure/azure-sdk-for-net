// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

public partial class CloudMachineClient : CloudMachineWorkspace
{
    public CloudMachineClient(TokenCredential? credential = default, IConfiguration? configuration = default)
        : base(credential, configuration)
    {
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

    public MessagingServices Messaging { get; }
    public StorageServices Storage { get; }
}
