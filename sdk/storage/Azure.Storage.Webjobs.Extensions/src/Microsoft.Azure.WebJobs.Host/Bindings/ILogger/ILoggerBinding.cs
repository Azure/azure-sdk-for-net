// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class ILoggerBinding : IBinding
    {
        private readonly ParameterInfo _parameter;
        private readonly ILoggerFactory _loggerFactory;

        public ILoggerBinding(ParameterInfo parameter, ILoggerFactory loggerFactory)
        {
            _parameter = parameter;
            _loggerFactory = loggerFactory;
        }

        public bool FromAttribute => false;

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            if (value == null || !_parameter.ParameterType.IsAssignableFrom(value.GetType()))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unable to convert value to {0}.", _parameter.ParameterType));
            }

            IValueProvider valueProvider = new ValueBinder(value, _parameter.ParameterType);
            return Task.FromResult<IValueProvider>(valueProvider);
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ILogger logger = _loggerFactory.CreateLogger(LogCategories.CreateFunctionUserCategory(context.ValueContext.FunctionContext.MethodName));
            return BindAsync(logger, context.ValueContext);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor
            {
                Name = _parameter.Name
            };
        }

        private sealed class ValueBinder : IValueBinder
        {
            private readonly object _tracer;
            private readonly Type _type;

            public ValueBinder(object tracer, Type type)
            {
                _tracer = tracer;
                _type = type;
            }

            public Type Type => _type;

            public Task<object> GetValueAsync() => Task.FromResult(_tracer);

            public string ToInvokeString() => null;

            public Task SetValueAsync(object value, CancellationToken cancellationToken) => Task.CompletedTask;
        }
    }
}
