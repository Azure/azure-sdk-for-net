// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Cancellation
{
    internal class CancellationTokenBinding : IBinding
    {
        private readonly string _parameterName;

        public CancellationTokenBinding(string parameterName)
        {
            _parameterName = parameterName;
        }

        public bool FromAttribute
        {
            get { return false; }
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "context")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private Task<IValueProvider> BindAsync(CancellationToken token, ValueBindingContext context)
        {
            IValueProvider provider = new CancellationTokenValueProvider(token);
            return Task.FromResult(provider);
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            if (!(value is CancellationToken))
            {
                throw new InvalidOperationException("Unable to convert value to CancellationToken.");
            }

            CancellationToken token = (CancellationToken)value;

            return BindAsync(token, context);
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            return BindAsync(context.FunctionCancellationToken, context.ValueContext);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new CancellationTokenParameterDescriptor
            {
                Name = _parameterName
            };
        }
    }
}
