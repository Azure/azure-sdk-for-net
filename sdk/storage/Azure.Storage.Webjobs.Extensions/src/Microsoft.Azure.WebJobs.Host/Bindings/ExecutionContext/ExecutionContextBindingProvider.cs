// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// This provider provides a binding to Type <see cref="ExecutionContext"/>.
    /// </summary>
    internal class ExecutionContextBindingProvider : IBindingProvider
    {
        private readonly IOptions<ExecutionContextOptions> _options;

        public ExecutionContextBindingProvider(IOptions<ExecutionContextOptions> options)
        {
            _options = options;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (context.Parameter.ParameterType != typeof(ExecutionContext))
            {
                return Task.FromResult<IBinding>(null);
            }

            return Task.FromResult<IBinding>(new ExecutionContextBinding(context.Parameter, _options));
        }

        private class ExecutionContextBinding : IBinding
        {
            private readonly ParameterInfo _parameter;
            private readonly IOptions<ExecutionContextOptions> _options;
            private static ParameterDisplayHints _displayHints = new ParameterDisplayHints { Description = "Function ExecutionContext" };

            public ExecutionContextBinding(ParameterInfo parameter, IOptions<ExecutionContextOptions> options)
            {
                _parameter = parameter;
                _options = options;
            }

            public bool FromAttribute
            {
                get { return false; }
            }

            public Task<IValueProvider> BindAsync(BindingContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                return Task.FromResult<IValueProvider>(new ExecutionContextValueProvider(context.ValueContext, _options));
            }

            public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                return Task.FromResult<IValueProvider>(new ExecutionContextValueProvider(context, _options));
            }

            public ParameterDescriptor ToParameterDescriptor()
            {
                return new ParameterDescriptor
                {
                    Name = _parameter.Name,
                    DisplayHints = _displayHints
                };
            }

            private class ExecutionContextValueProvider : IValueProvider
            {
                private readonly ValueBindingContext _context;
                private readonly IOptions<ExecutionContextOptions> _options;

                public ExecutionContextValueProvider(ValueBindingContext context, IOptions<ExecutionContextOptions> options)
                {
                    _context = context;
                    _options = options;
                }

                public Type Type
                {
                    get { return typeof(ExecutionContext); }
                }

                public Task<object> GetValueAsync()
                {
                    return Task.FromResult<object>(CreateContext());
                }

                public string ToInvokeString()
                {
                    return _context.FunctionInstanceId.ToString();
                }

                private ExecutionContext CreateContext()
                {
                    var result = new ExecutionContext
                    {
                        InvocationId = _context.FunctionInstanceId,
                        FunctionName = _context.FunctionContext.MethodName,
                        FunctionDirectory = Environment.CurrentDirectory,
                        FunctionAppDirectory = _options.Value.AppDirectory
                    };

                    if (result.FunctionAppDirectory != null)
                    {
                        result.FunctionDirectory = System.IO.Path.Combine(result.FunctionAppDirectory, result.FunctionName);
                    }

                    return result;
                }
            }
        }
    }
}