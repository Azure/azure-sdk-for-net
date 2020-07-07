// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Protocols
{
    /// <summary>Represents a host message sender.</summary>
    public class HostMessageSender : IHostMessageSender
    {
        private readonly CloudQueueClient _client;

        /// <summary>Initializes a new instance of the <see cref="HostMessageSender"/> class.</summary>
        /// <param name="client">A queue client for the storage account where the host listens.</param>
        public HostMessageSender(CloudQueueClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            _client = client;
        }

        /// <inheritdoc />
        public async Task EnqueueAsync(string queueName, HostMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            CloudQueue queue = _client.GetQueueReference(queueName);
            Debug.Assert(queue != null);
            await queue.CreateIfNotExistsAsync();
            string content = JsonConvert.SerializeObject(message, JsonSerialization.Settings);
            Debug.Assert(content != null);
            CloudQueueMessage queueMessage = new CloudQueueMessage(content);
            await queue.AddMessageAsync(queueMessage);
        }
    }
}
