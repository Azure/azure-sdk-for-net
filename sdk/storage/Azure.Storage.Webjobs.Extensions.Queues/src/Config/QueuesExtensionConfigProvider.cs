// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues.Triggers;
using Newtonsoft.Json.Linq;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Text;
using Azure.Core;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.Queues.Config
{
    [Extension("AzureStorageQueues", "Queues")]
    internal class QueuesExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly IContextGetter<IMessageEnqueuedWatcher> _contextGetter;
        private readonly StorageAccountProvider _storageAccountProvider;
        private readonly QueueTriggerAttributeBindingProvider _triggerProvider;

        public QueuesExtensionConfigProvider(StorageAccountProvider storageAccountProvider, IContextGetter<IMessageEnqueuedWatcher> contextGetter,
            QueueTriggerAttributeBindingProvider triggerProvider)
        {
            _contextGetter = contextGetter;
            _storageAccountProvider = storageAccountProvider;
            _triggerProvider = triggerProvider;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.AddBindingRule<QueueTriggerAttribute>().BindToTrigger(_triggerProvider);

            var config = new PerHostConfig();
            config.Initialize(context, _storageAccountProvider, _contextGetter);
        }

        // $$$ Get rid of PerHostConfig part?
        // Multiple JobHost objects may share the same JobHostConfiguration.
        // But queues have per-host instance state (IMessageEnqueuedWatcher).
        // so capture that and create new binding rules per host instance.
        private class PerHostConfig : IConverter<QueueAttribute, IAsyncCollector<QueueMessage>>
        {
            // Fields that the various binding funcs need to close over.
            private StorageAccountProvider _accountProvider;

            // Optimization where a queue output can directly trigger a queue input.
            // This is per-host (not per-config)
            private IContextGetter<IMessageEnqueuedWatcher> _messageEnqueuedWatcherGetter;

            public void Initialize(ExtensionConfigContext context, StorageAccountProvider storageAccountProvider, IContextGetter<IMessageEnqueuedWatcher> contextGetter)
            {
                _accountProvider = storageAccountProvider;
                _messageEnqueuedWatcherGetter = contextGetter;

                // TODO: FACAVAL replace this with queue options. This should no longer be needed.
                //context.ApplyConfig(context.Config.Queues, "queues");

                // IStorageQueueMessage is the core testing interface
                var binding = context.AddBindingRule<QueueAttribute>();
                binding
                    .AddConverter<byte[], QueueMessage>(ConvertByteArrayToCloudQueueMessage)
                    .AddConverter<string, QueueMessage>(ConvertStringToCloudQueueMessage)
                    .AddOpenConverter<OpenType.Poco, QueueMessage>(ConvertPocoToCloudQueueMessage);

                context // global converters, apply to multiple attributes.
                     .AddConverter<QueueMessage, byte[]>(ConvertCloudQueueMessageToByteArray)
                     .AddConverter<QueueMessage, string>(ConvertCloudQueueMessageToString);

                var builder = new QueueBuilder(this);

                binding.AddValidator(ValidateQueueAttribute);

#pragma warning disable CS0618 // Type or member is obsolete
                binding.SetPostResolveHook(ToWriteParameterDescriptorForCollector)
#pragma warning restore CS0618 // Type or member is obsolete
                        .BindToCollector<QueueMessage>(this);

#pragma warning disable CS0618 // Type or member is obsolete
                binding.SetPostResolveHook(ToReadWriteParameterDescriptorForCollector)
#pragma warning restore CS0618 // Type or member is obsolete
                        .BindToInput<QueueClient>(builder);

#pragma warning disable CS0618 // Type or member is obsolete
                binding.SetPostResolveHook(ToReadWriteParameterDescriptorForCollector)
#pragma warning restore CS0618 // Type or member is obsolete
                        .BindToInput<QueueClient>(builder);
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

            // ParameterDescriptor for binding to CloudQueue. Whereas the output bindings are FileAccess.Write; CloudQueue exposes Peek()
            // and so is technically Read/Write.
            // Preserves compat with older SDK.
            private ParameterDescriptor ToReadWriteParameterDescriptorForCollector(QueueAttribute attr, ParameterInfo parameter, INameResolver nameResolver)
            {
                return ToParameterDescriptorForCollector(attr, parameter, nameResolver, FileAccess.ReadWrite);
            }

            // Asyncollector version. Write-only
            private ParameterDescriptor ToWriteParameterDescriptorForCollector(QueueAttribute attr, ParameterInfo parameter, INameResolver nameResolver)
            {
                return ToParameterDescriptorForCollector(attr, parameter, nameResolver, FileAccess.Write);
            }

            private ParameterDescriptor ToParameterDescriptorForCollector(QueueAttribute attr, ParameterInfo parameter, INameResolver nameResolver, FileAccess access)
            {
                var account = _accountProvider.Get(attr.Connection, nameResolver);
                var accountName = account.Name;

                return new QueueParameterDescriptor
                {
                    Name = parameter.Name,
                    AccountName = accountName,
                    QueueName = NormalizeQueueName(attr, nameResolver),
                    Access = access
                };
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
                return Encoding.UTF8.GetBytes(arg.MessageText);
            }

            private static string ConvertCloudQueueMessageToString(QueueMessage arg)
            {
                return arg.MessageText;
            }

            private static QueueMessage ConvertByteArrayToCloudQueueMessage(byte[] arg, QueueAttribute attrResolved)
            {
                // TODO (kasobol-msft) revisit this base64/BinaryData
                return QueuesModelFactory.QueueMessage(null, null, Encoding.UTF8.GetString(arg), 0);
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
                var account = _accountProvider.Get(attrResolved.Connection);
                var client = account.CreateQueueServiceClient();

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

                await _queue.AddMessageAndCreateIfNotExistsAsync(message.MessageText, cancellationToken).ConfigureAwait(false);

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
