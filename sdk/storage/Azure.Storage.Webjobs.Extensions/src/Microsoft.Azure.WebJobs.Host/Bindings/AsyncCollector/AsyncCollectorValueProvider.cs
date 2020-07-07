// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // ValueProvider for binding to an IAsyncCollector.
    // TUser is the parameter type from the user function we're binding to. 
    // TMessage is from the underying IAsyncCollector<TMessage>
    internal class AsyncCollectorValueProvider<TUser, TMessage> : IOrderedValueBinder
    {
        private readonly IAsyncCollector<TMessage> _raw;
        private readonly TUser _object;
        private readonly string _invokeString;

        // raw is the underlying object (exposes a Flush method).
        // obj is the front-end veneer to pass to the user function. 
        // calls to obj will trickle through adapters to be calls on raw. 
        public AsyncCollectorValueProvider(TUser obj, IAsyncCollector<TMessage> raw, string invokeString)
        {
            _raw = raw;
            _object = obj;
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
                return typeof(TUser);
            }
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_object);
        }

        public async Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            await _raw.FlushAsync();
        }

        public string ToInvokeString()
        {
            return _invokeString;
        }
    }
}