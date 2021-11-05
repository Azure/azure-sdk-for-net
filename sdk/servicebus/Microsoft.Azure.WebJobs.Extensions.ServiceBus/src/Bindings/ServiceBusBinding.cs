// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class ServiceBusBinding : IBinding
    {
        private readonly string _parameterName;
        private readonly IArgumentBinding<ServiceBusEntity> _argumentBinding;
        private readonly IBindableServiceBusPath _path;
        private readonly IAsyncObjectToTypeConverter<ServiceBusEntity> _converter;
        private readonly MessagingProvider _messagingProvider;
        private readonly ServiceBusClientFactory _clientFactory;
        private readonly ServiceBusAttribute _attribute;

        public ServiceBusBinding(
            string parameterName,
            IArgumentBinding<ServiceBusEntity> argumentBinding,
            IBindableServiceBusPath path,
            ServiceBusAttribute attribute,
            MessagingProvider messagingProvider,
            ServiceBusClientFactory clientFactory)
        {
            _parameterName = parameterName;
            _argumentBinding = argumentBinding;
            _path = path;
            _messagingProvider = messagingProvider;
            _clientFactory = clientFactory;
            _attribute = attribute;
            _converter = new OutputConverter<string>(new StringToServiceBusEntityConverter(_attribute, _path, _messagingProvider, _clientFactory));
        }

        public bool FromAttribute
        {
            get { return true; }
        }

        public async Task<IValueProvider> BindAsync(BindingContext context)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            string boundQueueName = _path.Bind(context.BindingData);
            var messageSender = _messagingProvider.CreateMessageSender(_clientFactory.CreateClientFromSetting(_attribute.Connection), boundQueueName);

            var entity = new ServiceBusEntity
            {
                MessageSender = messageSender,
                ServiceBusEntityType = _attribute.EntityType,
            };

            return await BindAsync(entity, context.ValueContext).ConfigureAwait(false);
        }

        public async Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            ConversionResult<ServiceBusEntity> conversionResult = await _converter.TryConvertAsync(value, context.CancellationToken).ConfigureAwait(false);

            if (!conversionResult.Succeeded)
            {
                throw new InvalidOperationException("Unable to convert value to ServiceBusEntity.");
            }

            return await BindAsync(conversionResult.Result, context).ConfigureAwait(false);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ServiceBusParameterDescriptor
            {
                Name = _parameterName,
                QueueOrTopicName = _path.QueueOrTopicNamePattern,
                DisplayHints = CreateParameterDisplayHints(_path.QueueOrTopicNamePattern, false)
            };
        }

        private Task<IValueProvider> BindAsync(ServiceBusEntity value, ValueBindingContext context)
        {
            return _argumentBinding.BindAsync(value, context);
        }

        internal static ParameterDisplayHints CreateParameterDisplayHints(string entityPath, bool isInput)
        {
            ParameterDisplayHints descriptor = new ParameterDisplayHints
            {
                Description = isInput ?
                string.Format(CultureInfo.CurrentCulture, "dequeue from '{0}'", entityPath) :
                string.Format(CultureInfo.CurrentCulture, "enqueue to '{0}'", entityPath),

                Prompt = isInput ?
                "Enter the queue message body" :
                "Enter the output entity name",

                DefaultValue = isInput ? null : entityPath
            };

            return descriptor;
        }
    }
}
