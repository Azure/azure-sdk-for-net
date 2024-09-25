// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Azure.CloudMachine;

public static class MessagingServices
{
    public static string Send(this CloudMachineClient cm, object json)
    {
        ServiceBusClient sb = new(cm.Properties.ServiceBusNamespace, cm.Credential);
        ServiceBusSender sender = sb.CreateSender("cm_default_topic");
        throw new NotImplementedException();
    }
}
