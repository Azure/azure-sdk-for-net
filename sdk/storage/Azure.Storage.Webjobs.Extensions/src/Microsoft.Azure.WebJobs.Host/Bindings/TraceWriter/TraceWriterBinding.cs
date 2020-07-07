// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class TraceWriterBinding : IBinding
    {
        private readonly ParameterInfo _parameter;
        private ILoggerFactory _loggerFactory;

        public TraceWriterBinding(ParameterInfo parameter, ILoggerFactory loggerFactory)
        {
            _parameter = parameter;
            _loggerFactory = loggerFactory;
        }

        public bool FromAttribute
        {
            get { return false; }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "TraceWriter")]
        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            if (value == null || !_parameter.ParameterType.IsAssignableFrom(value.GetType()))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unable to convert value to {0}.", _parameter.ParameterType));
            }

            IValueProvider valueProvider = new ValueBinder(value, _parameter.ParameterType);
            return Task.FromResult<IValueProvider>(valueProvider);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ILogger logger = _loggerFactory.CreateLogger(LogCategories.CreateFunctionUserCategory(context.ValueContext.FunctionContext.MethodName));
            TraceWriter trace = new LoggerTraceWriter(logger);

            object tracer = trace;

            if (_parameter.ParameterType == typeof(TextWriter))
            {
                // bind to an adapter
                tracer = TextWriterTraceAdapter.Synchronized(trace);
            }

            return BindAsync(tracer, context.ValueContext);
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

            public Type Type
            {
                get { return _type; }
            }

            public Task<object> GetValueAsync()
            {
                return Task.FromResult(_tracer);
            }

            public string ToInvokeString()
            {
                return null;
            }

            public Task SetValueAsync(object value, CancellationToken cancellationToken)
            {
                TextWriter traceAdapter = value as TextWriter;
                if (traceAdapter != null)
                {
                    traceAdapter.Flush();
                }
                return Task.FromResult(0);
            }
        }
    }
}
