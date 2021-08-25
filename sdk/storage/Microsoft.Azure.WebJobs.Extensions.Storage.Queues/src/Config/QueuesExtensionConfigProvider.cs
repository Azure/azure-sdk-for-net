// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Protocols;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Config
{
    [Extension("AzureStorageQueues", "Queues")]
    internal class QueuesExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly IContextGetter<IMessageEnqueuedWatcher> _contextGetter;
        private readonly QueueServiceClientProvider _queueServiceClientProvider;
        private readonly QueueTriggerAttributeBindingProvider _triggerProvider;
        private readonly QueueCausalityManager _queueCausalityManager;

        public QueuesExtensionConfigProvider(QueueServiceClientProvider queueServiceClientProvider, IContextGetter<IMessageEnqueuedWatcher> contextGetter,
            QueueTriggerAttributeBindingProvider triggerProvider, QueueCausalityManager queueCausalityManager)
        {
            _contextGetter = contextGetter;
            _queueServiceClientProvider = queueServiceClientProvider;
            _triggerProvider = triggerProvider;
            _queueCausalityManager = queueCausalityManager;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.AddBindingRule<QueueTriggerAttribute>().BindToTrigger(_triggerProvider);

            var config = new PerHostConfig();
            config.Initialize(context, _queueServiceClientProvider, _contextGetter, _queueCausalityManager);
        }

        // $$$ Get rid of PerHostConfig part?
        // Multiple JobHost objects may share the same JobHostConfiguration.
        // But queues have per-host instance state (IMessageEnqueuedWatcher).
        // so capture that and create new binding rules per host instance.
        private class PerHostConfig : IConverter<QueueAttribute, IAsyncCollector<QueueMessage>>
        {
            // Fields that the various binding funcs need to close over.
            private QueueServiceClientProvider _queueServiceClientProvider;

            // Optimization where a queue output can directly trigger a queue input.
            // This is per-host (not per-config)
            private IContextGetter<IMessageEnqueuedWatcher> _messageEnqueuedWatcherGetter;

            private QueueCausalityManager _queueCausalityManager;

            public void Initialize(
                ExtensionConfigContext context,
                QueueServiceClientProvider queueServiceClientProvider,
                IContextGetter<IMessageEnqueuedWatcher> contextGetter,
                QueueCausalityManager queueCausalityManager)
            {
                _queueServiceClientProvider = queueServiceClientProvider;
                _messageEnqueuedWatcherGetter = contextGetter;
                _queueCausalityManager = queueCausalityManager;

                // IStorageQueueMessage is the core testing interface
                var binding = context.AddBindingRule<QueueAttribute>();
                binding
                    .AddConverter<byte[], QueueMessage>(ConvertByteArrayToCloudQueueMessage)
                    .AddConverter<string, QueueMessage>(ConvertStringToCloudQueueMessage)
                    .AddConverter<BinaryData, QueueMessage>(ConvertBinaryDataToCloudQueueMessage)
                    .AddOpenConverter<OpenType.Poco, QueueMessage>(ConvertPocoToCloudQueueMessage);

                context // global converters, apply to multiple attributes.
                     .AddConverter<QueueMessage, byte[]>(ConvertCloudQueueMessageToByteArray)
                     .AddConverter<QueueMessage, string>(ConvertCloudQueueMessageToString)
                     .AddConverter<QueueMessage, BinaryData>(ConvertCloudQueueMessageToBinaryData);

                var builder = new QueueBuilder(this);

                binding.AddValidator(ValidateQueueAttribute);

                binding.BindToCollector<QueueMessage>(this);

                binding.BindToInput<QueueClient>(builder);

                binding.BindToInput<QueueClient>(builder);
            }

            private async Task<object> ConvertPocoToCloudQueueMessage(object arg, Attribute attrResolved, ValueBindingContext context)
            {
                var attr = (QueueAttribute)attrResolved;
                var jobj = await SerializeToJobject(arg, context).ConfigureAwait(false);
                var msg = ConvertJObjectToCloudQueueMessage(jobj, attr);
                return msg;
            }

            private static QueueMessage ConvertJObjectToCloudQueueMessage(JObject obj, QueueAttribute attrResolved)
            {
                var json = obj.ToString(); // convert to JSon
                return ConvertStringToCloudQueueMessage(json, attrResolved);
            }

            // Hook JObject serialization to so we can stamp the object with a causality marker.
            private static Task<JObject> SerializeToJobject(object input, ValueBindingContext context)
            {
                JObject objectToken = JObject.FromObject(input, JsonSerialization.Serializer);
                var functionInstanceId = context.FunctionInstanceId;
                QueueCausalityManager.SetOwner(functionInstanceId, objectToken);

                return Task.FromResult<JObject>(objectToken);
            }

            private static string NormalizeQueueName(QueueAttribute attribute, INameResolver nameResolver)
            {
                string queueName = attribute.QueueName;
                if (nameResolver != null)
                {
                    queueName = nameResolver.ResolveWholeString(queueName);
                }
                queueName = queueName.ToLowerInvariant(); // must be lowercase. coerce here to be nice.
                return queueName;
            }

            // This is a static validation (so only %% are resolved; not {} )
            // For runtime validation, the regular builder functions can do the resolution.
            private void ValidateQueueAttribute(QueueAttribute attribute, Type parameterType)
            {
                string queueName = NormalizeQueueName(attribute, null);

                // Queue pre-existing  behavior: if there are { }in the path, then defer validation until runtime.
                if (!queueName.Contains("{"))
                {
                    QueueClientExtensions.ValidateQueueName(queueName);
                }
            }

            private byte[] ConvertCloudQueueMessageToByteArray(QueueMessage arg)
            {
                return arg.Body.ToArray();
            }

            private BinaryData ConvertCloudQueueMessageToBinaryData(QueueMessage arg)
            {
                return arg.Body;
            }

            private static string ConvertCloudQueueMessageToString(QueueMessage arg)
            {
                return arg.Body.ToValidUTF8String();
            }

            private static QueueMessage ConvertByteArrayToCloudQueueMessage(byte[] arg, QueueAttribute attrResolved)
            {
                return QueuesModelFactory.QueueMessage(null, null, new BinaryData(arg), 0);
            }

            private static QueueMessage ConvertBinaryDataToCloudQueueMessage(BinaryData arg, QueueAttribute attrResolved)
            {
                return QueuesModelFactory.QueueMessage(null, null, arg, 0);
            }

            private static QueueMessage ConvertStringToCloudQueueMessage(string arg, QueueAttribute attrResolved)
            {
                return QueuesModelFactory.QueueMessage(null, null, arg, 0);
            }

            public IAsyncCollector<QueueMessage> Convert(QueueAttribute attrResolved)
            {
                var queue = GetQueue(attrResolved);
                return new QueueAsyncCollector(queue, _messageEnqueuedWatcherGetter.Value);
            }

            internal QueueClient GetQueue(QueueAttribute attrResolved)
            {
                var client = _queueServiceClientProvider.Get(attrResolved.Connection);

                string queueName = attrResolved.QueueName.ToLowerInvariant();
                QueueClientExtensions.ValidateQueueName(queueName);

                return client.GetQueueClient(queueName);
            }
        }

        private class QueueBuilder :
            IAsyncConverter<QueueAttribute, QueueClient>
        {
            private readonly PerHostConfig _bindingProvider;

            public QueueBuilder(PerHostConfig bindingProvider)
            {
                _bindingProvider = bindingProvider;
            }

            async Task<QueueClient> IAsyncConverter<QueueAttribute, QueueClient>.ConvertAsync(
                QueueAttribute attrResolved,
                CancellationToken cancellation)
            {
                QueueClient queue = _bindingProvider.GetQueue(attrResolved);
                await queue.CreateIfNotExistsAsync(cancellationToken: cancellation).ConfigureAwait(false);
                return queue;
            }
        }

        // The core Async Collector for queueing messages.
        internal class QueueAsyncCollector : IAsyncCollector<QueueMessage>
        {
            private readonly QueueClient _queue;
            private readonly IMessageEnqueuedWatcher _messageEnqueuedWatcher;

            public QueueAsyncCollector(QueueClient queue, IMessageEnqueuedWatcher messageEnqueuedWatcher)
            {
                this._queue = queue;
                this._messageEnqueuedWatcher = messageEnqueuedWatcher;
            }

            public async Task AddAsync(QueueMessage message, CancellationToken cancellationToken = default(CancellationToken))
            {
                if (message == null)
                {
                    throw new InvalidOperationException("Cannot enqueue a null queue message instance.");
                }

                await _queue.AddMessageAndCreateIfNotExistsAsync(message.Body, cancellationToken).ConfigureAwait(false);

                if (_messageEnqueuedWatcher != null)
                {
                    _messageEnqueuedWatcher.Notify(_queue.Name);
                }
            }

            public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                // Batching not supported.
                return Task.FromResult(0);
            }
        }
    }
}
