// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Queue.Protocol;

namespace FakeStorage
{
    public class FakeQueue : CloudQueue
    {
        private FakeQueueClient _client;
        private MemoryQueueStore _store;

        public static Uri FakeUri = new Uri("https://fakeaccount.queue.core.windows.net");

        public FakeQueue(FakeQueueClient client, string queueName) : base(
            GetQueueUri(queueName), client.Credentials
            )
        {
            _client = client;
            _store = _client._account._queueStore;

            this.SetInternalProperty(nameof(CloudQueue.ServiceClient), _client);
        }

        static internal Uri GetQueueUri(string queueName)
        {
            return new Uri(FakeUri.ToString() + queueName); // Uri already has trailing slash 
        }

        public override Task AddMessageAsync(CloudQueueMessage message)
        {
            // throw new NotImplementedException();
            return base.AddMessageAsync(message);
        }

        public override Task AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext)
        {
            //throw new NotImplementedException();
            return base.AddMessageAsync(message, timeToLive, initialVisibilityDelay, options, operationContext);
        }

        public override Task AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            _store.AddMessage(this.Name, message);
            return Task.FromResult(0);
        }

        public override Task ClearAsync()
        {
            _store.Clear(this.Name);
            return Task.CompletedTask;
        }

        public override Task ClearAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.ClearAsync(options, operationContext);
        }

        public override Task ClearAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.ClearAsync(options, operationContext, cancellationToken);
        }

        public override Task CreateAsync()
        {
            //throw new NotImplementedException();
            return base.CreateAsync();
        }

        public override Task CreateAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            //throw new NotImplementedException();
            return base.CreateAsync(options, operationContext);
        }

        public override Task CreateAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            _store.CreateIfNotExists(this.Name);
            return Task.FromResult(0);

            // throw new NotImplementedException();
            // return base.CreateAsync(options, operationContext, cancellationToken);
        }

        public override Task<bool> CreateIfNotExistsAsync()
        {
            //throw new NotImplementedException();
            return base.CreateIfNotExistsAsync();
        }

        public override Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            //throw new NotImplementedException();
            return base.CreateIfNotExistsAsync(options, operationContext);
        }

        public override Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            // return base.CreateIfNotExistsAsync(options, operationContext, cancellationToken);
            _store.CreateIfNotExists(this.Name);
            return Task.FromResult(true);
        }

        public override Task DeleteAsync()
        {
            throw new NotImplementedException();
            // return base.DeleteAsync();
        }

        public override Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException(); 
            // return base.DeleteAsync(options, operationContext);
        }

        public override Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(); 
            // return base.DeleteAsync(options, operationContext, cancellationToken);
        }

        public override Task<bool> DeleteIfExistsAsync()
        {
            throw new NotImplementedException();
            // return base.DeleteIfExistsAsync();
        }

        public override Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.DeleteIfExistsAsync(options, operationContext);
        }

        public override Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.DeleteIfExistsAsync(options, operationContext, cancellationToken);
        }

        public override Task DeleteMessageAsync(CloudQueueMessage message)
        {
            // throw new NotImplementedException();
            return base.DeleteMessageAsync(message);
        }

        public override Task DeleteMessageAsync(CloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext)
        {
            // throw new NotImplementedException();
            return base.DeleteMessageAsync(message, options, operationContext);            
        }

        public override Task DeleteMessageAsync(CloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            _store.DeleteMessage(this.Name, message);
            return Task.CompletedTask;
        }

        public override Task DeleteMessageAsync(string messageId, string popReceipt)
        {
            throw new NotImplementedException();
            // return base.DeleteMessageAsync(messageId, popReceipt);
        }

        public override Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.DeleteMessageAsync(messageId, popReceipt, options, operationContext);
        }

        public override Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.DeleteMessageAsync(messageId, popReceipt, options, operationContext, cancellationToken);
        }

        public override bool Equals(object obj)
        {
            if (obj is FakeQueue other)
            {
                return this.Uri == other.Uri;
            }
            return false;
        }

        public override Task<bool> ExistsAsync()
        {
            // throw new NotImplementedException();
            // return base.ExistsAsync();
            return Task.FromResult(_store.Exists(this.Name));
        }

        public override Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            // throw new NotImplementedException();
            // return base.ExistsAsync(options, operationContext);
            return Task.FromResult(_store.Exists(this.Name));
        }

        public override Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            // throw new NotImplementedException();
            // return base.ExistsAsync(options, operationContext, cancellationToken);
            return Task.FromResult(_store.Exists(this.Name));
        }

        public override Task FetchAttributesAsync()
        {
            throw new NotImplementedException();
            // return base.FetchAttributesAsync();
        }

        public override Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.FetchAttributesAsync(options, operationContext);
        }

        public override Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.FetchAttributesAsync(options, operationContext, cancellationToken);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Task<CloudQueueMessage> GetMessageAsync()
        {
            // throw new NotImplementedException();
            return base.GetMessageAsync();
        }

        public override Task<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext)
        {
            // throw new NotImplementedException();
            return base.GetMessageAsync(visibilityTimeout, options, operationContext);
        }

        public override async Task<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            // throw new NotImplementedException();
            // return base.GetMessageAsync(visibilityTimeout, options, operationContext, cancellationToken);
            var msgs = await this.GetMessagesAsync(1);
            return msgs.FirstOrDefault();
        }

        public override Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount)
        {
            //throw new NotImplementedException();
            return base.GetMessagesAsync(messageCount);
        }

        public override Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext)
        {
            //throw new NotImplementedException();
            return base.GetMessagesAsync(messageCount, visibilityTimeout, options, operationContext);
        }

        public override Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            // throw new NotImplementedException();
            // return base.GetMessagesAsync(messageCount, visibilityTimeout, options, operationContext, cancellationToken);
            IEnumerable<CloudQueueMessage> messages = _store.GetMessages(this.Name, messageCount,
                visibilityTimeout ?? TimeSpan.FromSeconds(30));
            return Task.FromResult(messages);
        }

        public override Task<QueuePermissions> GetPermissionsAsync()
        {
            throw new NotImplementedException();
            // return base.GetPermissionsAsync();
        }

        public override Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.GetPermissionsAsync(options, operationContext);
        }

        public override Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.GetPermissionsAsync(options, operationContext, cancellationToken);
        }

        public override Task<CloudQueueMessage> PeekMessageAsync()
        {
            throw new NotImplementedException();
            // return base.PeekMessageAsync();
        }

        public override Task<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.PeekMessageAsync(options, operationContext);
        }

        public override Task<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.PeekMessageAsync(options, operationContext, cancellationToken);
        }

        public override Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount)
        {
            throw new NotImplementedException();
            // return base.PeekMessagesAsync(messageCount);
        }

        public override Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.PeekMessagesAsync(messageCount, options, operationContext);
        }

        public override Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.PeekMessagesAsync(messageCount, options, operationContext, cancellationToken);
        }

        public override Task SetMetadataAsync()
        {
            throw new NotImplementedException();
            // return base.SetMetadataAsync();
        }

        public override Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.SetMetadataAsync(options, operationContext);
        }

        public override Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.SetMetadataAsync(options, operationContext, cancellationToken);
        }

        public override Task SetPermissionsAsync(QueuePermissions permissions)
        {
            throw new NotImplementedException();
            // return base.SetPermissionsAsync(permissions);
        }

        public override Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.SetPermissionsAsync(permissions, options, operationContext);
        }

        public override Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.SetPermissionsAsync(permissions, options, operationContext, cancellationToken);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields)
        {
            //throw new NotImplementedException();
            return base.UpdateMessageAsync(message, visibilityTimeout, updateFields);
        }

        public override Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext)
        {
            //throw new NotImplementedException();
            return base.UpdateMessageAsync(message, visibilityTimeout, updateFields, options, operationContext);
        }

        public override Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            //return base.UpdateMessageAsync(message, visibilityTimeout, updateFields, options, operationContext, cancellationToken);

            _store.UpdateMessage(this.Name, message, visibilityTimeout, updateFields);
            return Task.FromResult(0);
        }
    }
}
