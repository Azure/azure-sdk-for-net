// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Storage.Queue;

namespace FakeStorage
{
    internal class MemoryQueueStore
    {
        private readonly ConcurrentDictionary<string, Queue> _items = new ConcurrentDictionary<string, Queue>();

        public void AddMessage(string queueName, CloudQueueMessage message)
        {
            if (!_items.ContainsKey(queueName))
            {
                throw StorageExceptionFactory.Create(404, "QueueNotFound");
            }

            _items[queueName].AddMessage(message);
        }

        public void CreateIfNotExists(string queueName)
        {
            _items.AddOrUpdate(queueName, new Queue(), (_, existing) => existing);
        }

        public void DeleteMessage(string queueName, CloudQueueMessage message)
        {
            _items[queueName].DeleteMessage(message);
        }

        public void Clear(string queueName)
        {
            Queue queue;
            if (_items.TryGetValue(queueName, out queue))
            {
                queue.Clear();
            }
        }

        public bool Exists(string queueName)
        {
            return _items.ContainsKey(queueName);
        }

        public IEnumerable<CloudQueueMessage> GetMessages(string queueName, int messageCount,
            TimeSpan visibilityTimeout)
        {
            if (!_items.ContainsKey(queueName))
            {
                return Enumerable.Empty<CloudQueueMessage>();
            }
            return _items[queueName].GetMessages(messageCount, visibilityTimeout);
        }

        public void UpdateMessage(string queueName, CloudQueueMessage message, TimeSpan visibilityTimeout,
            MessageUpdateFields updateFields)
        {
            _items[queueName].UpdateMessage(message, visibilityTimeout, updateFields);
        }

        private class Queue
        {
            private readonly ConcurrentQueue<CloudQueueMessage> _visibleMessages =
                new ConcurrentQueue<CloudQueueMessage>();
            private readonly ConcurrentDictionary<string, CloudQueueMessage> _invisibleMessages =
                new ConcurrentDictionary<string, CloudQueueMessage>();

            public void AddMessage(CloudQueueMessage message)
            {
                // need to create a new instance so other queues handling this message aren't updated
                DateTimeOffset now = DateTimeOffset.Now;
                var newMessage = new CloudQueueMessage(message.AsBytes);
                newMessage.SetId(Guid.NewGuid().ToString());
                newMessage.SetInsertionTime(now);
                newMessage.SetExpirationTime(now.AddDays(7));
                newMessage.SetNextVisibleTime(now);

                _visibleMessages.Enqueue(newMessage);
            }

            public void DeleteMessage(CloudQueueMessage message)
            {
                CloudQueueMessage ignore;

                if (!_invisibleMessages.TryRemove(message.PopReceipt, out ignore))
                {
                    throw new InvalidOperationException("Unable to delete message.");
                }
            }

            public IEnumerable<CloudQueueMessage> GetMessages(int messageCount, TimeSpan visibilityTimeout)
            {
                MakeExpiredInvisibleMessagesVisible();
                List<CloudQueueMessage> messages = new List<CloudQueueMessage>();
                CloudQueueMessage message;

                for (int count = 0; count < messageCount && _visibleMessages.TryDequeue(out message); count++)
                {
                    string popReceipt = Guid.NewGuid().ToString();
                    message.SetDequeueCount(message.DequeueCount + 1);
                    message.SetNextVisibleTime(DateTimeOffset.Now.Add(visibilityTimeout));
                    message.SetPopReceipt(popReceipt);
                    _invisibleMessages[popReceipt] = message;
                    messages.Add(message);
                }

                return messages;
            }

            public void UpdateMessage(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields)
            {
                CloudQueueMessage storedMessage = LookupMessage(message.PopReceipt);

                if ((updateFields & MessageUpdateFields.Content) == MessageUpdateFields.Content)
                {
                    // No-op; queue messages already provide in-memory content updating.
                }

                if ((updateFields & MessageUpdateFields.Visibility) == MessageUpdateFields.Visibility)
                {
                    DateTimeOffset nextVisibleTime = DateTimeOffset.Now.Add(visibilityTimeout);
                    storedMessage.SetNextVisibleTime(nextVisibleTime);
                    message.SetNextVisibleTime(nextVisibleTime);
                }
            }

            private void MakeExpiredInvisibleMessagesVisible()
            {
                KeyValuePair<string, CloudQueueMessage>[] invisibleMessagesSnapshot =
                    _invisibleMessages.ToArray();
                IEnumerable<string> expiredInvisibleMessagePopReceipts =
                    invisibleMessagesSnapshot.Where(
                    p => p.Value.NextVisibleTime.Value.UtcDateTime < DateTimeOffset.UtcNow).Select(p => p.Key);

                foreach (string popReceipt in expiredInvisibleMessagePopReceipts)
                {
                    CloudQueueMessage message;

                    if (_invisibleMessages.TryRemove(popReceipt, out message))
                    {
                        _visibleMessages.Enqueue(message);
                    }
                }
            }

            private CloudQueueMessage LookupMessage(string popReceipt)
            {
                CloudQueueMessage message = _visibleMessages.FirstOrDefault(p => p.PopReceipt == popReceipt);
                if (message == null)
                {
                    message = _invisibleMessages[popReceipt];
                }
                return message;
            }

            public void Clear()
            {
                CloudQueueMessage msg;
                while (this._visibleMessages.TryDequeue(out msg))
                {
                    // nop
                }

                this._invisibleMessages.Clear();
            }
        }  
    }
}
