// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal static class MessageSenderExtensions
    {
        public static async Task SendAndCreateEntityIfNotExists(this MessageSender sender, Message message,
            Guid functionInstanceId, CancellationToken cancellationToken)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            ServiceBusCausalityHelper.EncodePayload(functionInstanceId, message);

            cancellationToken.ThrowIfCancellationRequested();

            await sender.SendAsync(message).ConfigureAwait(false);
            return;
        }
    }
}
