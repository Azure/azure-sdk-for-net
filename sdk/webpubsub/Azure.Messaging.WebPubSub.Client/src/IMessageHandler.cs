// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal interface IMessageHandler
    {
        Task HandleMessageAsync(WebPubSubMessage message, CancellationToken token);
    }
}
