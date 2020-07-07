// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // Bind an IAsyncCollector to an 'Out T" parameter. 
    internal class OutValueProvider<TMessage> : IOrderedValueBinder
    {
        private readonly IAsyncCollector<TMessage> _raw;
        private readonly string _invokeString;

        // raw is the underlying object (exposes a Flush method).
        public OutValueProvider(IAsyncCollector<TMessage> raw, string invokeString)
        {
            _raw = raw;
            _invokeString = invokeString;
        }

        public BindStepOrder StepOrder
        {
            get { return BindStepOrder.Enqueue; }
        }

        public Type Type
        {
            get
            {
                return typeof(TMessage);
            }
        }

        public Task<object> GetValueAsync()
        {
            // Out parameters are set on return
            return Task.FromResult<object>(null);
        }

        public async Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            if (value == null)
            {
                // Nothing set
                return;
            }

            TMessage message = (TMessage)value;

            await _raw.AddAsync(message, cancellationToken);
            await _raw.FlushAsync();
        }

        public string ToInvokeString()
        {
            return _invokeString;
        }
    }
}