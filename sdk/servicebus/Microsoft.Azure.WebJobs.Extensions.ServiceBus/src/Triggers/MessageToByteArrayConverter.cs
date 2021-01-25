// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    internal class MessageToByteArrayConverter : IAsyncConverter<Message, byte[]>
    {
        public Task<byte[]> ConvertAsync(Message input, CancellationToken cancellationToken)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(input.Body);
        }
    }
}