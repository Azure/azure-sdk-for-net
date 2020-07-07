// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Binding provider handling bindings to <see cref="TraceWriter"/> and <see cref="TextWriter"/>.
    /// </summary>
    internal class TraceWriterBindingProvider : IBindingProvider
    {
        private ILoggerFactory _loggerFactory;

        public TraceWriterBindingProvider(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ParameterInfo parameter = context.Parameter;
            if (parameter.ParameterType != typeof(TraceWriter) &&
                parameter.ParameterType != typeof(TextWriter))
            {
                return Task.FromResult<IBinding>(null);
            }

            IBinding binding = new TraceWriterBinding(parameter, _loggerFactory);
            return Task.FromResult(binding);
        }
    }
}
