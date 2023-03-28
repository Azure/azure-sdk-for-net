// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
	/// <summary>
	/// This class manages a queue of Service Bus messages using a minimum and maximum batch size. This class is NOT thread safe.
	/// Concurrency must be managed by the class using this message manager.
	/// </summary>
	internal class ServiceBusMessageManager
	{
		private int _maxBatchSize;
		private int _minBatchSize;

		// This is internal for mocking purposes only.
		internal Queue<ServiceBusMessage> CachedMessages { get; set; }

		public bool HasCachedMessages
		{
			get
			{
				return CachedMessages.Count > 0;
			}
		}

		public ServiceBusMessageManager(int maxBatchSize, int minBatchSize)
		{
			CachedMessages = new Queue<ServiceBusMessage>();
			_maxBatchSize = maxBatchSize;
			_minBatchSize = minBatchSize;
		}

		public void ClearEventCache()
		{
			CachedMessages.Clear();
		}

		/// <summary>
		/// Try to create a batch from <paramref name="messages"/> and any messages stored in the cache. If <paramref name="allowPartialBatch"/>
		/// is true, this method return all messages available even if there aren't enough to hit the minimum batch size threshold. If
		/// <paramref name="allowPartialBatch"/> is false, this method either returns a batch of at least the minimum batch size (and less than the
		/// maximum batch size), or it returns nothing and retains all available messages in the cache.
		/// </summary>
		/// <param name="messages">An array of messages to either add to a batch or cache.</param>
		/// <param name="allowPartialBatch">True if batches smaller than the minimum batch size can be returned.</param>
		/// <returns></returns>
		public ServiceBusMessage[] TryGetBatchofEventsWithCached(ServiceBusMessage[] messages = null, bool allowPartialBatch = false)
		{
			ServiceBusMessage[] messagesToReturn;
			var inputMessages = messages?.Length ?? 0;
			var totalMessages = CachedMessages.Count + inputMessages;

			// Enqueue all new messages, if any, to the cache queue.
			if (messages != null)
			{
				foreach (var message in messages)
				{
					CachedMessages.Enqueue(message);
				}
			}

			if (totalMessages < _minBatchSize && !allowPartialBatch)
			{
				// If we don't have enough messages, and we can't return a partial batch, just return an empty array.
				messagesToReturn = Array.Empty<ServiceBusMessage>();
			}
			else
			{
				// If we have enough messages, pull all the messages off the queue to return.
				var sizeOfBatch = totalMessages > _maxBatchSize ? _maxBatchSize : totalMessages;
				messagesToReturn = new ServiceBusMessage[sizeOfBatch];
				for (int i = 0; i < sizeOfBatch; i++)
				{
					var nextMessage = CachedMessages.Dequeue();
					messagesToReturn[i] = nextMessage;
				}
			}
			return messagesToReturn;
		}
	}
}