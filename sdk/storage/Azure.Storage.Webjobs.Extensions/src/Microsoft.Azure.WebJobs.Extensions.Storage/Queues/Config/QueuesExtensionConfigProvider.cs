// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json.Linq;

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
        private class PerHostConfig : IConverter<QueueAttribute, IAsyncCollector<CloudQueueMessage>>
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
                    .AddConverter<byte[], CloudQueueMessage>(ConvertByteArrayToCloudQueueMessage)
                    .AddConverter<string, CloudQueueMessage>(ConvertStringToCloudQueueMessage)
                    .AddOpenConverter<OpenType.Poco, CloudQueueMessage>(ConvertPocoToCloudQueueMessage);

                context // global converters, apply to multiple attributes. 
                     .AddConverter<CloudQueueMessage, byte[]>(ConvertCloudQueueMessageToByteArray)
                     .AddConverter<CloudQueueMessage, string>(ConvertCloudQueueMessageToString);

                var builder = new QueueBuilder(this);

                binding.AddValidator(ValidateQueueAttribute);

                binding.SetPostResolveHook(ToWriteParameterDescriptorForCollector)
                        .BindToCollector<CloudQueueMessage>(this);

                binding.SetPostResolveHook(ToReadWriteParameterDescriptorForCollector)
                        .BindToInput<CloudQueue>(builder);

                binding.SetPostResolveHook(ToReadWriteParameterDescriptorForCollector)
                        .BindToInput<CloudQueue>(builder);
            }

            private async Task<object> ConvertPocoToCloudQueueMessage(object arg, Attribute attrResolved, ValueBindingContext context)
            {
                var attr = (QueueAttribute)attrResolved;
                var jobj = await SerializeToJobject(arg, attr, context);
                var msg = ConvertJObjectToCloudQueueMessage(jobj, attr);
                return msg;
            }

            private CloudQueueMessage ConvertJObjectToCloudQueueMessage(JObject obj, QueueAttribute attrResolved)
            {
                var json = obj.ToString(); // convert to JSon
                return ConvertStringToCloudQueueMessage(json, attrResolved);
            }

            // Hook JObject serialization to so we can stamp the object with a causality marker. 
            private static Task<JObject> SerializeToJobject(object input, Attribute attrResolved, ValueBindingContext context)
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
                    QueueClient.ValidateQueueName(queueName);
                }
            }

            private byte[] ConvertCloudQueueMessageToByteArray(CloudQueueMessage arg)
            {
                return arg.AsBytes;
            }

            private string ConvertCloudQueueMessageToString(CloudQueueMessage arg)
            {
                return arg.AsString;
            }

            private CloudQueueMessage ConvertByteArrayToCloudQueueMessage(byte[] arg, QueueAttribute attrResolved)
            {
                return new CloudQueueMessage(arg);
            }

            private CloudQueueMessage ConvertStringToCloudQueueMessage(string arg, QueueAttribute attrResolved)
            {
                return new CloudQueueMessage(arg);
            }

            public IAsyncCollector<CloudQueueMessage> Convert(QueueAttribute attrResolved)
            {
                var queue = GetQueue(attrResolved);
                return new QueueAsyncCollector(queue, _messageEnqueuedWatcherGetter.Value);
            }

            internal CloudQueue GetQueue(QueueAttribute attrResolved)
            {
                var account = _accountProvider.Get(attrResolved.Connection);
                var client = account.CreateCloudQueueClient();

                string queueName = attrResolved.QueueName.ToLowerInvariant();
                QueueClient.ValidateQueueName(queueName);

                return client.GetQueueReference(queueName);
            }
        }

        private class QueueBuilder :
            IAsyncConverter<QueueAttribute, CloudQueue>
        {
            private readonly PerHostConfig _bindingProvider;

            public QueueBuilder(PerHostConfig bindingProvider)
            {
                _bindingProvider = bindingProvider;
            }

            async Task<CloudQueue> IAsyncConverter<QueueAttribute, CloudQueue>.ConvertAsync(
                QueueAttribute attrResolved,
                CancellationToken cancellation)
            {
                CloudQueue queue = _bindingProvider.GetQueue(attrResolved);
                await queue.CreateIfNotExistsAsync(cancellation);
                return queue;
            }
        }

        // The core Async Collector for queueing messages. 
        internal class QueueAsyncCollector : IAsyncCollector<CloudQueueMessage>
        {
            private readonly CloudQueue _queue;
            private readonly IMessageEnqueuedWatcher _messageEnqueuedWatcher;

            public QueueAsyncCollector(CloudQueue queue, IMessageEnqueuedWatcher messageEnqueuedWatcher)
            {
                this._queue = queue;
                this._messageEnqueuedWatcher = messageEnqueuedWatcher;
            }

            public async Task AddAsync(CloudQueueMessage message, CancellationToken cancellationToken = default(CancellationToken))
            {
                if (message == null)
                {
                    throw new InvalidOperationException("Cannot enqueue a null queue message instance.");
                }

                await _queue.AddMessageAndCreateIfNotExistsAsync(message, cancellationToken);

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